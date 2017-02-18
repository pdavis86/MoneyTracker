namespace MoneyTracker
{
    partial class MainForm
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
            this.btnImportTrans = new System.Windows.Forms.Button();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxTrans = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnImportSalary = new System.Windows.Forms.Button();
            this.lblMaxPaySlip = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImportTrans
            // 
            this.btnImportTrans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportTrans.Location = new System.Drawing.Point(75, 78);
            this.btnImportTrans.Name = "btnImportTrans";
            this.btnImportTrans.Size = new System.Drawing.Size(115, 23);
            this.btnImportTrans.TabIndex = 0;
            this.btnImportTrans.Text = "Import &Transactions";
            this.btnImportTrans.UseVisualStyleBackColor = true;
            this.btnImportTrans.Click += new System.EventHandler(this.btnImportTrans_Click);
            // 
            // cboAccounts
            // 
            this.cboAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(75, 18);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(281, 21);
            this.cboAccounts.TabIndex = 1;
            this.cboAccounts.ValueMemberChanged += new System.EventHandler(this.cboAccounts_ValueMemberChanged);
            this.cboAccounts.SelectedValueChanged += new System.EventHandler(this.cboAccounts_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account:";
            // 
            // lblMaxTrans
            // 
            this.lblMaxTrans.AutoSize = true;
            this.lblMaxTrans.Location = new System.Drawing.Point(165, 62);
            this.lblMaxTrans.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxTrans.Name = "lblMaxTrans";
            this.lblMaxTrans.Size = new System.Drawing.Size(65, 13);
            this.lblMaxTrans.TabIndex = 10;
            this.lblMaxTrans.Text = "dd/mm/yyyy";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(72, 62);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Max Transaction:";
            // 
            // btnImportSalary
            // 
            this.btnImportSalary.Location = new System.Drawing.Point(75, 145);
            this.btnImportSalary.Name = "btnImportSalary";
            this.btnImportSalary.Size = new System.Drawing.Size(115, 23);
            this.btnImportSalary.TabIndex = 11;
            this.btnImportSalary.Text = "Import &Pay Slip";
            this.btnImportSalary.UseVisualStyleBackColor = true;
            this.btnImportSalary.Click += new System.EventHandler(this.btnImportSalary_Click);
            // 
            // lblMaxPaySlip
            // 
            this.lblMaxPaySlip.AutoSize = true;
            this.lblMaxPaySlip.Location = new System.Drawing.Point(165, 129);
            this.lblMaxPaySlip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxPaySlip.Name = "lblMaxPaySlip";
            this.lblMaxPaySlip.Size = new System.Drawing.Size(65, 13);
            this.lblMaxPaySlip.TabIndex = 13;
            this.lblMaxPaySlip.Text = "dd/mm/yyyy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Max Pay Slip:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 189);
            this.Controls.Add(this.lblMaxPaySlip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnImportSalary);
            this.Controls.Add(this.lblMaxTrans);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAccounts);
            this.Controls.Add(this.btnImportTrans);
            this.Name = "MainForm";
            this.Text = "MoneyTracker";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportTrans;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblMaxTrans;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnImportSalary;
        internal System.Windows.Forms.Label lblMaxPaySlip;
        internal System.Windows.Forms.Label label4;
    }
}

