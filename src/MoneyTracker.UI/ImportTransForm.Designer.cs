namespace MoneyTracker
{
    partial class ImportTransForm
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
            this.grdDataView = new System.Windows.Forms.DataGridView();
            this.btnFindFile = new System.Windows.Forms.Button();
            this.txtImportFile = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDataView
            // 
            this.grdDataView.AllowUserToAddRows = false;
            this.grdDataView.AllowUserToOrderColumns = true;
            this.grdDataView.AllowUserToResizeRows = false;
            this.grdDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDataView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdDataView.Location = new System.Drawing.Point(12, 35);
            this.grdDataView.MultiSelect = false;
            this.grdDataView.Name = "grdDataView";
            this.grdDataView.RowTemplate.Height = 24;
            this.grdDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDataView.Size = new System.Drawing.Size(812, 376);
            this.grdDataView.TabIndex = 8;
            // 
            // btnFindFile
            // 
            this.btnFindFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindFile.Location = new System.Drawing.Point(800, 11);
            this.btnFindFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(25, 19);
            this.btnFindFile.TabIndex = 7;
            this.btnFindFile.Text = "...";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // txtImportFile
            // 
            this.txtImportFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFile.Location = new System.Drawing.Point(11, 11);
            this.txtImportFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.ReadOnly = true;
            this.txtImportFile.Size = new System.Drawing.Size(785, 20);
            this.txtImportFile.TabIndex = 6;
            this.txtImportFile.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(749, 417);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "&Save";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(12, 417);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(208, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "GetTransactionsNeedingAttention";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.cbLoad_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(226, 417);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 12;
            this.btnInsert.Text = "&New row";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // ImportTransForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 452);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grdDataView);
            this.Controls.Add(this.btnFindFile);
            this.Controls.Add(this.txtImportFile);
            this.Name = "ImportTransForm";
            this.Text = "Transactions";
            this.Shown += new System.EventHandler(this.ImportTransForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DataGridView grdDataView;
        internal System.Windows.Forms.Button btnFindFile;
        internal System.Windows.Forms.TextBox txtImportFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
    }
}