using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using MoneyTracker.Core.Services;
using MoneyTracker.Data.Entities;

namespace MoneyTracker
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class CreateRuleForm : Form
    {
        private DatabaseService _databaseService;

        public CreateRuleForm(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;
        }

#pragma warning disable WFO1000 // Missing code serialization configuration for property content
        public Transaction TransactionData { get; internal set; }
#pragma warning restore WFO1000 // Missing code serialization configuration for property content

        private void CreateRuleForm_Shown(object sender, EventArgs e)
        {
            GridColumnNameText.Text = nameof(Transaction.Description);
            GridDataPatternText.Text = "*" + TransactionData.Description + "*";
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            UpdateDataValueText.Visible = false;

            UpdateDataValueCombo.Top = UpdateDataValueText.Top;
            UpdateDataValueCombo.Visible = true;

            var categories = _databaseService.GetTransactionCategories()?.Where(x => !x.Obsolete).ToList();
            var categoryList = new List<TransactionCategory>
            {
                new TransactionCategory()
            };
            if (categories != null)
            {
                categoryList.AddRange(categories.OrderBy(c => c.Description));
            }

            UpdateDataValueCombo.DataSource = categoryList;
            UpdateDataValueCombo.DisplayMember = nameof(TransactionCategory.Description);
            UpdateDataValueCombo.ValueMember = nameof(TransactionCategory.CategoryId);

            UpdateColumnNameText.Text = nameof(Transaction.CategoryId);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var autoAllocation = new AutoAllocation
            {
                GridColumnName = GridColumnNameText.Text,
                GridDataPattern = GridDataPatternText.Text,
                UpdateColumnName = UpdateColumnNameText.Text,
                UpdateDataValue = UpdateDataValueText.Text
            };

            if (_databaseService.WriteAutoAllocation(autoAllocation))
            {
                MessageBox.Show("Auto-allocation created", "New rule created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void UpdateDataValueCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateDataValueText.Text = UpdateDataValueCombo.SelectedValue?.ToString();
        }
    }
}
