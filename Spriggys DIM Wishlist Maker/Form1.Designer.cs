﻿namespace Spriggys_DIM_Wishlist_Maker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageForm = new System.Windows.Forms.TabPage();
            this.textBoxMain_Weapon = new System.Windows.Forms.TextBox();
            this.labelMain_WeaponID = new System.Windows.Forms.Label();
            this.comboBoxMain_Weapon = new System.Windows.Forms.ComboBox();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.buttonGenerateText = new System.Windows.Forms.Button();
            this.textBoxRollInput = new System.Windows.Forms.TextBox();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.buttonSettings_Save = new System.Windows.Forms.Button();
            this.labelSettings_RollInput = new System.Windows.Forms.Label();
            this.textBoxSettings_RollInput = new System.Windows.Forms.ComboBox();
            this.checkBoxSettings_IncludeMasterwork = new System.Windows.Forms.CheckBox();
            this.checkBoxSettings_IncludeRating = new System.Windows.Forms.CheckBox();
            this.textBoxSettings_OutputFile = new System.Windows.Forms.TextBox();
            this.labelSettings_OutputFile = new System.Windows.Forms.Label();
            this.checkBoxSettings_IncludeRollInfo = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageForm.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageForm);
            this.tabControl1.Controls.Add(this.tabPageText);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1454, 920);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageForm
            // 
            this.tabPageForm.Controls.Add(this.textBoxMain_Weapon);
            this.tabPageForm.Controls.Add(this.labelMain_WeaponID);
            this.tabPageForm.Controls.Add(this.comboBoxMain_Weapon);
            this.tabPageForm.Location = new System.Drawing.Point(4, 29);
            this.tabPageForm.Name = "tabPageForm";
            this.tabPageForm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForm.Size = new System.Drawing.Size(1446, 887);
            this.tabPageForm.TabIndex = 0;
            this.tabPageForm.Text = "Main";
            this.tabPageForm.UseVisualStyleBackColor = true;
            // 
            // textBoxMain_Weapon
            // 
            this.textBoxMain_Weapon.Location = new System.Drawing.Point(90, 24);
            this.textBoxMain_Weapon.Name = "textBoxMain_Weapon";
            this.textBoxMain_Weapon.Size = new System.Drawing.Size(200, 26);
            this.textBoxMain_Weapon.TabIndex = 2;
            this.textBoxMain_Weapon.Visible = false;
            // 
            // labelMain_WeaponID
            // 
            this.labelMain_WeaponID.AutoSize = true;
            this.labelMain_WeaponID.Location = new System.Drawing.Point(15, 27);
            this.labelMain_WeaponID.Name = "labelMain_WeaponID";
            this.labelMain_WeaponID.Size = new System.Drawing.Size(69, 20);
            this.labelMain_WeaponID.TabIndex = 1;
            this.labelMain_WeaponID.Text = "Weapon";
            this.labelMain_WeaponID.Click += new System.EventHandler(this.labelMain_WeaponID_Click);
            // 
            // comboBoxMain_Weapon
            // 
            this.comboBoxMain_Weapon.FormattingEnabled = true;
            this.comboBoxMain_Weapon.Location = new System.Drawing.Point(90, 24);
            this.comboBoxMain_Weapon.Name = "comboBoxMain_Weapon";
            this.comboBoxMain_Weapon.Size = new System.Drawing.Size(200, 28);
            this.comboBoxMain_Weapon.TabIndex = 0;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.buttonGenerateText);
            this.tabPageText.Controls.Add(this.textBoxRollInput);
            this.tabPageText.Location = new System.Drawing.Point(4, 29);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(1446, 887);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "Text Input";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateText
            // 
            this.buttonGenerateText.Location = new System.Drawing.Point(1267, 816);
            this.buttonGenerateText.Name = "buttonGenerateText";
            this.buttonGenerateText.Size = new System.Drawing.Size(173, 65);
            this.buttonGenerateText.TabIndex = 1;
            this.buttonGenerateText.Text = "Submit";
            this.buttonGenerateText.UseVisualStyleBackColor = true;
            this.buttonGenerateText.Click += new System.EventHandler(this.buttonGenerateText_Click);
            // 
            // textBoxRollInput
            // 
            this.textBoxRollInput.Location = new System.Drawing.Point(6, 6);
            this.textBoxRollInput.Multiline = true;
            this.textBoxRollInput.Name = "textBoxRollInput";
            this.textBoxRollInput.Size = new System.Drawing.Size(1434, 804);
            this.textBoxRollInput.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.checkBoxSettings_IncludeMasterwork);
            this.tabPageSettings.Controls.Add(this.checkBoxSettings_IncludeRollInfo);
            this.tabPageSettings.Controls.Add(this.checkBoxSettings_IncludeRating);
            this.tabPageSettings.Controls.Add(this.buttonSettings_Save);
            this.tabPageSettings.Controls.Add(this.labelSettings_RollInput);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_RollInput);
            this.tabPageSettings.Controls.Add(this.textBoxSettings_OutputFile);
            this.tabPageSettings.Controls.Add(this.labelSettings_OutputFile);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(1446, 887);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // buttonSettings_Save
            // 
            this.buttonSettings_Save.Location = new System.Drawing.Point(285, 458);
            this.buttonSettings_Save.Name = "buttonSettings_Save";
            this.buttonSettings_Save.Size = new System.Drawing.Size(173, 65);
            this.buttonSettings_Save.TabIndex = 5;
            this.buttonSettings_Save.Text = "Save";
            this.buttonSettings_Save.UseVisualStyleBackColor = true;
            this.buttonSettings_Save.Click += new System.EventHandler(this.buttonSettings_Save_Click);
            // 
            // labelSettings_RollInput
            // 
            this.labelSettings_RollInput.AutoSize = true;
            this.labelSettings_RollInput.Location = new System.Drawing.Point(82, 122);
            this.labelSettings_RollInput.Name = "labelSettings_RollInput";
            this.labelSettings_RollInput.Size = new System.Drawing.Size(77, 20);
            this.labelSettings_RollInput.TabIndex = 4;
            this.labelSettings_RollInput.Text = "Roll Input";
            // 
            // textBoxSettings_RollInput
            // 
            this.textBoxSettings_RollInput.FormattingEnabled = true;
            this.textBoxSettings_RollInput.Items.AddRange(new object[] {
            "Picklist",
            "Text"});
            this.textBoxSettings_RollInput.Location = new System.Drawing.Point(165, 122);
            this.textBoxSettings_RollInput.Name = "textBoxSettings_RollInput";
            this.textBoxSettings_RollInput.Size = new System.Drawing.Size(161, 28);
            this.textBoxSettings_RollInput.TabIndex = 3;
            // 
            // checkBoxSettings_IncludeMasterwork
            // 
            this.checkBoxSettings_IncludeMasterwork.AutoSize = true;
            this.checkBoxSettings_IncludeMasterwork.Location = new System.Drawing.Point(23, 292);
            this.checkBoxSettings_IncludeMasterwork.Name = "checkBoxSettings_IncludeMasterwork";
            this.checkBoxSettings_IncludeMasterwork.Size = new System.Drawing.Size(235, 24);
            this.checkBoxSettings_IncludeMasterwork.TabIndex = 1;
            this.checkBoxSettings_IncludeMasterwork.Text = "Include Masterwork in Notes";
            this.checkBoxSettings_IncludeMasterwork.UseVisualStyleBackColor = true;
            // 
            // checkBoxSettings_IncludeRating
            // 
            this.checkBoxSettings_IncludeRating.AutoSize = true;
            this.checkBoxSettings_IncludeRating.Location = new System.Drawing.Point(23, 244);
            this.checkBoxSettings_IncludeRating.Name = "checkBoxSettings_IncludeRating";
            this.checkBoxSettings_IncludeRating.Size = new System.Drawing.Size(200, 24);
            this.checkBoxSettings_IncludeRating.TabIndex = 0;
            this.checkBoxSettings_IncludeRating.Text = "Inlcude Rating in Notes";
            this.checkBoxSettings_IncludeRating.UseVisualStyleBackColor = true;
            // 
            // textBoxSettings_OutputFile
            // 
            this.textBoxSettings_OutputFile.Location = new System.Drawing.Point(165, 61);
            this.textBoxSettings_OutputFile.Name = "textBoxSettings_OutputFile";
            this.textBoxSettings_OutputFile.Size = new System.Drawing.Size(293, 26);
            this.textBoxSettings_OutputFile.TabIndex = 1;
            this.textBoxSettings_OutputFile.TextChanged += new System.EventHandler(this.textBoxSettings_OutputFile_TextChanged);
            // 
            // labelSettings_OutputFile
            // 
            this.labelSettings_OutputFile.AutoSize = true;
            this.labelSettings_OutputFile.Location = new System.Drawing.Point(3, 61);
            this.labelSettings_OutputFile.Name = "labelSettings_OutputFile";
            this.labelSettings_OutputFile.Size = new System.Drawing.Size(156, 20);
            this.labelSettings_OutputFile.TabIndex = 0;
            this.labelSettings_OutputFile.Text = "Output File Location:";
            // 
            // checkBoxSettings_IncludeRollInfo
            // 
            this.checkBoxSettings_IncludeRollInfo.AutoSize = true;
            this.checkBoxSettings_IncludeRollInfo.Location = new System.Drawing.Point(23, 192);
            this.checkBoxSettings_IncludeRollInfo.Name = "checkBoxSettings_IncludeRollInfo";
            this.checkBoxSettings_IncludeRollInfo.Size = new System.Drawing.Size(244, 24);
            this.checkBoxSettings_IncludeRollInfo.TabIndex = 6;
            this.checkBoxSettings_IncludeRollInfo.Text = "Include Roll Info as Comment";
            this.checkBoxSettings_IncludeRollInfo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Spriggy\'s DIM Wishlist Maker";
            this.tabControl1.ResumeLayout(false);
            this.tabPageForm.ResumeLayout(false);
            this.tabPageForm.PerformLayout();
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.Button buttonGenerateText;
        private System.Windows.Forms.TextBox textBoxRollInput;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox textBoxSettings_OutputFile;
        private System.Windows.Forms.Label labelSettings_OutputFile;
        private System.Windows.Forms.Label labelMain_WeaponID;
        private System.Windows.Forms.ComboBox comboBoxMain_Weapon;
        private System.Windows.Forms.CheckBox checkBoxSettings_IncludeMasterwork;
        private System.Windows.Forms.CheckBox checkBoxSettings_IncludeRating;
        private System.Windows.Forms.TextBox textBoxMain_Weapon;
        private System.Windows.Forms.Label labelSettings_RollInput;
        private System.Windows.Forms.ComboBox textBoxSettings_RollInput;
        private System.Windows.Forms.Button buttonSettings_Save;
        private System.Windows.Forms.CheckBox checkBoxSettings_IncludeRollInfo;
    }
}
