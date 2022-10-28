namespace RACWinFormsSample
{
    partial class AddProjectForm
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
            this.components = new System.ComponentModel.Container();
            this.DeleteValueButton = new System.Windows.Forms.Button();
            this.EditValueButton = new System.Windows.Forms.Button();
            this.AddValueButton = new System.Windows.Forms.Button();
            this.ValueListBox = new System.Windows.Forms.ListBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteValueButton
            // 
            this.DeleteValueButton.Location = new System.Drawing.Point(267, 193);
            this.DeleteValueButton.Name = "DeleteValueButton";
            this.DeleteValueButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteValueButton.TabIndex = 16;
            this.DeleteValueButton.Text = "Delete Value";
            this.DeleteValueButton.UseVisualStyleBackColor = true;
            this.DeleteValueButton.Click += new System.EventHandler(this.DeleteValueButton_Click);
            // 
            // EditValueButton
            // 
            this.EditValueButton.Location = new System.Drawing.Point(267, 150);
            this.EditValueButton.Name = "EditValueButton";
            this.EditValueButton.Size = new System.Drawing.Size(75, 23);
            this.EditValueButton.TabIndex = 15;
            this.EditValueButton.Text = "Edit Value";
            this.EditValueButton.UseVisualStyleBackColor = true;
            this.EditValueButton.Click += new System.EventHandler(this.EditValueButton_Click);
            // 
            // AddValueButton
            // 
            this.AddValueButton.Location = new System.Drawing.Point(267, 106);
            this.AddValueButton.Name = "AddValueButton";
            this.AddValueButton.Size = new System.Drawing.Size(75, 23);
            this.AddValueButton.TabIndex = 14;
            this.AddValueButton.Text = "Add Vlaue";
            this.AddValueButton.UseVisualStyleBackColor = true;
            this.AddValueButton.Click += new System.EventHandler(this.AddValueButton_Click);
            // 
            // ValueListBox
            // 
            this.ValueListBox.FormattingEnabled = true;
            this.ValueListBox.ItemHeight = 15;
            this.ValueListBox.Location = new System.Drawing.Point(105, 92);
            this.ValueListBox.Name = "ValueListBox";
            this.ValueListBox.Size = new System.Drawing.Size(120, 244);
            this.ValueListBox.TabIndex = 13;
            this.ValueListBox.SelectedIndexChanged += new System.EventHandler(this.ValueListBox_SelectedIndexChanged);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(105, 45);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 23);
            this.TypeComboBox.TabIndex = 12;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(105, 15);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(120, 23);
            this.NameTextBox.TabIndex = 11;
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(42, 43);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(38, 15);
            this.TypeLabel.TabIndex = 10;
            this.TypeLabel.Text = "Type: ";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(41, 18);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 15);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "Name: ";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(270, 308);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_ClickAsync);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteValueButton);
            this.Controls.Add(this.EditValueButton);
            this.Controls.Add(this.AddValueButton);
            this.Controls.Add(this.ValueListBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.NameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProjectForm";
            this.Text = "Add Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProjectForm_FormClosed);
            this.Load += new System.EventHandler(this.AddProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteValueButton;
        private System.Windows.Forms.Button EditValueButton;
        private System.Windows.Forms.Button AddValueButton;
        private System.Windows.Forms.ListBox ValueListBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}