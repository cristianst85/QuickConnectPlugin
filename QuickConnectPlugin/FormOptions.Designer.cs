namespace QuickConnectPlugin {
    partial class FormOptions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxWinScpPathWarningIcon = new System.Windows.Forms.PictureBox();
            this.labelWinScpPathWarningMessage = new System.Windows.Forms.Label();
            this.buttonConfigureWinScpPath = new System.Windows.Forms.Button();
            this.textBoxWinScpPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSSHClientPathWarningIcon = new System.Windows.Forms.PictureBox();
            this.labelSSHClientPathWarningMessage = new System.Windows.Forms.Label();
            this.buttonConfigureSSHClientPath = new System.Windows.Forms.Button();
            this.textBoxSSHClientPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxCompatibleMode = new System.Windows.Forms.CheckBox();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBoxAdditionalOptionsMapFieldName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelWarningMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxConnectionMethodMapFieldName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHostAddressMapFieldName = new System.Windows.Forms.ComboBox();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinScpPathWarningIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSSHClientPathWarningIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Location = new System.Drawing.Point(24, 23);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(590, 566);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(574, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxWinScpPathWarningIcon);
            this.groupBox3.Controls.Add(this.labelWinScpPathWarningMessage);
            this.groupBox3.Controls.Add(this.buttonConfigureWinScpPath);
            this.groupBox3.Controls.Add(this.textBoxWinScpPath);
            this.groupBox3.Location = new System.Drawing.Point(6, 353);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(560, 154);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WinSCP Path";
            // 
            // pictureBoxWinScpPathWarningIcon
            // 
            this.pictureBoxWinScpPathWarningIcon.ErrorImage = null;
            this.pictureBoxWinScpPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxWinScpPathWarningIcon.Location = new System.Drawing.Point(38, 96);
            this.pictureBoxWinScpPathWarningIcon.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxWinScpPathWarningIcon.Name = "pictureBoxWinScpPathWarningIcon";
            this.pictureBoxWinScpPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxWinScpPathWarningIcon.TabIndex = 7;
            this.pictureBoxWinScpPathWarningIcon.TabStop = false;
            // 
            // labelWinScpPathWarningMessage
            // 
            this.labelWinScpPathWarningMessage.AutoSize = true;
            this.labelWinScpPathWarningMessage.Location = new System.Drawing.Point(76, 96);
            this.labelWinScpPathWarningMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWinScpPathWarningMessage.Name = "labelWinScpPathWarningMessage";
            this.labelWinScpPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWinScpPathWarningMessage.Size = new System.Drawing.Size(306, 25);
            this.labelWinScpPathWarningMessage.TabIndex = 5;
            this.labelWinScpPathWarningMessage.Text = "Specified path does not exists.";
            this.labelWinScpPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigureWinScpPath
            // 
            this.buttonConfigureWinScpPath.Location = new System.Drawing.Point(390, 87);
            this.buttonConfigureWinScpPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonConfigureWinScpPath.Name = "buttonConfigureWinScpPath";
            this.buttonConfigureWinScpPath.Size = new System.Drawing.Size(154, 46);
            this.buttonConfigureWinScpPath.TabIndex = 4;
            this.buttonConfigureWinScpPath.Text = "Configure...";
            this.buttonConfigureWinScpPath.UseVisualStyleBackColor = true;
            this.buttonConfigureWinScpPath.Click += new System.EventHandler(this.buttonConfigureWinScpPath_Click);
            // 
            // textBoxWinScpPath
            // 
            this.textBoxWinScpPath.Location = new System.Drawing.Point(38, 37);
            this.textBoxWinScpPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxWinScpPath.Name = "textBoxWinScpPath";
            this.textBoxWinScpPath.Size = new System.Drawing.Size(502, 31);
            this.textBoxWinScpPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxSSHClientPathWarningIcon);
            this.groupBox2.Controls.Add(this.labelSSHClientPathWarningMessage);
            this.groupBox2.Controls.Add(this.buttonConfigureSSHClientPath);
            this.groupBox2.Controls.Add(this.textBoxSSHClientPath);
            this.groupBox2.Location = new System.Drawing.Point(6, 187);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(560, 154);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSH Client Path";
            // 
            // pictureBoxSSHClientPathWarningIcon
            // 
            this.pictureBoxSSHClientPathWarningIcon.ErrorImage = null;
            this.pictureBoxSSHClientPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxSSHClientPathWarningIcon.Location = new System.Drawing.Point(38, 98);
            this.pictureBoxSSHClientPathWarningIcon.Name = "pictureBoxSSHClientPathWarningIcon";
            this.pictureBoxSSHClientPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSSHClientPathWarningIcon.TabIndex = 7;
            this.pictureBoxSSHClientPathWarningIcon.TabStop = false;
            // 
            // labelSSHClientPathWarningMessage
            // 
            this.labelSSHClientPathWarningMessage.AutoSize = true;
            this.labelSSHClientPathWarningMessage.Location = new System.Drawing.Point(76, 98);
            this.labelSSHClientPathWarningMessage.Name = "labelSSHClientPathWarningMessage";
            this.labelSSHClientPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSSHClientPathWarningMessage.Size = new System.Drawing.Size(306, 25);
            this.labelSSHClientPathWarningMessage.TabIndex = 5;
            this.labelSSHClientPathWarningMessage.Text = "Specified path does not exists.";
            this.labelSSHClientPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigureSSHClientPath
            // 
            this.buttonConfigureSSHClientPath.Location = new System.Drawing.Point(390, 87);
            this.buttonConfigureSSHClientPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonConfigureSSHClientPath.Name = "buttonConfigureSSHClientPath";
            this.buttonConfigureSSHClientPath.Size = new System.Drawing.Size(154, 46);
            this.buttonConfigureSSHClientPath.TabIndex = 4;
            this.buttonConfigureSSHClientPath.Text = "Configure...";
            this.buttonConfigureSSHClientPath.UseVisualStyleBackColor = true;
            this.buttonConfigureSSHClientPath.Click += new System.EventHandler(this.buttonConfigureSSHClientPath_Click);
            // 
            // textBoxSSHClientPath
            // 
            this.textBoxSSHClientPath.Location = new System.Drawing.Point(38, 37);
            this.textBoxSSHClientPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSSHClientPath.Name = "textBoxSSHClientPath";
            this.textBoxSSHClientPath.Size = new System.Drawing.Size(502, 31);
            this.textBoxSSHClientPath.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCompatibleMode);
            this.groupBox1.Controls.Add(this.checkBoxEnable);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(560, 173);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxCompatibleMode
            // 
            this.checkBoxCompatibleMode.AutoSize = true;
            this.checkBoxCompatibleMode.Location = new System.Drawing.Point(38, 81);
            this.checkBoxCompatibleMode.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxCompatibleMode.Name = "checkBoxCompatibleMode";
            this.checkBoxCompatibleMode.Size = new System.Drawing.Size(211, 29);
            this.checkBoxCompatibleMode.TabIndex = 1;
            this.checkBoxCompatibleMode.Text = "Compatible mode";
            this.checkBoxCompatibleMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(38, 37);
            this.checkBoxEnable.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(111, 29);
            this.checkBoxEnable.TabIndex = 0;
            this.checkBoxEnable.Text = "Enable";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox12);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(574, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map Fields";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(456, 601);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(6);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(150, 44);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(294, 601);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 44);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(132, 601);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 44);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.comboBoxAdditionalOptionsMapFieldName);
            this.groupBox12.Controls.Add(this.label3);
            this.groupBox12.Controls.Add(this.labelWarningMessage);
            this.groupBox12.Controls.Add(this.label2);
            this.groupBox12.Controls.Add(this.comboBoxConnectionMethodMapFieldName);
            this.groupBox12.Controls.Add(this.label1);
            this.groupBox12.Controls.Add(this.comboBoxHostAddressMapFieldName);
            this.groupBox12.Location = new System.Drawing.Point(8, 6);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox12.Size = new System.Drawing.Size(560, 507);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Settings";
            // 
            // comboBoxAdditionalOptionsMapFieldName
            // 
            this.comboBoxAdditionalOptionsMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdditionalOptionsMapFieldName.FormattingEnabled = true;
            this.comboBoxAdditionalOptionsMapFieldName.Location = new System.Drawing.Point(274, 156);
            this.comboBoxAdditionalOptionsMapFieldName.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxAdditionalOptionsMapFieldName.Name = "comboBoxAdditionalOptionsMapFieldName";
            this.comboBoxAdditionalOptionsMapFieldName.Size = new System.Drawing.Size(270, 33);
            this.comboBoxAdditionalOptionsMapFieldName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Additional options from";
            // 
            // labelWarningMessage
            // 
            this.labelWarningMessage.AutoSize = true;
            this.labelWarningMessage.Location = new System.Drawing.Point(18, 238);
            this.labelWarningMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWarningMessage.Name = "labelWarningMessage";
            this.labelWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWarningMessage.Size = new System.Drawing.Size(544, 50);
            this.labelWarningMessage.TabIndex = 4;
            this.labelWarningMessage.Text = "No database available. Open or unlock a database first \r\nand then try again.";
            this.labelWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection method from";
            // 
            // comboBoxConnectionMethodMapFieldName
            // 
            this.comboBoxConnectionMethodMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnectionMethodMapFieldName.FormattingEnabled = true;
            this.comboBoxConnectionMethodMapFieldName.Location = new System.Drawing.Point(274, 96);
            this.comboBoxConnectionMethodMapFieldName.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxConnectionMethodMapFieldName.Name = "comboBoxConnectionMethodMapFieldName";
            this.comboBoxConnectionMethodMapFieldName.Size = new System.Drawing.Size(270, 33);
            this.comboBoxConnectionMethodMapFieldName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host address from";
            // 
            // comboBoxHostAddressMapFieldName
            // 
            this.comboBoxHostAddressMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHostAddressMapFieldName.FormattingEnabled = true;
            this.comboBoxHostAddressMapFieldName.Location = new System.Drawing.Point(274, 37);
            this.comboBoxHostAddressMapFieldName.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxHostAddressMapFieldName.Name = "comboBoxHostAddressMapFieldName";
            this.comboBoxHostAddressMapFieldName.Size = new System.Drawing.Size(270, 33);
            this.comboBoxHostAddressMapFieldName.TabIndex = 0;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(638, 658);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.tabControl3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{title} Options";
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinScpPathWarningIcon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSSHClientPathWarningIcon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConfigureSSHClientPath;
        private System.Windows.Forms.TextBox textBoxSSHClientPath;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.CheckBox checkBoxCompatibleMode;
        private System.Windows.Forms.Label labelSSHClientPathWarningMessage;
        private System.Windows.Forms.PictureBox pictureBoxSSHClientPathWarningIcon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBoxWinScpPathWarningIcon;
        private System.Windows.Forms.Label labelWinScpPathWarningMessage;
        private System.Windows.Forms.Button buttonConfigureWinScpPath;
        private System.Windows.Forms.TextBox textBoxWinScpPath;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox comboBoxAdditionalOptionsMapFieldName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelWarningMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxConnectionMethodMapFieldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHostAddressMapFieldName;
    }
}