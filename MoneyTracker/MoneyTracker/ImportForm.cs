using MoneyTrackerDataModel.Contexts;
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

        #region Constructor
        public ImportForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        private void ImportForm_Load(object sender, EventArgs e)
        {
            //SetControlDefaults();
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            LoadSourceData();
            AutoAssignValues();

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (WriteToDatabase())
            {
                MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        #endregion

        private void SetControlDefaults()
        {
            grdDataView.RowHeadersVisible = false;
            grdDataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDataView.Rows.Clear();
            grdDataView.Columns.Clear();

            openDialog.Filter = "Text Files|*.txt|CSV files|*.csv";
            //openDialog.ValidateNames = false;
        }

        private void LoadSourceData()
        {
            try
            {
                SetControlDefaults();

                if (openDialog.ShowDialog() != DialogResult.Cancel)
                {
                    txtImportFile.Text = openDialog.FileName;

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
            grdDataView.Rows[0].Selected = true;
        }

        private void AutoAssignValues()
        {
            using (var db = new Context(_connStr))
            {
                try
                {
                    var query = (from aa in db.AutoAllocations select aa).ToList(); //ToList() is necessary to avoid recalling the query
                    foreach (var row in query)
                    {
                        for (int li_row = 0; li_row <= grdDataView.Rows.Count - 1; li_row++)
                        {
                            var lo_cellValue = grdDataView.Rows[li_row].Cells[row.GridColumnName].Value;
                            //if (lo_cellValue == null)
                            //{
                            //    lo_cellValue = string.Empty;
                            //}
                            if (PatternMatch(lo_cellValue.ToString(), row.GridDataPattern))
                            {
                                grdDataView.Rows[li_row].Cells[row.UpdateColumnName].Value = row.UpdateDataValue;
                            }
                        }
                    }
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
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
