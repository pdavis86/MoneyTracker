using CsvHelper;
using MoneyTracker.UI.Extensions;
using MoneyTrackerDataModel.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportTransForm : Form
    {
        public int AccountId { get; set; }

        private OpenFileDialog openDialog = new OpenFileDialog();

        #region Constructor
        public ImportTransForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        private void ImportTransForm_Shown(object sender, EventArgs e)
        {
            BuildGrid();
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            grdDataView.Rows.Clear();

            //todo: deal with exceptions
            //try
            //{
            LoadSourceData();
            AutoAssignValues();
            //}
            //catch (Exception ex)
            //{
            //    var dosomething = ex.ToString();
            //    Debugger.Break();
            //}
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //todo: deal with exceptions
            //try
            //{
            if (WriteToDatabase())
            {
                MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            //}
            //catch (Exception ex)
            //{
            //    var dosomething = ex.ToString();
            //    Debugger.Break();
            //}
        }

        private void cbLoad_Click(object sender, EventArgs e)
        {
            LoadTransactionsNeedingAttention();

            if (grdDataView.Rows.Count == 0)
            {
                MessageBox.Show("There were none", "No rows found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            grdDataView.Rows.Add();
        }

        #endregion

        private void LoadSourceData()
        {
            openDialog.Filter = "Santander TEXT File|*.txt|Capital One CSV file|*.csv";
            //openDialog.ValidateNames = false;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtImportFile.Text = openDialog.FileName;
                //todo: why was this here? - this.Refresh();

                using (var lo_reader = new StreamReader(openDialog.FileName))
                {
                    switch (openDialog.FilterIndex)
                    {
                        case 1:
                            //todo: load on a separate thread and show progress
                            LoadDataFromSantander(lo_reader);
                            break;

                        case 2:
                            LoadDataFromCapitalOne(lo_reader);
                            break;

                        default:
                            throw new Exception("Unexpected filter index");
                    }
                }
            }
        }

        private void BuildGrid()
        {
            grdDataView.RowHeadersVisible = false;
            //todo: why doesn't this work?  - grdDataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            grdDataView.Rows.Clear();
            grdDataView.Columns.Clear();

            //todo: offload these to another thread
            var categs = GetTransCategCombo();
            var types = GetTransTypeCombo();

            foreach (var prop in typeof(Transaction).GetProperties())
            {
                switch (prop.Name)
                {
                    case "CategoryId":
                        grdDataView.Columns.Add(new DataGridViewComboBoxColumn()
                        {
                            Name = prop.Name,
                            HeaderText = "Category",
                            CellTemplate = categs
                        });
                        break;

                    case "TypeId":
                        grdDataView.Columns.Add(new DataGridViewComboBoxColumn()
                        {
                            Name = prop.Name,
                            HeaderText = "Type",
                            CellTemplate = types
                        });
                        break;

                    case "Account":
                    case "Category":
                    case "Type":
                        //Don't include the foreign keys
                        break;

                    default:
                        grdDataView.Columns.Add(prop.Name, prop.Name.TrimEnd("Id"));
                        //grdDataView.Columns[prop.Name].ReadOnly = true; 
                        break;
                }
                if (prop.Name == "Value" || prop.Name == "Balance")
                {
                    grdDataView.Columns[prop.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                //todo: why doesn't this work? - grdDataView.Columns[prop.Name].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdDataView.Columns["TransactionId"].Visible = false;
            grdDataView.Columns["AccountId"].Visible = false;

            grdDataView.Columns["TypeId"].DisplayIndex = 7;
            grdDataView.Columns["CategoryId"].DisplayIndex = 7;
        }

        private void LoadDataFromSantander(StreamReader reader)
        {
            //todo: move this logic to core

            //Read past the initial lines
            if (!reader.ReadLine().StartsWith("From:"))
            {
                MessageBox.Show("Failed to read past header line 1", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(reader.ReadLine()))
            {
                MessageBox.Show("Failed to read past header line 2", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!reader.ReadLine().StartsWith("Account:"))
            {
                MessageBox.Show("Failed to read past header line 3", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(reader.ReadLine()))
            {
                MessageBox.Show("Failed to read past header line 4", "Invalid File Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Read in the data
            string charToRemove = System.Text.Encoding.Unicode.GetString(new byte[] { 0xa0 });
            string lineText;
            bool newRow = true;
            var rowNum = -1;
            //object[] csvData = new object[8];
            do
            {
                if (newRow)
                {
                    newRow = false;
                    rowNum = grdDataView.Rows.Add();
                }

                lineText = reader.ReadLine()?.Replace(charToRemove, " ");

                if (string.IsNullOrWhiteSpace(lineText))
                {
                    newRow = true;
                    continue;
                }

                switch (lineText.Trim().Substring(0, 5))
                {
                    case "Date:":
                        grdDataView.Rows[rowNum].Cells["Date"].Value = Convert.ToDateTime(lineText.Substring(6));
                        break;
                    case "Descr":
                        grdDataView.Rows[rowNum].Cells["Description"].Value = lineText.Substring(13);
                        break;
                    case "Amoun":
                        grdDataView.Rows[rowNum].Cells["Value"].Value = decimal.Parse(lineText.Substring(8).Replace(" GBP", ""));
                        break;
                    case "Balan":
                        grdDataView.Rows[rowNum].Cells["Balance"].Value = decimal.Parse(lineText.Substring(9).Replace(" GBP", ""));
                        break;
                }

                //if (reader.EndOfStream)
                //{
                //    newRow = true;
                //}
            } while (reader.EndOfStream == false);

            //todo: remove when tested
            MessageBox.Show("Check the first and last transactions are present following the above commetned out code");

            grdDataView.Rows[0].Selected = true;
        }

        private void LoadDataFromCapitalOne(StreamReader reader)
        {
            using (var csv = new CsvReader(reader))
            {
                var rowNum = -1;
                var records = csv.GetRecords<Core.Models.CapitalOne.Transaction>();

                foreach (var record in records)
                {
                    rowNum = grdDataView.Rows.Add();
                    grdDataView.Rows[rowNum].Cells["Date"].Value = record.Date;
                    grdDataView.Rows[rowNum].Cells["Description"].Value = record.Description;
                    grdDataView.Rows[rowNum].Cells["Value"].Value = record.Amount;
                }
            }

            if (grdDataView.Rows.Count > 0)
            {
                grdDataView.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("No data to import");
            }
        }

        private void AutoAssignValues()
        {
            foreach (var autoAlloc in Controller.GetAutoAllocations())
            {
                for (int li_row = 0; li_row <= grdDataView.Rows.Count - 1; li_row++)
                {
                    var lo_cellValue = grdDataView.Rows[li_row].Cells[autoAlloc.GridColumnName].Value;
                    if (lo_cellValue != null && PatternMatch(lo_cellValue.ToString(), autoAlloc.GridDataPattern))
                    {
                        if (autoAlloc.UpdateColumnName == "CategoryId")
                        {
                            grdDataView.Rows[li_row].Cells["CategoryId"].Value = int.Parse(autoAlloc.UpdateDataValue);
                        }
                        else if (autoAlloc.UpdateColumnName == "TypeId")
                        {
                            grdDataView.Rows[li_row].Cells["TypeId"].Value = int.Parse(autoAlloc.UpdateDataValue);
                        }
                        else
                        {
                            grdDataView.Rows[li_row].Cells[autoAlloc.UpdateColumnName].Value = autoAlloc.UpdateDataValue;
                        }
                    }
                }
            }
        }

        private bool PatternMatch(string dataValue, string matchPattern)
        {
            dataValue = dataValue.ToLower();
            matchPattern = matchPattern.ToLower();
            string matchValue = matchPattern.Replace("*", "");
            if (!matchPattern.Contains("*"))
            {
                return dataValue.Equals(matchValue);
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

        private DataGridViewComboBoxCell GetTransTypeCombo()
        {
            var lo_return = new DataGridViewComboBoxCell();
            var list = new List<TransactionType>();
            list.Add(new TransactionType());
            list.AddRange(Controller.GetTransactionTypes());
            lo_return.DataSource = list;
            lo_return.DisplayMember = "Description";
            lo_return.ValueMember = "TypeId";
            return lo_return;
        }

        private DataGridViewComboBoxCell GetTransCategCombo()
        {
            var lo_return = new DataGridViewComboBoxCell();
            var list = new List<TransactionCategory>();
            list.Add(new TransactionCategory());
            list.AddRange(Controller.GetTransactionCategories().Where(c => !c.Obsolete).OrderBy(c => c.Description));
            lo_return.DataSource = list;
            lo_return.DisplayMember = "Description";
            lo_return.ValueMember = "CategoryId";
            return lo_return;
        }

        private bool WriteToDatabase()
        {
            var transData = new List<Transaction>();
            foreach (DataGridViewRow row in grdDataView.Rows)
            {
                int? transId = row.Cells["TransactionId"].Value != null ? int.Parse(row.Cells["TransactionId"].Value.ToString()) : (int?)null;
                int? categId = row.Cells["CategoryId"].Value != null ? int.Parse(row.Cells["CategoryId"].Value.ToString()) : (int?)null;
                if (transId == null)
                {
                    transData.Add(new Transaction
                    {
                        AccountId = this.AccountId,
                        CategoryId = categId,
                        TypeId = row.Cells["TypeId"].Value != null ? int.Parse(row.Cells["TypeId"].Value.ToString()) : (int?)null,
                        Date = DateTime.Parse(row.Cells["Date"].Value.ToString()),
                        Description = row.Cells["Description"].Value.ToString(),
                        Value = decimal.Parse(row.Cells["Value"].Value.ToString()),
                        Balance = row.Cells["Balance"].Value != null ? decimal.Parse(row.Cells["Balance"].Value.ToString()) : (decimal?)null
                    });
                }
                else
                {
                    //todo: why does this only update the category?
                    Controller.SetTransactionCategory((int)transId, categId);
                }
            }
            return Controller.WriteTransactions(transData);
        }

        private void LoadTransactionsNeedingAttention()
        {
            foreach (var trans in Controller.GetTransactionsNeedingAttention())
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["TransactionId"].Value = trans.TransactionId;
                grdDataView.Rows[rowNum].Cells["Date"].Value = trans.Date;
                grdDataView.Rows[rowNum].Cells["Description"].Value = trans.Description;
                grdDataView.Rows[rowNum].Cells["Value"].Value = trans.Value;
                grdDataView.Rows[rowNum].Cells["Balance"].Value = trans.Balance;
                grdDataView.Rows[rowNum].Cells["CategoryId"].Value = trans.CategoryId;
            }
        }

    } //End class
} //End namespace
