using MoneyTracker.Core.Services;
using System;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportPaySlipForm : Form
    {
        private readonly DatabaseService _databaseService;

        public ImportPaySlipForm()
        {
            InitializeComponent();

            _databaseService = Core.Factories.DatabaseServiceFactory.GetNewDatabaseService();
        }

        private void ImportPaySlipForm_Shown(object sender, EventArgs e)
        {
            cboEmployers.DataSource = _databaseService.GetEmployers();
            cboEmployers.DisplayMember = "Description";
            cboEmployers.ValueMember = "EmployerId";
            cboEmployers.SelectedIndex = cboEmployers.Items.Count - 1;

            dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

            dtpDate.Focus();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (WriteToDatabase())
            {
                MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private bool WriteToDatabase()
        {
            var paySlip = new Data.Entities.PaySlip
            {
                EmployerId = (int)cboEmployers.SelectedValue,
                Date = dtpDate.Value,
                Basic = decBasic.ValueDecimal,
                SspSmpSpp = decSsp.Value,
                Overtime = decOvertime.Value,
                Bonus = decBonus.Value,
                UnpaidPay = decUnpaid.Value,
                BackPay = decBackPay.Value,
                HolidayPay = decHolidayPay.Value,
                Tax = decTax.ValueDecimal,
                NationalInsurance = decNi.ValueDecimal,
                Pension = decPension.Value,
                StudentLoan = decStudent.Value,
                Net = decNet.ValueDecimal
            };
            return _databaseService.WritePaySlip(paySlip);
        }

        private void decNet_TextChanged(object sender, EventArgs e)
        {
            //Validate on changing any of the text boxes
            ValidateInput();
        }

        private void ValidateInput()
        {
            decimal payments = decBasic.ValueDecimal + decSsp.ValueDecimal + decOvertime.ValueDecimal + decBonus.ValueDecimal + decUnpaid.ValueDecimal + decBackPay.ValueDecimal + decHolidayPay.ValueDecimal;
            decimal deductions = decTax.ValueDecimal + decNi.ValueDecimal + decPension.ValueDecimal + decStudent.ValueDecimal;
            decimal netCalcd = payments - deductions;
            btnImport.Enabled = decNet.Value == netCalcd;
        }

        private void dtpDate_Leave(object sender, EventArgs e)
        {
            if (dtpDate.Value.Date == DateTime.Today.Date)
            {
                switch (MessageBox.Show("The date has not been changed. is it correct?", "Date Not Changed", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        break;

                    case DialogResult.No:
                    case DialogResult.Cancel:
                        btnImport.Enabled = false;
                        dtpDate.Focus();
                        break;

                    default:
                        btnImport.Enabled = false;
                        return;
                }
            }
        }


    }
}
