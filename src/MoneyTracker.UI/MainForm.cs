using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;

using MoneyTracker.Core.Services;

namespace MoneyTracker
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class MainForm : Form
    {
        private readonly DatabaseService _databaseService;
        private bool _formLoaded;

        public MainForm(IConfiguration configuration)
        {
            InitializeComponent();

            _databaseService = new DatabaseService(configuration.GetConnectionString("MoneyTrackerDatabase"));
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var accounts = _databaseService.GetAccounts()?.Where(a => !a.Obsolete).ToList()
                ?? new List<Data.Entities.Account>();

            cboAccounts.DataSource = accounts;
            cboAccounts.DisplayMember = "Description";
            cboAccounts.ValueMember = "AccountId";

            GetMaxDates();

            _formLoaded = true;
        }

        private void cboAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_formLoaded)
            {
                GetMaxDates();
            }
        }

        private void btnImportTrans_Click(object sender, EventArgs e)
        {
            if (cboAccounts.SelectedValue == null)
            {
                return;
            }

            var form = new ImportTransForm(_databaseService)
            {
                AccountId = (int)cboAccounts.SelectedValue
            };
            form.ShowDialog(this);
            GetMaxDates();
        }

        private void btnImportSalary_Click(object sender, EventArgs e)
        {
            var form = new ImportPaySlipForm(_databaseService);
            form.ShowDialog(this);
            GetMaxDates();
        }

        private void GetMaxDates()
        {
            if (cboAccounts.SelectedValue == null)
            {
                return;
            }

            const string dateFormatForDisplay = "dd/MM/yyyy";
            lblMaxTrans.Text = _databaseService.GetMaxTransactionDate((int)cboAccounts.SelectedValue)?.ToString(dateFormatForDisplay);
            lblMaxPaySlip.Text = _databaseService.GetMaxPaySlipDate()?.ToString(dateFormatForDisplay);
        }
    }
}
