using MoneyTracker.Core.Extensions;
using MoneyTracker.Core.Services;
using MoneyTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportTransForm : Form
    {
        private readonly OpenFileDialog _openDialog;
        private readonly DatabaseService _databaseService;

        private List<TransactionCategory> _categories;

        public int AccountId { private get; set; }

        public ImportTransForm(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;

            _openDialog = new OpenFileDialog();
        }

        #region Event Handlers

        private void ImportTransForm_Shown(object sender, EventArgs e)
        {
            BuildGrid();
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            grdDataView.Rows.Clear();

            //todo: deal with exceptions
            try
            {
                LoadSourceData();
                AutoAssignValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, something went wrong", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex);
                Debugger.Break();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //todo: deal with exceptions
            try
            {
                if (WriteToDatabase())
                {
                    MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, something went wrong", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex);
                Debugger.Break();
            }
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
            //todo: get this mapping from somewhere
            switch (AccountId)
            {
                case 7:
                    _openDialog.Filter = "Capital One CSV file|*.csv";
                    break;

                case 8:
                case 11:
                    _openDialog.Filter = "Starling Bank CSV file|*.csv";
                    break;

                case 9:
                    _openDialog.Filter = "First Direct CSV file|*.csv";
                    break;

                case 10:
                    _openDialog.Filter = "AMEX CSV file|*.csv";
                    break;

                case 12:
                    _openDialog.Filter = "Virgin Credit Card CSV file|*.csv";
                    break;
            }

            if (_openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtImportFile.Text = _openDialog.FileName;

            //todo: check the mapping to see which method to use
            switch (AccountId)
            {
                case 7:
                    LoadDataFromCapitalOne(_openDialog.FileName);
                    break;

                case 8:
                case 11:
                    LoadDataFromStarlingBank(_openDialog.FileName);
                    break;

                case 9:
                    LoadDataFromFirstDirect(_openDialog.FileName);
                    break;

                case 10:
                    LoadDataFromAmex(_openDialog.FileName);
                    break;

                case 12:
                    LoadDataFromVirginCreditCard(_openDialog.FileName);
                    break;

                default:
                    throw new Exception("Unexpected filter index");
            }

            if (grdDataView.Rows.Count == 0)
            {
                MessageBox.Show("No data to import", "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grdDataView.Rows[0].Selected = true;
        }

        private void LoadDataFromCapitalOne(string filePath)
        {
            IEnumerable<Core.Models.CapitalOneTransaction> transactions = null;
            Task.Run(() => transactions = Core.Helpers.ParseHelper.LoadData<Core.Models.CapitalOneTransaction>(filePath)).Wait();
            foreach (var record in transactions)
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["Date"].Value = record.Date;
                grdDataView.Rows[rowNum].Cells["Description"].Value = record.Description;
                grdDataView.Rows[rowNum].Cells["Value"].Value = record.DebitCreditCode == Core.Models.CapitalOneTransaction.DebitCreditCodes.Debit ? record.Amount * -1 : record.Amount;
            }
        }

        private void LoadDataFromStarlingBank(string filePath)
        {
            IEnumerable<Core.Models.StarlingTransaction> transactions = null;
            Task.Run(() => transactions = Core.Helpers.ParseHelper.LoadData<Core.Models.StarlingTransaction>(filePath)).Wait();
            foreach (var record in transactions)
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["Date"].Value = record.Date;
                grdDataView.Rows[rowNum].Cells["Description"].Value = record.GetDesc();
                grdDataView.Rows[rowNum].Cells["Value"].Value = record.Amount;
                grdDataView.Rows[rowNum].Cells["Balance"].Value = record.Balance;
                GetCategoryFromStarlingBank(rowNum, record);
            }
        }

        private void LoadDataFromVirginCreditCard(string filePath)
        {
            IEnumerable<Core.Models.VirginTransaction> transactions = null;
            Task.Run(() => transactions = Core.Helpers.ParseHelper.LoadData<Core.Models.VirginTransaction>(filePath)).Wait();
            foreach (var record in transactions)
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["Date"].Value = record.TransactionDate;
                grdDataView.Rows[rowNum].Cells["Description"].Value = record.Merchant;
                grdDataView.Rows[rowNum].Cells["Value"].Value = record.DebitOrCredit == Core.Models.VirginTransaction.DebitCreditCodes.Debit ? record.Amount * -1 : record.Amount;
            }
        }

        private void GetCategoryFromStarlingBank(int rowNum, Core.Models.StarlingTransaction record)
        {
            string searchStr;

            switch (record.SpendingCategory)
            {
                //Misleading - case "BILLS_AND_SERVICES": searchStr = "bills"; break;
                case "EATING_OUT": searchStr = "eating out"; break;
                case "ENTERTAINMENT": searchStr = "entertainment"; break;
                case "GENERAL": searchStr = "all other"; break;
                case "GROCERIES": searchStr = "supermarket"; break;
                case "HOME": searchStr = "diy"; break;
                case "INCOME": searchStr = "internal transfer"; break;
                //case "LIFESTYLE":
                //Misleading - case "PAYMENTS": searchStr = "loan payment"; break;
                case "PETS": searchStr = "pets"; break;
                case "SHOPPING": searchStr = "high street"; break;
                default: return;
            }

            var match = _categories.FirstOrDefault(x => x.Description.ToLower().Contains(searchStr));

            if (match == null)
            {
                return;
            }

            grdDataView.Rows[rowNum].Cells["CategoryId"].Value = match.CategoryId;
        }

        private void LoadDataFromFirstDirect(string filePath)
        {
            IEnumerable<Core.Models.FirstDirectTransaction> transactions = null;
            Task.Run(() => transactions = Core.Helpers.ParseHelper.LoadData<Core.Models.FirstDirectTransaction>(filePath)).Wait();
            foreach (var record in transactions.Reverse())
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["Date"].Value = record.Date;
                grdDataView.Rows[rowNum].Cells["Description"].Value = record.Description;
                grdDataView.Rows[rowNum].Cells["Value"].Value = record.Amount;
                grdDataView.Rows[rowNum].Cells["Balance"].Value = record.Balance;
            }
        }

        private void LoadDataFromAmex(string filePath)
        {
            IEnumerable<Core.Models.AmexTransaction> transactions = null;
            Task.Run(() => transactions = Core.Helpers.ParseHelper.LoadData<Core.Models.AmexTransaction>(filePath)).Wait();
            foreach (var record in transactions.Reverse())
            {
                var rowNum = grdDataView.Rows.Add();
                grdDataView.Rows[rowNum].Cells["Date"].Value = record.Date;
                grdDataView.Rows[rowNum].Cells["Description"].Value = record.Description;
                grdDataView.Rows[rowNum].Cells["Value"].Value = record.Amount * -1;
            }
        }

        private void BuildGrid()
        {
            grdDataView.RowHeadersVisible = false;
            //todo: why doesn't this work?  - grdDataView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            grdDataView.Rows.Clear();
            grdDataView.Columns.Clear();

            DataGridViewComboBoxCell categs = null;
            DataGridViewComboBoxCell types = null;
            Task.WaitAll(
                Task.Run(() => categs = GetTransactionCategoryCombo()),
                Task.Run(() => types = GetTransTypeCombo())
                );

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
                if (grdDataView.Columns[prop.Name] != null)
                {
                    if (prop.Name == "Value" || prop.Name == "Balance")
                    {
                        grdDataView.Columns[prop.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (prop.Name == "TransactionId" || prop.Name == "AccountId")
                    {
                        grdDataView.Columns[prop.Name].Visible = false;
                    }
                }
                //todo: why doesn't this work? - grdDataView.Columns[prop.Name].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //grdDataView.Columns["TransactionId"].Visible = false;
            //grdDataView.Columns["AccountId"].Visible = false;

            if (grdDataView.Columns["TypeId"] != null)
            {
                grdDataView.Columns["TypeId"].DisplayIndex = 7;
            }
            if (grdDataView.Columns["CategoryId"] != null)
            {
                grdDataView.Columns["CategoryId"].DisplayIndex = 7;
            }
        }

        private void AutoAssignValues()
        {
            foreach (var autoAlloc in _databaseService.GetAutoAllocations())
            {
                for (int row = 0; row <= grdDataView.Rows.Count - 1; row++)
                {
                    var cellValue = grdDataView.Rows[row].Cells[autoAlloc.GridColumnName].Value;
                    if (cellValue != null && PatternMatch(cellValue.ToString(), autoAlloc.GridDataPattern))
                    {
                        if (autoAlloc.UpdateColumnName == "CategoryId")
                        {
                            grdDataView.Rows[row].Cells["CategoryId"].Value = int.Parse(autoAlloc.UpdateDataValue);
                        }
                        else if (autoAlloc.UpdateColumnName == "TypeId")
                        {
                            grdDataView.Rows[row].Cells["TypeId"].Value = int.Parse(autoAlloc.UpdateDataValue);
                        }
                        else
                        {
                            grdDataView.Rows[row].Cells[autoAlloc.UpdateColumnName].Value = autoAlloc.UpdateDataValue;
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

        private DataGridViewComboBoxCell GetTransTypeCombo()
        {
            var list = new List<TransactionType>
            {
                new TransactionType()
            };
            list.AddRange(_databaseService.GetTransactionTypes());
            return new DataGridViewComboBoxCell
            {
                DataSource = list,
                DisplayMember = "Description",
                ValueMember = "TypeId"
            };
        }

        private DataGridViewComboBoxCell GetTransactionCategoryCombo()
        {
            var list = new List<TransactionCategory>
            {
                new TransactionCategory()
            };

            _categories = _databaseService.GetTransactionCategories().Where(c => !c.Obsolete).ToList();

            list.AddRange(_categories.OrderBy(c => c.Description));

            return new DataGridViewComboBoxCell
            {
                DataSource = list,
                DisplayMember = "Description",
                ValueMember = "CategoryId"
            };
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
                        AccountId = AccountId,
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
                    if (!_databaseService.SetTransactionCategory((int)transId, categId))
                    {
                        MessageBox.Show("Failed to set transaction category", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return _databaseService.WriteTransactions(transData);
        }

        private void LoadTransactionsNeedingAttention()
        {
            foreach (var trans in _databaseService.GetTransactionsNeedingAttention())
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

    }
}
