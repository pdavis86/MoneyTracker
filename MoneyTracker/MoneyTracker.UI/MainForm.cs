﻿using System;
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
            GetMaxDates();
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
            if (formLoaded)
            {
                lblMaxTrans.Text = Controller.GetMaxTransactionDate((int)cboAccounts.SelectedValue)?.ToString(Controller.DATEFORMAT_DISPLAY);
                lblMaxPaySlip.Text = Controller.GetMaxPaySlipDate()?.ToString(Controller.DATEFORMAT_DISPLAY);
            }
        }
    }
}