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
    public partial class MainForm : Form
    {
        private bool formLoaded;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var importForm = new ImportForm();
            importForm.AccountId = (int)cboAccounts.SelectedValue;
            importForm.ShowDialog(this);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cboAccounts.DataSource = Controller.GetAccounts();
            cboAccounts.DisplayMember = "Description";
            cboAccounts.ValueMember = "AccountId";

            formLoaded = true;
            cboAccounts.SelectedIndex = cboAccounts.Items.Count - 1;
        }

        private void cboAccounts_ValueMemberChanged(object sender, EventArgs e)
        {
            //no good
        }

        private void cboAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                int accountId;
                //if (cboAccounts.SelectedValue.GetType() == typeof(MoneyTrackerDataModel.Entities.Account))
                //{
                //    accountId = (int)((MoneyTrackerDataModel.Entities.Account)cboAccounts.SelectedValue).AccountId;
                //}
                //else
                //{
                accountId = (int)cboAccounts.SelectedValue;
                //}
                lblMaxDate.Text = Controller.GetMaxTransactionDate(accountId)?.ToString(Controller.DATEFORMAT_DISPLAY);
            }
        }
    }
}
