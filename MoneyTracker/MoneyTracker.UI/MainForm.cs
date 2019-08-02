using MoneyTracker.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MoneyTracker
{
    public partial class MainForm : Form
    {
        private readonly DatabaseService _databaseService;
        private bool _formLoaded;

        public MainForm()
        {
            InitializeComponent();

            _databaseService = Core.Factories.DatabaseServiceFactory.GetNewDatabaseService();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cboAccounts.DataSource = _databaseService.GetAccounts().Where(a => !a.Obsolete).ToList();
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
            var form = new ImportTransForm
            {
                AccountId = (int)cboAccounts.SelectedValue
            };
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
            const string dateFormatForDisplay = "dd/MM/yyyy";
            lblMaxTrans.Text = _databaseService.GetMaxTransactionDate((int)cboAccounts.SelectedValue)?.ToString(dateFormatForDisplay);
            lblMaxPaySlip.Text = _databaseService.GetMaxPaySlipDate()?.ToString(dateFormatForDisplay);
        }
    }
}
