﻿using MoneyTracker.CustomControls;

namespace MoneyTracker
{
    partial class ImportPaySlipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmployers = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.decWorkingFromHome = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decHolidayPay = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decBackPay = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decNet = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decStudent = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decPension = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decNi = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decTax = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decUnpaid = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decBonus = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decOvertime = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decSsp = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.decBasic = new MoneyTracker.CustomControls.DecimalBoxControl();
            this.chkSsp = new System.Windows.Forms.CheckBox();
            this.chkOvertime = new System.Windows.Forms.CheckBox();
            this.chkBonus = new System.Windows.Forms.CheckBox();
            this.chkUnpaid = new System.Windows.Forms.CheckBox();
            this.chkBackPay = new System.Windows.Forms.CheckBox();
            this.chkHolidayPay = new System.Windows.Forms.CheckBox();
            this.chkWorkingFromHome = new System.Windows.Forms.CheckBox();
            this.chkStudent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Employer:";
            // 
            // cboEmployers
            // 
            this.cboEmployers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmployers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployers.FormattingEnabled = true;
            this.cboEmployers.Location = new System.Drawing.Point(118, 12);
            this.cboEmployers.Name = "cboEmployers";
            this.cboEmployers.Size = new System.Drawing.Size(449, 21);
            this.cboEmployers.TabIndex = 14;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(118, 39);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(449, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.Leave += new System.EventHandler(this.dtpDate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Basic:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ssp/Smp/Spp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Overtime:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Bonus:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Unpaid Pay:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tax:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "National Insurance:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Pension:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(331, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Student Loan:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Net:";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(492, 320);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Back-Pay:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Holiday Pay:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Working from home:";
            // 
            // decWorkingFromHome
            // 
            this.decWorkingFromHome.Location = new System.Drawing.Point(138, 267);
            this.decWorkingFromHome.Name = "decWorkingFromHome";
            this.decWorkingFromHome.Size = new System.Drawing.Size(100, 20);
            this.decWorkingFromHome.TabIndex = 8;
            this.decWorkingFromHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decHolidayPay
            // 
            this.decHolidayPay.Enabled = false;
            this.decHolidayPay.Location = new System.Drawing.Point(138, 241);
            this.decHolidayPay.Name = "decHolidayPay";
            this.decHolidayPay.Size = new System.Drawing.Size(100, 20);
            this.decHolidayPay.TabIndex = 7;
            this.decHolidayPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBackPay
            // 
            this.decBackPay.Enabled = false;
            this.decBackPay.Location = new System.Drawing.Point(138, 215);
            this.decBackPay.Name = "decBackPay";
            this.decBackPay.Size = new System.Drawing.Size(100, 20);
            this.decBackPay.TabIndex = 6;
            this.decBackPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decNet
            // 
            this.decNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decNet.Location = new System.Drawing.Point(386, 320);
            this.decNet.Name = "decNet";
            this.decNet.Size = new System.Drawing.Size(100, 20);
            this.decNet.TabIndex = 13;
            this.decNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.decNet.TextChanged += new System.EventHandler(this.decNet_TextChanged);
            // 
            // decStudent
            // 
            this.decStudent.Enabled = false;
            this.decStudent.Location = new System.Drawing.Point(437, 166);
            this.decStudent.Name = "decStudent";
            this.decStudent.Size = new System.Drawing.Size(100, 20);
            this.decStudent.TabIndex = 12;
            this.decStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decPension
            // 
            this.decPension.Location = new System.Drawing.Point(437, 140);
            this.decPension.Name = "decPension";
            this.decPension.Size = new System.Drawing.Size(100, 20);
            this.decPension.TabIndex = 11;
            this.decPension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decNi
            // 
            this.decNi.Location = new System.Drawing.Point(437, 114);
            this.decNi.Name = "decNi";
            this.decNi.Size = new System.Drawing.Size(100, 20);
            this.decNi.TabIndex = 10;
            this.decNi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decTax
            // 
            this.decTax.Location = new System.Drawing.Point(437, 88);
            this.decTax.Name = "decTax";
            this.decTax.Size = new System.Drawing.Size(100, 20);
            this.decTax.TabIndex = 9;
            this.decTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decUnpaid
            // 
            this.decUnpaid.Enabled = false;
            this.decUnpaid.Location = new System.Drawing.Point(138, 189);
            this.decUnpaid.Name = "decUnpaid";
            this.decUnpaid.Size = new System.Drawing.Size(100, 20);
            this.decUnpaid.TabIndex = 5;
            this.decUnpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBonus
            // 
            this.decBonus.Enabled = false;
            this.decBonus.Location = new System.Drawing.Point(138, 163);
            this.decBonus.Name = "decBonus";
            this.decBonus.Size = new System.Drawing.Size(100, 20);
            this.decBonus.TabIndex = 4;
            this.decBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decOvertime
            // 
            this.decOvertime.Enabled = false;
            this.decOvertime.Location = new System.Drawing.Point(138, 137);
            this.decOvertime.Name = "decOvertime";
            this.decOvertime.Size = new System.Drawing.Size(100, 20);
            this.decOvertime.TabIndex = 3;
            this.decOvertime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decSsp
            // 
            this.decSsp.Enabled = false;
            this.decSsp.Location = new System.Drawing.Point(138, 111);
            this.decSsp.Name = "decSsp";
            this.decSsp.Size = new System.Drawing.Size(100, 20);
            this.decSsp.TabIndex = 2;
            this.decSsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBasic
            // 
            this.decBasic.Location = new System.Drawing.Point(138, 85);
            this.decBasic.Name = "decBasic";
            this.decBasic.Size = new System.Drawing.Size(100, 20);
            this.decBasic.TabIndex = 1;
            this.decBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSsp
            // 
            this.chkSsp.AutoSize = true;
            this.chkSsp.Location = new System.Drawing.Point(12, 113);
            this.chkSsp.Name = "chkSsp";
            this.chkSsp.Size = new System.Drawing.Size(15, 14);
            this.chkSsp.TabIndex = 34;
            this.chkSsp.UseVisualStyleBackColor = true;
            this.chkSsp.CheckedChanged += new System.EventHandler(this.chkSsp_CheckedChanged);
            // 
            // chkOvertime
            // 
            this.chkOvertime.AutoSize = true;
            this.chkOvertime.Location = new System.Drawing.Point(11, 140);
            this.chkOvertime.Name = "chkOvertime";
            this.chkOvertime.Size = new System.Drawing.Size(15, 14);
            this.chkOvertime.TabIndex = 35;
            this.chkOvertime.UseVisualStyleBackColor = true;
            this.chkOvertime.CheckedChanged += new System.EventHandler(this.chkOvertime_CheckedChanged);
            // 
            // chkBonus
            // 
            this.chkBonus.AutoSize = true;
            this.chkBonus.Location = new System.Drawing.Point(11, 166);
            this.chkBonus.Name = "chkBonus";
            this.chkBonus.Size = new System.Drawing.Size(15, 14);
            this.chkBonus.TabIndex = 36;
            this.chkBonus.UseVisualStyleBackColor = true;
            this.chkBonus.CheckedChanged += new System.EventHandler(this.chkBonus_CheckedChanged);
            // 
            // chkUnpaid
            // 
            this.chkUnpaid.AutoSize = true;
            this.chkUnpaid.Location = new System.Drawing.Point(11, 192);
            this.chkUnpaid.Name = "chkUnpaid";
            this.chkUnpaid.Size = new System.Drawing.Size(15, 14);
            this.chkUnpaid.TabIndex = 37;
            this.chkUnpaid.UseVisualStyleBackColor = true;
            this.chkUnpaid.CheckedChanged += new System.EventHandler(this.chkUnpaid_CheckedChanged);
            // 
            // chkBackPay
            // 
            this.chkBackPay.AutoSize = true;
            this.chkBackPay.Location = new System.Drawing.Point(11, 218);
            this.chkBackPay.Name = "chkBackPay";
            this.chkBackPay.Size = new System.Drawing.Size(15, 14);
            this.chkBackPay.TabIndex = 38;
            this.chkBackPay.UseVisualStyleBackColor = true;
            this.chkBackPay.CheckedChanged += new System.EventHandler(this.chkBackPay_CheckedChanged);
            // 
            // chkHolidayPay
            // 
            this.chkHolidayPay.AutoSize = true;
            this.chkHolidayPay.Location = new System.Drawing.Point(11, 244);
            this.chkHolidayPay.Name = "chkHolidayPay";
            this.chkHolidayPay.Size = new System.Drawing.Size(15, 14);
            this.chkHolidayPay.TabIndex = 39;
            this.chkHolidayPay.UseVisualStyleBackColor = true;
            this.chkHolidayPay.CheckedChanged += new System.EventHandler(this.chkHolidayPay_CheckedChanged);
            // 
            // chkWorkingFromHome
            // 
            this.chkWorkingFromHome.AutoSize = true;
            this.chkWorkingFromHome.Checked = true;
            this.chkWorkingFromHome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWorkingFromHome.Location = new System.Drawing.Point(11, 270);
            this.chkWorkingFromHome.Name = "chkWorkingFromHome";
            this.chkWorkingFromHome.Size = new System.Drawing.Size(15, 14);
            this.chkWorkingFromHome.TabIndex = 40;
            this.chkWorkingFromHome.UseVisualStyleBackColor = true;
            this.chkWorkingFromHome.CheckedChanged += new System.EventHandler(this.chkWorkingFromHom_CheckedChanged);
            // 
            // chkStudent
            // 
            this.chkStudent.AutoSize = true;
            this.chkStudent.Location = new System.Drawing.Point(310, 169);
            this.chkStudent.Name = "chkStudent";
            this.chkStudent.Size = new System.Drawing.Size(15, 14);
            this.chkStudent.TabIndex = 41;
            this.chkStudent.UseVisualStyleBackColor = true;
            this.chkStudent.CheckedChanged += new System.EventHandler(this.chkStudent_CheckedChanged);
            // 
            // ImportPaySlipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 355);
            this.Controls.Add(this.chkStudent);
            this.Controls.Add(this.chkWorkingFromHome);
            this.Controls.Add(this.chkHolidayPay);
            this.Controls.Add(this.chkBackPay);
            this.Controls.Add(this.chkUnpaid);
            this.Controls.Add(this.chkBonus);
            this.Controls.Add(this.chkOvertime);
            this.Controls.Add(this.chkSsp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.decWorkingFromHome);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.decHolidayPay);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.decBackPay);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.decNet);
            this.Controls.Add(this.decStudent);
            this.Controls.Add(this.decPension);
            this.Controls.Add(this.decNi);
            this.Controls.Add(this.decTax);
            this.Controls.Add(this.decUnpaid);
            this.Controls.Add(this.decBonus);
            this.Controls.Add(this.decOvertime);
            this.Controls.Add(this.decSsp);
            this.Controls.Add(this.decBasic);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmployers);
            this.Name = "ImportPaySlipForm";
            this.Text = "ImportSalaryForm";
            this.Shown += new System.EventHandler(this.ImportPaySlipForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEmployers;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private DecimalBoxControl decBasic;
        private DecimalBoxControl decSsp;
        private DecimalBoxControl decOvertime;
        private DecimalBoxControl decBonus;
        private DecimalBoxControl decUnpaid;
        private DecimalBoxControl decTax;
        private DecimalBoxControl decNi;
        private DecimalBoxControl decPension;
        private DecimalBoxControl decStudent;
        private DecimalBoxControl decNet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label13;
        private DecimalBoxControl decBackPay;
        private DecimalBoxControl decHolidayPay;
        private System.Windows.Forms.Label label14;
        private DecimalBoxControl decWorkingFromHome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkSsp;
        private System.Windows.Forms.CheckBox chkOvertime;
        private System.Windows.Forms.CheckBox chkBonus;
        private System.Windows.Forms.CheckBox chkUnpaid;
        private System.Windows.Forms.CheckBox chkBackPay;
        private System.Windows.Forms.CheckBox chkHolidayPay;
        private System.Windows.Forms.CheckBox chkWorkingFromHome;
        private System.Windows.Forms.CheckBox chkStudent;
    }
}