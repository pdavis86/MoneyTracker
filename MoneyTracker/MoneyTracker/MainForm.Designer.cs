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
            this.btnImport = new System.Windows.Forms.Button();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxDate = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(199, 45);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "&Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cboAccounts
            // 
            this.cboAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(75, 18);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(199, 21);
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
            // lblMaxDate
            // 
            this.lblMaxDate.AutoSize = true;
            this.lblMaxDate.Location = new System.Drawing.Point(72, 50);
            this.lblMaxDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxDate.Name = "lblMaxDate";
            this.lblMaxDate.Size = new System.Drawing.Size(65, 13);
            this.lblMaxDate.TabIndex = 10;
            this.lblMaxDate.Text = "dd/mm/yyyy";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 50);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Max Date:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 87);
            this.Controls.Add(this.lblMaxDate);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAccounts);
            this.Controls.Add(this.btnImport);
            this.Name = "MainForm";
            this.Text = "MoneyTracker";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblMaxDate;
        internal System.Windows.Forms.Label Label2;
    }
}

