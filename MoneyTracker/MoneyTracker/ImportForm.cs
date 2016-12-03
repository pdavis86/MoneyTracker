﻿using MoneyTrackerDataModel.Contexts;
using MoneyTrackerDataModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportForm : Form
    {

        //private string _connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=personal;Integrated Security=True;MultipleActiveResultSets=True"; //todo: move this
        private string _connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True;MultipleActiveResultSets=True";
        private OpenFileDialog openDialog = new OpenFileDialog();
        private Dictionary<int, string> _comboColumnMappings;

        #region Constructor
        public ImportForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        private void ImportForm_Load(object sender, EventArgs e)
        {
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            BuildGrid();
            LoadSourceData();
            ModifyGrid();
            AutoAssignValues();
            grdDataView.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
            grdDataView.CellValueChanged += new DataGridViewCellEventHandler(grdDataView_CellValueChanged);

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (WriteToDatabase())
            {
                MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdDataView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                grdDataView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void grdDataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_comboColumnMappings.ContainsKey(e.ColumnIndex))
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)grdDataView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cb.Value != null)
                {
                    if (grdDataView.Rows[e.RowIndex].Cells[_comboColumnMappings[e.ColumnIndex]].Value?.ToString() != cb.Value.ToString())
                    {
                        grdDataView.Rows[e.RowIndex].Cells[_comboColumnMappings[e.ColumnIndex]].Value = cb.Value;
                    }
                }
            }
        }

        #endregion

        private void LoadSourceData()
        {
            try
            {
                openDialog.Filter = "Text Files|*.txt|CSV files|*.csv";
                //openDialog.ValidateNames = false;

                if (openDialog.ShowDialog() != DialogResult.Cancel)
                {
                    txtImportFile.Text = openDialog.FileName;
                    this.Refresh();

                    //Read file format from the header line
                    using (StreamReader lo_reader = new StreamReader(openDialog.FileName))
                    {
                        string ls_lineText = null;
                        do
                        {
                            ls_lineText = lo_reader.ReadLine();
                        } while (string.IsNullOrWhiteSpace(ls_lineText));
                        if (ls_lineText.StartsWith("From:"))
                        {
                            //todo: load on a separate thread and show progress
                            LoadDataFromSantander(lo_reader);
                        }
                        else
                        {
                            throw new ApplicationException("Unsupported format");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var dosomething = ex.ToString();
                //todo:
            }
        }

        private void BuildGrid()
        {
            //grdDataView.AutoGenerateColumns = false;

            grdDataView.RowHeadersVisible = false;
            grdDataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //todo: why doesn't this work? 
            grdDataView.Rows.Clear();
            grdDataView.Columns.Clear();

            //var transTypeCombo = GetTranstypeCombo();

            //foreach (var prop in typeof(Transaction).GetProperties())
            //{
            //    switch (prop.Name)
            //    {
            //        case "Category":
            //            grdDataView.Columns.Add(new DataGridViewComboBoxColumn()
            //            {
            //                Name = prop.Name,
            //                HeaderText = prop.Name,
            //                CellTemplate = transTypeCombo
            //            });
            //            break;

            //        default:
            //            grdDataView.Columns.Add(prop.Name, prop.Name);
            //            break;
            //    }
            //    if (prop.Name == "Value" || prop.Name == "Balance")
            //    {
            //        grdDataView.Columns[prop.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    }
            //    //todo: grdDataView.Columns[prop.Name].ReadOnly = true;
            //    //todo: why doesn't this work? - grdDataView.Columns[prop.Name].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}

            //grdDataView.Columns["TransactionId"].Visible = false;
            //grdDataView.Columns["AccountId"].Visible = false;
            //grdDataView.Columns["CategoryId"].Visible = false;
            //grdDataView.Columns["TypeId"].Visible = false;

            //grdDataView.Columns["Account"].DisplayIndex = 0;
            //grdDataView.Columns["Category"].DisplayIndex = 1;
            //grdDataView.Columns["Type"].DisplayIndex = 2;
        }

        private void LoadDataFromSantander(StreamReader reader)
        {

            string charToRemove = (System.Text.Encoding.Unicode.GetString(new byte[] { 0xa0 }));
            var transList = new List<Transaction>();

            //Read past the initial lines
            if (!string.IsNullOrWhiteSpace(reader.ReadLine()))
            {
                MessageBox.Show("Failed to read past header line 2", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!reader.ReadLine().StartsWith("Account:"))
            {
                MessageBox.Show("Failed to read past header line 3", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!string.IsNullOrWhiteSpace(reader.ReadLine()))
            {
                MessageBox.Show("Failed to read past header line 4", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var tempTransaction = new Transaction();

            //Read in the data
            string lineText = null;
            do
            {
                lineText = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(lineText))
                {
                    string lineTextStripped = lineText.Replace(charToRemove, " ").Trim();
                    switch (lineTextStripped.Substring(0, 5))
                    {
                        case "Date:":
                            tempTransaction.Date = Convert.ToDateTime(lineTextStripped.Substring(6));
                            break;
                        case "Descr":
                            tempTransaction.Description = lineTextStripped.Substring(13);
                            break;
                        case "Amoun":
                            tempTransaction.Value = decimal.Parse(lineTextStripped.Substring(8).Replace("GBP", " "));
                            break;
                        case "Balan":
                            tempTransaction.Balance = decimal.Parse(lineTextStripped.Substring(9).Replace("GBP", " "));
                            break;
                    }
                }
                if (string.IsNullOrWhiteSpace(lineText) || reader.EndOfStream)
                {
                    transList.Insert(0, tempTransaction); //Sort by date (oldest to newest)
                    tempTransaction = new Transaction();
                }
            } while (reader.EndOfStream == false);

            grdDataView.DataSource = transList;
        }

        private void ModifyGrid()
        {
            grdDataView.Columns["TransactionId"].Visible = false;
            //todo: grdDataView.Columns["AccountId"].Visible = false;
            //todo: grdDataView.Columns["CategoryId"].Visible = false;
            //todo: grdDataView.Columns["TypeId"].Visible = false;
            grdDataView.Columns["Balance"].Visible = false;
            grdDataView.Columns["Account"].Visible = false;
            grdDataView.Columns["Category"].Visible = false;
            grdDataView.Columns["Type"].Visible = false;

            grdDataView.Columns["Date"].ReadOnly = true;
            grdDataView.Columns["Description"].ReadOnly = true;
            grdDataView.Columns["Value"].ReadOnly = true;

            grdDataView.Columns.Add(new DataGridViewComboBoxColumn()
            {
                Name = "CategoryCombo",
                HeaderText = "Category",
                DisplayIndex = 1,
                CellTemplate = GetTransCategCombo()
            });

            grdDataView.Columns.Add(new DataGridViewComboBoxColumn()
            {
                Name = "TypeCombo",
                HeaderText = "Type",
                DisplayIndex = 2,
                CellTemplate = GetTranstypeCombo()
            });

            //grdDataView.Columns["Account"].DisplayIndex = 0;

            _comboColumnMappings = new Dictionary<int, string>();
            _comboColumnMappings.Add(grdDataView.Columns["CategoryCombo"].Index, "CategoryId");
            _comboColumnMappings.Add(grdDataView.Columns["TypeCombo"].Index, "TypeId");

            grdDataView.Rows[0].Selected = true;
        }

        private void AutoAssignValues()
        {
            using (var db = new Context(_connStr))
            {
                try
                {
                    var query = (from aa in db.AutoAllocations select aa).ToList(); //ToList() is necessary to avoid recalling the query
                    foreach (var autoAlloc in query)
                    {
                        for (int li_row = 0; li_row <= grdDataView.Rows.Count - 1; li_row++)
                        {
                            var lo_cellValue = grdDataView.Rows[li_row].Cells[autoAlloc.GridColumnName].Value;
                            if (lo_cellValue != null && PatternMatch(lo_cellValue.ToString(), autoAlloc.GridDataPattern))
                            {
                                grdDataView.Rows[li_row].Cells[autoAlloc.UpdateColumnName].Value = autoAlloc.UpdateDataValue;
                                if (autoAlloc.UpdateColumnName == "CategoryId")
                                {
                                    grdDataView.Rows[li_row].Cells["CategoryCombo"].Value = int.Parse(autoAlloc.UpdateDataValue);
                                }
                                else if (autoAlloc.UpdateColumnName == "TypeId")
                                {
                                    grdDataView.Rows[li_row].Cells["TypeCombo"].Value = int.Parse(autoAlloc.UpdateDataValue);
                                }
                            }
                        }
                    }
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    //todo:
                    var actualException = ex.InnerException;
                }

            }
        }

        private bool PatternMatch(string dataValue, string matchPattern)
        {
            string matchValue = matchPattern.Replace("*", "");
            if (!matchPattern.Contains("*"))
            {
                return dataValue.Equals(matchValue, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                if (matchPattern.StartsWith("*"))
                {
                    if (matchPattern.EndsWith("*"))
                    {
                        return dataValue.Contains(matchValue);
                    }
                    return dataValue.EndsWith(matchValue);
                }
                return dataValue.StartsWith(matchValue);
            }
        }

        private DataGridViewComboBoxCell GetTranstypeCombo()
        {
            DataGridViewComboBoxCell lo_return = new DataGridViewComboBoxCell();
            lo_return.DisplayMember = "Description";
            lo_return.ValueMember = "TypeId";
            using (var db = new Context(_connStr))
            {
                lo_return.DataSource = (from t in db.TransactionTypes orderby t.Description select t).ToList();
            }
            return lo_return;
        }

        private DataGridViewComboBoxCell GetTransCategCombo()
        {
            DataGridViewComboBoxCell lo_return = new DataGridViewComboBoxCell();
            lo_return.DisplayMember = "Description";
            lo_return.ValueMember = "CategoryId";
            using (var db = new Context(_connStr))
            {
                lo_return.DataSource = (from t in db.Categories orderby t.Description select t).ToList();
            }
            return lo_return;
        }

        private bool WriteToDatabase()
        {
            try
            {
                //todo:
                using (var db = new Context(_connStr))
                {
                }
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex1)
            {
                foreach (var eve in ex1.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var face = eve.Entry.Entity.ToString() + " had error: " + ve.ErrorMessage;
                    }
                }

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex2)
            {
                var actualException = ex2.InnerException.InnerException;
                System.Diagnostics.Debugger.Break();
            }
            return false;
        }

    } //End class
} //End namespace
