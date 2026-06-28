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
            grdDataView = new System.Windows.Forms.DataGridView();
            btnFindFile = new System.Windows.Forms.Button();
            txtImportFile = new System.Windows.Forms.TextBox();
            btnImport = new System.Windows.Forms.Button();
            btnLoad = new System.Windows.Forms.Button();
            btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)grdDataView).BeginInit();
            SuspendLayout();
            // 
            // grdDataView
            // 
            grdDataView.AllowUserToAddRows = false;
            grdDataView.AllowUserToOrderColumns = true;
            grdDataView.AllowUserToResizeRows = false;
            grdDataView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grdDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grdDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdDataView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            grdDataView.Location = new System.Drawing.Point(14, 40);
            grdDataView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            grdDataView.MultiSelect = false;
            grdDataView.Name = "grdDataView";
            grdDataView.RowTemplate.Height = 24;
            grdDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grdDataView.Size = new System.Drawing.Size(947, 434);
            grdDataView.TabIndex = 8;
            grdDataView.CellClick += grdDataView_CellClick;
            grdDataView.DataError += grdDataView_DataError;
            // 
            // btnFindFile
            // 
            btnFindFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFindFile.Location = new System.Drawing.Point(933, 13);
            btnFindFile.Margin = new System.Windows.Forms.Padding(2);
            btnFindFile.Name = "btnFindFile";
            btnFindFile.Size = new System.Drawing.Size(29, 22);
            btnFindFile.TabIndex = 7;
            btnFindFile.Text = "...";
            btnFindFile.UseVisualStyleBackColor = true;
            btnFindFile.Click += btnFindFile_Click;
            // 
            // txtImportFile
            // 
            txtImportFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtImportFile.Location = new System.Drawing.Point(13, 13);
            txtImportFile.Margin = new System.Windows.Forms.Padding(2);
            txtImportFile.Name = "txtImportFile";
            txtImportFile.ReadOnly = true;
            txtImportFile.Size = new System.Drawing.Size(915, 23);
            txtImportFile.TabIndex = 6;
            txtImportFile.TabStop = false;
            // 
            // btnImport
            // 
            btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnImport.Location = new System.Drawing.Point(874, 481);
            btnImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new System.Drawing.Size(88, 27);
            btnImport.TabIndex = 9;
            btnImport.Text = "&Save";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnLoad.Location = new System.Drawing.Point(14, 481);
            btnLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(243, 27);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "GetTransactionsNeedingAttention";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += cbLoad_Click;
            // 
            // btnInsert
            // 
            btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnInsert.Location = new System.Drawing.Point(264, 481);
            btnInsert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new System.Drawing.Size(88, 27);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "&New row";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // ImportTransForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(975, 522);
            Controls.Add(btnInsert);
            Controls.Add(btnLoad);
            Controls.Add(btnImport);
            Controls.Add(grdDataView);
            Controls.Add(btnFindFile);
            Controls.Add(txtImportFile);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ImportTransForm";
            Text = "Transactions";
            Shown += ImportTransForm_Shown;
            ((System.ComponentModel.ISupportInitialize)grdDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();

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