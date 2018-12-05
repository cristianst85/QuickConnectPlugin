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
            this.tabControl = new System.Windows.Forms.TabControl();
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pictureBoxVSpherePowerCLIStatusIcon = new System.Windows.Forms.PictureBox();
            this.labelVSpherePowerCLIStatusMessage = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBoxPsPasswdPathWarningIcon = new System.Windows.Forms.PictureBox();
            this.labelPsPasswdPathWarningMessage = new System.Windows.Forms.Label();
            this.buttonConfigurePsPasswdPath = new System.Windows.Forms.Button();
            this.textBoxPsPasswdPath = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxAddChangePasswordItem = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBoxAdditionalOptionsMapFieldName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelWarningMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxConnectionMethodMapFieldName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHostAddressMapFieldName = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxDisableCLIPasswordForPutty = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWinScpPathWarningIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSSHClientPathWarningIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVSpherePowerCLIStatusIcon)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsPasswdPathWarningIcon)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(305, 294);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 268);
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
            this.groupBox3.Location = new System.Drawing.Point(3, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 80);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WinSCP Path";
            // 
            // pictureBoxWinScpPathWarningIcon
            // 
            this.pictureBoxWinScpPathWarningIcon.ErrorImage = null;
            this.pictureBoxWinScpPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxWinScpPathWarningIcon.Location = new System.Drawing.Point(19, 48);
            this.pictureBoxWinScpPathWarningIcon.Name = "pictureBoxWinScpPathWarningIcon";
            this.pictureBoxWinScpPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxWinScpPathWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxWinScpPathWarningIcon.TabIndex = 7;
            this.pictureBoxWinScpPathWarningIcon.TabStop = false;
            // 
            // labelWinScpPathWarningMessage
            // 
            this.labelWinScpPathWarningMessage.AutoSize = true;
            this.labelWinScpPathWarningMessage.Location = new System.Drawing.Point(38, 50);
            this.labelWinScpPathWarningMessage.Name = "labelWinScpPathWarningMessage";
            this.labelWinScpPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWinScpPathWarningMessage.Size = new System.Drawing.Size(151, 13);
            this.labelWinScpPathWarningMessage.TabIndex = 5;
            this.labelWinScpPathWarningMessage.Text = "Specified path does not exists.";
            this.labelWinScpPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigureWinScpPath
            // 
            this.buttonConfigureWinScpPath.Location = new System.Drawing.Point(207, 44);
            this.buttonConfigureWinScpPath.Name = "buttonConfigureWinScpPath";
            this.buttonConfigureWinScpPath.Size = new System.Drawing.Size(77, 24);
            this.buttonConfigureWinScpPath.TabIndex = 4;
            this.buttonConfigureWinScpPath.Text = "Configure...";
            this.buttonConfigureWinScpPath.UseVisualStyleBackColor = true;
            this.buttonConfigureWinScpPath.Click += new System.EventHandler(this.buttonConfigureWinScpPath_Click);
            // 
            // textBoxWinScpPath
            // 
            this.textBoxWinScpPath.Location = new System.Drawing.Point(19, 19);
            this.textBoxWinScpPath.Name = "textBoxWinScpPath";
            this.textBoxWinScpPath.Size = new System.Drawing.Size(265, 20);
            this.textBoxWinScpPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxSSHClientPathWarningIcon);
            this.groupBox2.Controls.Add(this.labelSSHClientPathWarningMessage);
            this.groupBox2.Controls.Add(this.buttonConfigureSSHClientPath);
            this.groupBox2.Controls.Add(this.textBoxSSHClientPath);
            this.groupBox2.Location = new System.Drawing.Point(3, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSH Client Path";
            // 
            // pictureBoxSSHClientPathWarningIcon
            // 
            this.pictureBoxSSHClientPathWarningIcon.ErrorImage = null;
            this.pictureBoxSSHClientPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxSSHClientPathWarningIcon.Location = new System.Drawing.Point(19, 49);
            this.pictureBoxSSHClientPathWarningIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxSSHClientPathWarningIcon.Name = "pictureBoxSSHClientPathWarningIcon";
            this.pictureBoxSSHClientPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSSHClientPathWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSSHClientPathWarningIcon.TabIndex = 7;
            this.pictureBoxSSHClientPathWarningIcon.TabStop = false;
            // 
            // labelSSHClientPathWarningMessage
            // 
            this.labelSSHClientPathWarningMessage.AutoSize = true;
            this.labelSSHClientPathWarningMessage.Location = new System.Drawing.Point(38, 51);
            this.labelSSHClientPathWarningMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSSHClientPathWarningMessage.Name = "labelSSHClientPathWarningMessage";
            this.labelSSHClientPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSSHClientPathWarningMessage.Size = new System.Drawing.Size(151, 13);
            this.labelSSHClientPathWarningMessage.TabIndex = 5;
            this.labelSSHClientPathWarningMessage.Text = "Specified path does not exists.";
            this.labelSSHClientPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigureSSHClientPath
            // 
            this.buttonConfigureSSHClientPath.Location = new System.Drawing.Point(207, 45);
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
            this.textBoxSSHClientPath.Size = new System.Drawing.Size(265, 20);
            this.textBoxSSHClientPath.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDisableCLIPasswordForPutty);
            this.groupBox1.Controls.Add(this.checkBoxCompatibleMode);
            this.groupBox1.Controls.Add(this.checkBoxEnable);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxCompatibleMode
            // 
            this.checkBoxCompatibleMode.AutoSize = true;
            this.checkBoxCompatibleMode.Location = new System.Drawing.Point(19, 42);
            this.checkBoxCompatibleMode.Name = "checkBoxCompatibleMode";
            this.checkBoxCompatibleMode.Size = new System.Drawing.Size(268, 17);
            this.checkBoxCompatibleMode.TabIndex = 1;
            this.checkBoxCompatibleMode.Text = "Place items at the bottom of the entry context menu";
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
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 268);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Password Changer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBoxVSpherePowerCLIStatusIcon);
            this.groupBox6.Controls.Add(this.labelVSpherePowerCLIStatusMessage);
            this.groupBox6.Location = new System.Drawing.Point(3, 184);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(290, 80);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "vSphere PowerCLI Status";
            // 
            // pictureBoxVSpherePowerCLIStatusIcon
            // 
            this.pictureBoxVSpherePowerCLIStatusIcon.ErrorImage = null;
            this.pictureBoxVSpherePowerCLIStatusIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxVSpherePowerCLIStatusIcon.Location = new System.Drawing.Point(19, 32);
            this.pictureBoxVSpherePowerCLIStatusIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxVSpherePowerCLIStatusIcon.Name = "pictureBoxVSpherePowerCLIStatusIcon";
            this.pictureBoxVSpherePowerCLIStatusIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxVSpherePowerCLIStatusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxVSpherePowerCLIStatusIcon.TabIndex = 8;
            this.pictureBoxVSpherePowerCLIStatusIcon.TabStop = false;
            // 
            // labelVSpherePowerCLIStatusMessage
            // 
            this.labelVSpherePowerCLIStatusMessage.AutoSize = true;
            this.labelVSpherePowerCLIStatusMessage.Location = new System.Drawing.Point(38, 33);
            this.labelVSpherePowerCLIStatusMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVSpherePowerCLIStatusMessage.Name = "labelVSpherePowerCLIStatusMessage";
            this.labelVSpherePowerCLIStatusMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelVSpherePowerCLIStatusMessage.Size = new System.Drawing.Size(148, 13);
            this.labelVSpherePowerCLIStatusMessage.TabIndex = 8;
            this.labelVSpherePowerCLIStatusMessage.Text = "vSphere PowerCLI is {status}.";
            this.labelVSpherePowerCLIStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBoxPsPasswdPathWarningIcon);
            this.groupBox5.Controls.Add(this.labelPsPasswdPathWarningMessage);
            this.groupBox5.Controls.Add(this.buttonConfigurePsPasswdPath);
            this.groupBox5.Controls.Add(this.textBoxPsPasswdPath);
            this.groupBox5.Location = new System.Drawing.Point(3, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(290, 80);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PsPasswd Path";
            // 
            // pictureBoxPsPasswdPathWarningIcon
            // 
            this.pictureBoxPsPasswdPathWarningIcon.ErrorImage = null;
            this.pictureBoxPsPasswdPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
            this.pictureBoxPsPasswdPathWarningIcon.Location = new System.Drawing.Point(19, 49);
            this.pictureBoxPsPasswdPathWarningIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPsPasswdPathWarningIcon.Name = "pictureBoxPsPasswdPathWarningIcon";
            this.pictureBoxPsPasswdPathWarningIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPsPasswdPathWarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPsPasswdPathWarningIcon.TabIndex = 7;
            this.pictureBoxPsPasswdPathWarningIcon.TabStop = false;
            // 
            // labelPsPasswdPathWarningMessage
            // 
            this.labelPsPasswdPathWarningMessage.AutoSize = true;
            this.labelPsPasswdPathWarningMessage.Location = new System.Drawing.Point(38, 51);
            this.labelPsPasswdPathWarningMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPsPasswdPathWarningMessage.Name = "labelPsPasswdPathWarningMessage";
            this.labelPsPasswdPathWarningMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPsPasswdPathWarningMessage.Size = new System.Drawing.Size(151, 13);
            this.labelPsPasswdPathWarningMessage.TabIndex = 5;
            this.labelPsPasswdPathWarningMessage.Text = "Specified path does not exists.";
            this.labelPsPasswdPathWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConfigurePsPasswdPath
            // 
            this.buttonConfigurePsPasswdPath.Location = new System.Drawing.Point(207, 45);
            this.buttonConfigurePsPasswdPath.Name = "buttonConfigurePsPasswdPath";
            this.buttonConfigurePsPasswdPath.Size = new System.Drawing.Size(77, 24);
            this.buttonConfigurePsPasswdPath.TabIndex = 4;
            this.buttonConfigurePsPasswdPath.Text = "Configure...";
            this.buttonConfigurePsPasswdPath.UseVisualStyleBackColor = true;
            this.buttonConfigurePsPasswdPath.Click += new System.EventHandler(this.buttonConfigurePsPasswdPath_Click);
            // 
            // textBoxPsPasswdPath
            // 
            this.textBoxPsPasswdPath.Location = new System.Drawing.Point(19, 19);
            this.textBoxPsPasswdPath.Name = "textBoxPsPasswdPath";
            this.textBoxPsPasswdPath.Size = new System.Drawing.Size(265, 20);
            this.textBoxPsPasswdPath.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxAddChangePasswordItem);
            this.groupBox4.Location = new System.Drawing.Point(3, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 90);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // checkBoxAddChangePasswordItem
            // 
            this.checkBoxAddChangePasswordItem.AutoSize = true;
            this.checkBoxAddChangePasswordItem.Location = new System.Drawing.Point(19, 19);
            this.checkBoxAddChangePasswordItem.Name = "checkBoxAddChangePasswordItem";
            this.checkBoxAddChangePasswordItem.Size = new System.Drawing.Size(261, 17);
            this.checkBoxAddChangePasswordItem.TabIndex = 1;
            this.checkBoxAddChangePasswordItem.Text = "Add \'Change Password\' to the entry context menu";
            this.checkBoxAddChangePasswordItem.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(297, 268);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Map Fields";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.groupBox12.Size = new System.Drawing.Size(290, 263);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Settings";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Additional options from";
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
            this.buttonApply.Location = new System.Drawing.Point(238, 313);
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
            this.buttonCancel.Location = new System.Drawing.Point(157, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(76, 313);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxDisableCLIPasswordForPutty
            // 
            this.checkBoxDisableCLIPasswordForPutty.AutoSize = true;
            this.checkBoxDisableCLIPasswordForPutty.Location = new System.Drawing.Point(19, 65);
            this.checkBoxDisableCLIPasswordForPutty.Name = "checkBoxDisableCLIPasswordForPutty";
            this.checkBoxDisableCLIPasswordForPutty.Size = new System.Drawing.Size(170, 17);
            this.checkBoxDisableCLIPasswordForPutty.TabIndex = 2;
            this.checkBoxDisableCLIPasswordForPutty.Text = "Disable CLI password for Putty";
            this.checkBoxDisableCLIPasswordForPutty.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(329, 342);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{title} Options";
            this.tabControl.ResumeLayout(false);
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
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVSpherePowerCLIStatusIcon)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPsPasswdPathWarningIcon)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConfigureSSHClientPath;
        private System.Windows.Forms.TextBox textBoxSSHClientPath;
        private System.Windows.Forms.TabPage tabPage3;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBoxPsPasswdPathWarningIcon;
        private System.Windows.Forms.Label labelPsPasswdPathWarningMessage;
        private System.Windows.Forms.Button buttonConfigurePsPasswdPath;
        private System.Windows.Forms.TextBox textBoxPsPasswdPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxAddChangePasswordItem;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pictureBoxVSpherePowerCLIStatusIcon;
        private System.Windows.Forms.Label labelVSpherePowerCLIStatusMessage;
        private System.Windows.Forms.CheckBox checkBoxDisableCLIPasswordForPutty;
    }
}