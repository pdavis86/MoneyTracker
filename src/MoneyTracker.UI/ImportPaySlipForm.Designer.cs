using MoneyTracker.CustomControls;

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
            label1 = new System.Windows.Forms.Label();
            cboEmployers = new System.Windows.Forms.ComboBox();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            btnImport = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            decWorkingFromHome = new DecimalBoxControl();
            decHolidayPay = new DecimalBoxControl();
            decBackPay = new DecimalBoxControl();
            decNet = new DecimalBoxControl();
            decStudent = new DecimalBoxControl();
            decPension = new DecimalBoxControl();
            decNi = new DecimalBoxControl();
            decTax = new DecimalBoxControl();
            decUnpaid = new DecimalBoxControl();
            decBonus = new DecimalBoxControl();
            decOvertime = new DecimalBoxControl();
            decSsp = new DecimalBoxControl();
            decBasic = new DecimalBoxControl();
            chkSsp = new System.Windows.Forms.CheckBox();
            chkOvertime = new System.Windows.Forms.CheckBox();
            chkBonus = new System.Windows.Forms.CheckBox();
            chkUnpaid = new System.Windows.Forms.CheckBox();
            chkBackPay = new System.Windows.Forms.CheckBox();
            chkHolidayPay = new System.Windows.Forms.CheckBox();
            chkWorkingFromHome = new System.Windows.Forms.CheckBox();
            chkStudent = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 17);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Employer:";
            // 
            // cboEmployers
            // 
            cboEmployers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboEmployers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEmployers.FormattingEnabled = true;
            cboEmployers.Location = new System.Drawing.Point(138, 14);
            cboEmployers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cboEmployers.Name = "cboEmployers";
            cboEmployers.Size = new System.Drawing.Size(523, 23);
            cboEmployers.TabIndex = 14;
            // 
            // dtpDate
            // 
            dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDate.CustomFormat = "yyyy-MM-dd";
            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDate.Location = new System.Drawing.Point(138, 45);
            dtpDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(523, 23);
            dtpDate.TabIndex = 0;
            dtpDate.Leave += dtpDate_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 52);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 16;
            label2.Text = "Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(37, 102);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 15);
            label3.TabIndex = 17;
            label3.Text = "Basic:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(37, 132);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 15);
            label4.TabIndex = 18;
            label4.Text = "Ssp/Smp/Spp:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(37, 162);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 15);
            label5.TabIndex = 19;
            label5.Text = "Overtime:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(37, 192);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 15);
            label6.TabIndex = 20;
            label6.Text = "Bonus:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(37, 222);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(70, 15);
            label7.TabIndex = 21;
            label7.Text = "Unpaid Pay:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(386, 105);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(27, 15);
            label8.TabIndex = 22;
            label8.Text = "Tax:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(386, 135);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(109, 15);
            label9.TabIndex = 23;
            label9.Text = "National Insurance:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(386, 165);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(52, 15);
            label10.TabIndex = 24;
            label10.Text = "Pension:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(386, 195);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(80, 15);
            label11.TabIndex = 25;
            label11.Text = "Student Loan:";
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(412, 373);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(29, 15);
            label12.TabIndex = 26;
            label12.Text = "Net:";
            // 
            // btnImport
            // 
            btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnImport.Enabled = false;
            btnImport.Location = new System.Drawing.Point(574, 369);
            btnImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new System.Drawing.Size(88, 27);
            btnImport.TabIndex = 14;
            btnImport.Text = "&Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(37, 252);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(59, 15);
            label13.TabIndex = 29;
            label13.Text = "Back-Pay:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(37, 282);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(73, 15);
            label14.TabIndex = 31;
            label14.Text = "Holiday Pay:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(37, 312);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(118, 15);
            label15.TabIndex = 33;
            label15.Text = "Working from home:";
            // 
            // decWorkingFromHome
            // 
            decWorkingFromHome.Enabled = false;
            decWorkingFromHome.Location = new System.Drawing.Point(161, 308);
            decWorkingFromHome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decWorkingFromHome.Name = "decWorkingFromHome";
            decWorkingFromHome.Size = new System.Drawing.Size(116, 23);
            decWorkingFromHome.TabIndex = 8;
            decWorkingFromHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decHolidayPay
            // 
            decHolidayPay.Enabled = false;
            decHolidayPay.Location = new System.Drawing.Point(161, 278);
            decHolidayPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decHolidayPay.Name = "decHolidayPay";
            decHolidayPay.Size = new System.Drawing.Size(116, 23);
            decHolidayPay.TabIndex = 7;
            decHolidayPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBackPay
            // 
            decBackPay.Enabled = false;
            decBackPay.Location = new System.Drawing.Point(161, 248);
            decBackPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decBackPay.Name = "decBackPay";
            decBackPay.Size = new System.Drawing.Size(116, 23);
            decBackPay.TabIndex = 6;
            decBackPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decNet
            // 
            decNet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            decNet.Location = new System.Drawing.Point(450, 369);
            decNet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decNet.Name = "decNet";
            decNet.Size = new System.Drawing.Size(116, 23);
            decNet.TabIndex = 13;
            decNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            decNet.TextChanged += decNet_TextChanged;
            // 
            // decStudent
            // 
            decStudent.Enabled = false;
            decStudent.Location = new System.Drawing.Point(510, 192);
            decStudent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decStudent.Name = "decStudent";
            decStudent.Size = new System.Drawing.Size(116, 23);
            decStudent.TabIndex = 12;
            decStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decPension
            // 
            decPension.Location = new System.Drawing.Point(510, 162);
            decPension.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decPension.Name = "decPension";
            decPension.Size = new System.Drawing.Size(116, 23);
            decPension.TabIndex = 11;
            decPension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decNi
            // 
            decNi.Location = new System.Drawing.Point(510, 132);
            decNi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decNi.Name = "decNi";
            decNi.Size = new System.Drawing.Size(116, 23);
            decNi.TabIndex = 10;
            decNi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decTax
            // 
            decTax.Location = new System.Drawing.Point(510, 102);
            decTax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decTax.Name = "decTax";
            decTax.Size = new System.Drawing.Size(116, 23);
            decTax.TabIndex = 9;
            decTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decUnpaid
            // 
            decUnpaid.Enabled = false;
            decUnpaid.Location = new System.Drawing.Point(161, 218);
            decUnpaid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decUnpaid.Name = "decUnpaid";
            decUnpaid.Size = new System.Drawing.Size(116, 23);
            decUnpaid.TabIndex = 5;
            decUnpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBonus
            // 
            decBonus.Enabled = false;
            decBonus.Location = new System.Drawing.Point(161, 188);
            decBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decBonus.Name = "decBonus";
            decBonus.Size = new System.Drawing.Size(116, 23);
            decBonus.TabIndex = 4;
            decBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decOvertime
            // 
            decOvertime.Enabled = false;
            decOvertime.Location = new System.Drawing.Point(161, 158);
            decOvertime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decOvertime.Name = "decOvertime";
            decOvertime.Size = new System.Drawing.Size(116, 23);
            decOvertime.TabIndex = 3;
            decOvertime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decSsp
            // 
            decSsp.Enabled = false;
            decSsp.Location = new System.Drawing.Point(161, 128);
            decSsp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decSsp.Name = "decSsp";
            decSsp.Size = new System.Drawing.Size(116, 23);
            decSsp.TabIndex = 2;
            decSsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decBasic
            // 
            decBasic.Location = new System.Drawing.Point(161, 98);
            decBasic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            decBasic.Name = "decBasic";
            decBasic.Size = new System.Drawing.Size(116, 23);
            decBasic.TabIndex = 1;
            decBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSsp
            // 
            chkSsp.AutoSize = true;
            chkSsp.Location = new System.Drawing.Point(14, 130);
            chkSsp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkSsp.Name = "chkSsp";
            chkSsp.Size = new System.Drawing.Size(15, 14);
            chkSsp.TabIndex = 34;
            chkSsp.UseVisualStyleBackColor = true;
            chkSsp.CheckedChanged += chkSsp_CheckedChanged;
            // 
            // chkOvertime
            // 
            chkOvertime.AutoSize = true;
            chkOvertime.Location = new System.Drawing.Point(13, 162);
            chkOvertime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOvertime.Name = "chkOvertime";
            chkOvertime.Size = new System.Drawing.Size(15, 14);
            chkOvertime.TabIndex = 35;
            chkOvertime.UseVisualStyleBackColor = true;
            chkOvertime.CheckedChanged += chkOvertime_CheckedChanged;
            // 
            // chkBonus
            // 
            chkBonus.AutoSize = true;
            chkBonus.Location = new System.Drawing.Point(13, 192);
            chkBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBonus.Name = "chkBonus";
            chkBonus.Size = new System.Drawing.Size(15, 14);
            chkBonus.TabIndex = 36;
            chkBonus.UseVisualStyleBackColor = true;
            chkBonus.CheckedChanged += chkBonus_CheckedChanged;
            // 
            // chkUnpaid
            // 
            chkUnpaid.AutoSize = true;
            chkUnpaid.Location = new System.Drawing.Point(13, 222);
            chkUnpaid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkUnpaid.Name = "chkUnpaid";
            chkUnpaid.Size = new System.Drawing.Size(15, 14);
            chkUnpaid.TabIndex = 37;
            chkUnpaid.UseVisualStyleBackColor = true;
            chkUnpaid.CheckedChanged += chkUnpaid_CheckedChanged;
            // 
            // chkBackPay
            // 
            chkBackPay.AutoSize = true;
            chkBackPay.Location = new System.Drawing.Point(13, 252);
            chkBackPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBackPay.Name = "chkBackPay";
            chkBackPay.Size = new System.Drawing.Size(15, 14);
            chkBackPay.TabIndex = 38;
            chkBackPay.UseVisualStyleBackColor = true;
            chkBackPay.CheckedChanged += chkBackPay_CheckedChanged;
            // 
            // chkHolidayPay
            // 
            chkHolidayPay.AutoSize = true;
            chkHolidayPay.Location = new System.Drawing.Point(13, 282);
            chkHolidayPay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkHolidayPay.Name = "chkHolidayPay";
            chkHolidayPay.Size = new System.Drawing.Size(15, 14);
            chkHolidayPay.TabIndex = 39;
            chkHolidayPay.UseVisualStyleBackColor = true;
            chkHolidayPay.CheckedChanged += chkHolidayPay_CheckedChanged;
            // 
            // chkWorkingFromHome
            // 
            chkWorkingFromHome.AutoSize = true;
            chkWorkingFromHome.Location = new System.Drawing.Point(13, 312);
            chkWorkingFromHome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkWorkingFromHome.Name = "chkWorkingFromHome";
            chkWorkingFromHome.Size = new System.Drawing.Size(15, 14);
            chkWorkingFromHome.TabIndex = 40;
            chkWorkingFromHome.UseVisualStyleBackColor = true;
            chkWorkingFromHome.CheckedChanged += chkWorkingFromHom_CheckedChanged;
            // 
            // chkStudent
            // 
            chkStudent.AutoSize = true;
            chkStudent.Location = new System.Drawing.Point(362, 195);
            chkStudent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkStudent.Name = "chkStudent";
            chkStudent.Size = new System.Drawing.Size(15, 14);
            chkStudent.TabIndex = 41;
            chkStudent.UseVisualStyleBackColor = true;
            chkStudent.CheckedChanged += chkStudent_CheckedChanged;
            // 
            // ImportPaySlipForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(676, 410);
            Controls.Add(chkStudent);
            Controls.Add(chkWorkingFromHome);
            Controls.Add(chkHolidayPay);
            Controls.Add(chkBackPay);
            Controls.Add(chkUnpaid);
            Controls.Add(chkBonus);
            Controls.Add(chkOvertime);
            Controls.Add(chkSsp);
            Controls.Add(label15);
            Controls.Add(decWorkingFromHome);
            Controls.Add(label14);
            Controls.Add(decHolidayPay);
            Controls.Add(label13);
            Controls.Add(decBackPay);
            Controls.Add(btnImport);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(decNet);
            Controls.Add(decStudent);
            Controls.Add(decPension);
            Controls.Add(decNi);
            Controls.Add(decTax);
            Controls.Add(decUnpaid);
            Controls.Add(decBonus);
            Controls.Add(decOvertime);
            Controls.Add(decSsp);
            Controls.Add(decBasic);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Controls.Add(cboEmployers);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ImportPaySlipForm";
            Text = "ImportSalaryForm";
            Shown += ImportPaySlipForm_Shown;
            ResumeLayout(false);
            PerformLayout();

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