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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSSHClientPathWarningIcon = new System.Windows.Forms.PictureBox();
            this.labelSSHClientPathWarningMessage = new System.Windows.Forms.Label();
            this.buttonConfigureSSHClientPath = new System.Windows.Forms.Button();
            this.textBoxSSHClientPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxCompatibleMode = new System.Windows.Forms.CheckBox();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.labelWarningMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxConnectionMethodMapFieldName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHostAddressMapFieldName = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAdditionalOptionsMapFieldName = new System.Windows.Forms.ComboBox();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabControl3.Location = new System.Drawing.Point(12, 12);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(295, 208);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxSSHClientPathWarningIcon);
            this.groupBox2.Controls.Add(this.labelSSHClientPathWarningMessage);
            this.groupBox2.Controls.Add(this.buttonConfigureSSHClientPath);
            this.groupBox2.Controls.Add(this.textBoxSSHClientPath);
            this.groupBox2.Location = new System.Drawing.Point(3, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSH Client Path";
            // 
            // pictureBoxSSHClientPathWarningIcon
            // 
            this.pictureBoxSSHClientPathWarningIcon.ErrorImage = null;
            this.pictureBoxSSHClientPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxSSHClientPathWarningIcon.Location = new System.Drawing.Point(19, 49);
            this.pictureBoxSSHClientPathWarningIcon.Name = "pictureBoxSSHClientPathWarningIcon";
            this.pictureBoxSSHClientPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSSHClientPathWarningIcon.TabIndex = 7;
            this.pictureBoxSSHClientPathWarningIcon.TabStop = false;
            // 
            // labelSSHClientPathWarningMessage
            // 
            this.labelSSHClientPathWarningMessage.AutoSize = true;
            this.labelSSHClientPathWarningMessage.Location = new System.Drawing.Point(38, 50);
            this.labelSSHClientPathWarningMessage.Name = "labelSSHClientPathWarningMessage";
            this.labelSSHClientPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSSHClientPathWarningMessage.Size = new System.Drawing.Size(151, 13);
            this.labelSSHClientPathWarningMessage.TabIndex = 5;
            this.labelSSHClientPathWarningMessage.Text = "Specified path does not exists.";
            this.labelSSHClientPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigureSSHClientPath
            // 
            this.buttonConfigureSSHClientPath.Location = new System.Drawing.Point(195, 45);
            this.buttonConfigureSSHClientPath.Name = "buttonConfigureSSHClientPath";
            this.buttonConfigureSSHClientPath.Size = new System.Drawing.Size(77, 24);
            this.buttonConfigureSSHClientPath.TabIndex = 4;
            this.buttonConfigureSSHClientPath.Text = "Configure...";
            this.buttonConfigureSSHClientPath.UseVisualStyleBackColor = true;
            this.buttonConfigureSSHClientPath.Click += new System.EventHandler(this.buttonConfigureSSHClientPath_Click);
            // 
            // textBoxSSHClientPath
            // 
            this.textBoxSSHClientPath.Location = new System.Drawing.Point(19, 19);
            this.textBoxSSHClientPath.Name = "textBoxSSHClientPath";
            this.textBoxSSHClientPath.Size = new System.Drawing.Size(253, 20);
            this.textBoxSSHClientPath.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCompatibleMode);
            this.groupBox1.Controls.Add(this.checkBoxEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxCompatibleMode
            // 
            this.checkBoxCompatibleMode.AutoSize = true;
            this.checkBoxCompatibleMode.Location = new System.Drawing.Point(19, 42);
            this.checkBoxCompatibleMode.Name = "checkBoxCompatibleMode";
            this.checkBoxCompatibleMode.Size = new System.Drawing.Size(107, 17);
            this.checkBoxCompatibleMode.TabIndex = 1;
            this.checkBoxCompatibleMode.Text = "Compatible mode";
            this.checkBoxCompatibleMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(19, 19);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(59, 17);
            this.checkBoxEnable.TabIndex = 0;
            this.checkBoxEnable.Text = "Enable";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(287, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map Fields";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.groupBox12.Location = new System.Drawing.Point(3, 1);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(280, 176);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Settings";
            // 
            // labelWarningMessage
            // 
            this.labelWarningMessage.AutoSize = true;
            this.labelWarningMessage.Location = new System.Drawing.Point(9, 124);
            this.labelWarningMessage.Name = "labelWarningMessage";
            this.labelWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWarningMessage.Size = new System.Drawing.Size(270, 26);
            this.labelWarningMessage.TabIndex = 4;
            this.labelWarningMessage.Text = "No database available. Open or unlock a database first \r\nand then try again.";
            this.labelWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection method from";
            // 
            // comboBoxConnectionMethodMapFieldName
            // 
            this.comboBoxConnectionMethodMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnectionMethodMapFieldName.FormattingEnabled = true;
            this.comboBoxConnectionMethodMapFieldName.Location = new System.Drawing.Point(137, 50);
            this.comboBoxConnectionMethodMapFieldName.Name = "comboBoxConnectionMethodMapFieldName";
            this.comboBoxConnectionMethodMapFieldName.Size = new System.Drawing.Size(137, 21);
            this.comboBoxConnectionMethodMapFieldName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host address from";
            // 
            // comboBoxHostAddressMapFieldName
            // 
            this.comboBoxHostAddressMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHostAddressMapFieldName.FormattingEnabled = true;
            this.comboBoxHostAddressMapFieldName.Location = new System.Drawing.Point(137, 19);
            this.comboBoxHostAddressMapFieldName.Name = "comboBoxHostAddressMapFieldName";
            this.comboBoxHostAddressMapFieldName.Size = new System.Drawing.Size(137, 21);
            this.comboBoxHostAddressMapFieldName.TabIndex = 0;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(232, 226);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(151, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(70, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Additional options from";
            // 
            // comboBoxAdditionalOptionsMapFieldName
            // 
            this.comboBoxAdditionalOptionsMapFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdditionalOptionsMapFieldName.FormattingEnabled = true;
            this.comboBoxAdditionalOptionsMapFieldName.Location = new System.Drawing.Point(137, 81);
            this.comboBoxAdditionalOptionsMapFieldName.Name = "comboBoxAdditionalOptionsMapFieldName";
            this.comboBoxAdditionalOptionsMapFieldName.Size = new System.Drawing.Size(137, 21);
            this.comboBoxAdditionalOptionsMapFieldName.TabIndex = 6;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(319, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.tabControl3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{title} Options";
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxConnectionMethodMapFieldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHostAddressMapFieldName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.CheckBox checkBoxCompatibleMode;
        private System.Windows.Forms.Label labelWarningMessage;
        private System.Windows.Forms.Label labelSSHClientPathWarningMessage;
        private System.Windows.Forms.PictureBox pictureBoxSSHClientPathWarningIcon;
        private System.Windows.Forms.ComboBox comboBoxAdditionalOptionsMapFieldName;
        private System.Windows.Forms.Label label3;
    }
}