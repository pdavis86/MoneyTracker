using MoneyTracker.Core.Services;
using MoneyTracker.Data.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportPaySlipForm : Form
    {
        private readonly DatabaseService _databaseService;

        public ImportPaySlipForm(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;
        }

        private void ImportPaySlipForm_Shown(object sender, EventArgs e)
        {
            cboEmployers.DataSource = _databaseService.GetEmployers().Where(x => !x.Obsolete).ToList();
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
            var paySlip = BuildPaySlipEntity();

            if (!IsInputValid(paySlip))
            {
                MessageBox.Show("Check the data", "Something is wrong with the data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return _databaseService.WritePaySlip(paySlip);
        }

        private PaySlip BuildPaySlipEntity()
        {
            return new PaySlip
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
                WorkingFromHome = decWorkingFromHome.Value,
                Tax = decTax.ValueDecimal,
                NationalInsurance = decNi.ValueDecimal,
                Pension = decPension.Value,
                StudentLoan = decStudent.Value,
                Net = decNet.ValueDecimal
            };
        }

        private void decNet_TextChanged(object sender, EventArgs e)
        {
            btnImport.Enabled = IsInputValid(BuildPaySlipEntity());
        }

        private bool IsInputValid(PaySlip paySlip)
        {
            var payments = paySlip.Basic
                + (paySlip.SspSmpSpp ?? 0)
                + (paySlip.Overtime ?? 0)
                + (paySlip.Bonus ?? 0)
                + (paySlip.UnpaidPay ?? 0)
                + (paySlip.BackPay ?? 0)
                + (paySlip.HolidayPay ?? 0)
                + (paySlip.WorkingFromHome ?? 0);

            var deductions = paySlip.Tax
                + paySlip.NationalInsurance
                + paySlip.Pension
                + (paySlip.StudentLoan ?? 0);

            var netCalcd = payments - deductions;

            return decNet.Value == netCalcd;
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

        private void chkSsp_CheckedChanged(object sender, EventArgs e)
        {
            decSsp.Enabled = chkSsp.Checked;
        }

        private void chkOvertime_CheckedChanged(object sender, EventArgs e)
        {
            decOvertime.Enabled = chkOvertime.Checked;
        }

        private void chkBonus_CheckedChanged(object sender, EventArgs e)
        {
            decBonus.Enabled = chkBonus.Checked;
        }

        private void chkUnpaid_CheckedChanged(object sender, EventArgs e)
        {
            decUnpaid.Enabled = chkUnpaid.Checked;
        }

        private void chkBackPay_CheckedChanged(object sender, EventArgs e)
        {
            decBackPay.Enabled = chkBackPay.Checked;
        }

        private void chkHolidayPay_CheckedChanged(object sender, EventArgs e)
        {
            decHolidayPay.Enabled = chkHolidayPay.Checked;
        }

        private void chkWorkingFromHom_CheckedChanged(object sender, EventArgs e)
        {
            decWorkingFromHome.Enabled = chkWorkingFromHome.Checked;
        }

        private void chkStudent_CheckedChanged(object sender, EventArgs e)
        {
            decStudent.Enabled = chkStudent.Checked;
        }
    }
}
