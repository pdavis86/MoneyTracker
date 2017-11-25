using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class ImportPaySlipForm : Form
    {
        public ImportPaySlipForm()
        {
            InitializeComponent();
        }

        private void ImportPaySlipForm_Shown(object sender, EventArgs e)
        {
            cboEmployers.DataSource = Controller.GetEmployers();
            cboEmployers.DisplayMember = "Description";
            cboEmployers.ValueMember = "EmployerId";
            cboEmployers.SelectedIndex = cboEmployers.Items.Count - 1;
            dtpDate.Focus();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (WriteToDatabase())
            {
                MessageBox.Show("Data Imported", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool WriteToDatabase()
        {
            var paySlip = new MoneyTrackerDataModel.Entities.PaySlip
            {
                EmployerId = (int)cboEmployers.SelectedValue,
                Date = dtpDate.Value,
                Basic = decBasic.ValueDecimal,
                SspSmpSpp = decSsp.Value,
                Overtime = decOvertime.Value,
                Bonus = decBonus.Value,
                UnpaidPay = decUnpaid.Value,
                //todo: BackPay = decBackPay.Value,
                Tax = decTax.ValueDecimal,
                NationalInsurance = decNi.ValueDecimal,
                Pension = decPension.Value,
                StudentLoan = decStudent.Value,
                Net = decNet.ValueDecimal
            };
            return Controller.WritePaySlip(paySlip);
        }

        private void decNet_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void ValidateInput()
        {
            if (dtpDate.Value.Date == DateTime.Today.Date)
            {
                switch (MessageBox.Show("The date has not been changed. is it correct?", "Date Not Changed", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        //continue
                        break;
                    default:
                        btnImport.Enabled = false;
                        return;
                }
            }

            decimal payments = decBasic.ValueDecimal + decSsp.ValueDecimal + decOvertime.ValueDecimal + decBonus.ValueDecimal + decUnpaid.ValueDecimal + decBackPay.ValueDecimal;
            decimal deductions = decTax.ValueDecimal + decNi.ValueDecimal + decPension.ValueDecimal + decStudent.ValueDecimal;
            decimal netCalcd = payments - deductions;
            btnImport.Enabled = decNet.Value == netCalcd;
        }
    }
}
