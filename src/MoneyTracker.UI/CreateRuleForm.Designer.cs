namespace MoneyTracker
{
    partial class CreateRuleForm
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
            GridColumnNameText = new System.Windows.Forms.TextBox();
            GridDataPatternText = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            UpdateDataValueText = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            UpdateColumnNameText = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            CategoryButton = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            UpdateDataValueCombo = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "Grid column name:";
            // 
            // GridColumnNameText
            // 
            GridColumnNameText.Location = new System.Drawing.Point(12, 30);
            GridColumnNameText.Name = "GridColumnNameText";
            GridColumnNameText.Size = new System.Drawing.Size(176, 23);
            GridColumnNameText.TabIndex = 1;
            // 
            // GridDataPatternText
            // 
            GridDataPatternText.Location = new System.Drawing.Point(12, 85);
            GridDataPatternText.Name = "GridDataPatternText";
            GridDataPatternText.Size = new System.Drawing.Size(176, 23);
            GridDataPatternText.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(99, 15);
            label2.TabIndex = 2;
            label2.Text = "Grid data pattern:";
            // 
            // UpdateDataValueText
            // 
            UpdateDataValueText.Location = new System.Drawing.Point(194, 85);
            UpdateDataValueText.Name = "UpdateDataValueText";
            UpdateDataValueText.Size = new System.Drawing.Size(176, 23);
            UpdateDataValueText.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(194, 67);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(105, 15);
            label3.TabIndex = 6;
            label3.Text = "Update data value:";
            // 
            // UpdateColumnNameText
            // 
            UpdateColumnNameText.Location = new System.Drawing.Point(194, 30);
            UpdateColumnNameText.Name = "UpdateColumnNameText";
            UpdateColumnNameText.Size = new System.Drawing.Size(176, 23);
            UpdateColumnNameText.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(194, 12);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(125, 15);
            label4.TabIndex = 4;
            label4.Text = "Update column name:";
            // 
            // CategoryButton
            // 
            CategoryButton.Location = new System.Drawing.Point(376, 85);
            CategoryButton.Name = "CategoryButton";
            CategoryButton.Size = new System.Drawing.Size(115, 23);
            CategoryButton.TabIndex = 6;
            CategoryButton.Text = "Pick Category";
            CategoryButton.UseVisualStyleBackColor = true;
            CategoryButton.Click += CategoryButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SaveButton.Location = new System.Drawing.Point(424, 169);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(75, 23);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // UpdateDataValueCombo
            // 
            UpdateDataValueCombo.FormattingEnabled = true;
            UpdateDataValueCombo.Location = new System.Drawing.Point(194, 114);
            UpdateDataValueCombo.Name = "UpdateDataValueCombo";
            UpdateDataValueCombo.Size = new System.Drawing.Size(176, 23);
            UpdateDataValueCombo.TabIndex = 5;
            UpdateDataValueCombo.Visible = false;
            UpdateDataValueCombo.SelectedValueChanged += UpdateDataValueCombo_SelectedValueChanged;
            // 
            // CreateRuleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(511, 204);
            Controls.Add(UpdateDataValueCombo);
            Controls.Add(SaveButton);
            Controls.Add(CategoryButton);
            Controls.Add(UpdateDataValueText);
            Controls.Add(label3);
            Controls.Add(UpdateColumnNameText);
            Controls.Add(label4);
            Controls.Add(GridDataPatternText);
            Controls.Add(label2);
            Controls.Add(GridColumnNameText);
            Controls.Add(label1);
            Name = "CreateRuleForm";
            Text = "CreateRuleForm";
            Shown += CreateRuleForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GridColumnNameText;
        private System.Windows.Forms.TextBox GridDataPatternText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UpdateDataValueText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UpdateColumnNameText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CategoryButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox UpdateDataValueCombo;
    }
}