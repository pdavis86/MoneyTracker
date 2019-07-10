using System;
using System.Linq;
using System.Windows.Forms;

//todo: add a way to add/edit employers

namespace MoneyTracker
{
    public partial class MainForm : Form
    {
        private bool formLoaded;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cboAccounts.DataSource = Controller.GetAccounts().Where(a => !a.Obsolete).ToList();
            cboAccounts.DisplayMember = "Description";
            cboAccounts.ValueMember = "AccountId";

            GetMaxDates();

            formLoaded = true;
        }

        private void cboAccounts_ValueMemberChanged(object sender, EventArgs e)
        {
            //no good
        }

        private void cboAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                GetMaxDates();
            }
        }

        private void btnImportTrans_Click(object sender, EventArgs e)
        {
            var form = new ImportTransForm();
            form.AccountId = (int)cboAccounts.SelectedValue;
            form.ShowDialog(this);
            GetMaxDates();
        }

        private void btnImportSalary_Click(object sender, EventArgs e)
        {
            var form = new ImportPaySlipForm();
            form.ShowDialog(this);
            GetMaxDates();
        }

        private void GetMaxDates()
        {
            lblMaxTrans.Text = Controller.GetMaxTransactionDate((int)cboAccounts.SelectedValue)?.ToString(Controller.DATEFORMAT_DISPLAY);
            lblMaxPaySlip.Text = Controller.GetMaxPaySlipDate()?.ToString(Controller.DATEFORMAT_DISPLAY);
        }
    }
}
