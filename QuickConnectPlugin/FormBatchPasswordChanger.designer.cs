using System.Windows.Forms;

namespace QuickConnectPlugin {

    partial class FormBatchPasswordChanger {
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonShowHidePassword = new System.Windows.Forms.Button();
            this.checkBoxOverrideHostType = new System.Windows.Forms.CheckBox();
            this.comboBoxHostType = new System.Windows.Forms.ComboBox();
            this.labelHostType = new System.Windows.Forms.Label();
            this.maskedTextBoxRepeatNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.labelRepeatNewPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStartChangePasswords = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSaveLogAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowEntriesOfSubgroups = new System.Windows.Forms.ToolStripMenuItem();
            this.showPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(15, 286);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(788, 113);
            this.textBox.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(202, 239);
            this.treeView.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1.Controls.Add(this.menuStrip2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBox);
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(795, 250);
            this.splitContainer.SplitterDistance = 208;
            this.splitContainer.TabIndex = 4;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(208, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.buttonShowHidePassword);
            this.groupBox.Controls.Add(this.checkBoxOverrideHostType);
            this.groupBox.Controls.Add(this.comboBoxHostType);
            this.groupBox.Controls.Add(this.labelHostType);
            this.groupBox.Controls.Add(this.maskedTextBoxRepeatNewPassword);
            this.groupBox.Controls.Add(this.maskedTextBoxNewPassword);
            this.groupBox.Controls.Add(this.labelRepeatNewPassword);
            this.groupBox.Controls.Add(this.labelNewPassword);
            this.groupBox.Location = new System.Drawing.Point(3, 163);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(576, 79);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // buttonShowHidePassword
            // 
            this.buttonShowHidePassword.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonShowHidePassword.Location = new System.Drawing.Point(536, 19);
            this.buttonShowHidePassword.Name = "buttonShowHidePassword";
            this.buttonShowHidePassword.Size = new System.Drawing.Size(34, 20);
            this.buttonShowHidePassword.TabIndex = 12;
            this.buttonShowHidePassword.Text = "···";
            this.buttonShowHidePassword.UseVisualStyleBackColor = true;
            this.buttonShowHidePassword.Click += new System.EventHandler(this.buttonShowHidePasswordClick);
            // 
            // checkBoxOverrideHostType
            // 
            this.checkBoxOverrideHostType.AutoSize = true;
            this.checkBoxOverrideHostType.Location = new System.Drawing.Point(11, 21);
            this.checkBoxOverrideHostType.Name = "checkBoxOverrideHostType";
            this.checkBoxOverrideHostType.Size = new System.Drawing.Size(239, 17);
            this.checkBoxOverrideHostType.TabIndex = 2;
            this.checkBoxOverrideHostType.Text = "Override host system type for selected entries";
            this.checkBoxOverrideHostType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxOverrideHostType.UseVisualStyleBackColor = true;
            // 
            // comboBoxHostType
            // 
            this.comboBoxHostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHostType.FormattingEnabled = true;
            this.comboBoxHostType.Location = new System.Drawing.Point(106, 44);
            this.comboBoxHostType.Name = "comboBoxHostType";
            this.comboBoxHostType.Size = new System.Drawing.Size(137, 21);
            this.comboBoxHostType.TabIndex = 11;
            // 
            // labelHostType
            // 
            this.labelHostType.AutoSize = true;
            this.labelHostType.Location = new System.Drawing.Point(45, 48);
            this.labelHostType.Name = "labelHostType";
            this.labelHostType.Size = new System.Drawing.Size(55, 13);
            this.labelHostType.TabIndex = 10;
            this.labelHostType.Text = "Host type:";
            // 
            // maskedTextBoxRepeatNewPassword
            // 
            this.maskedTextBoxRepeatNewPassword.Location = new System.Drawing.Point(387, 45);
            this.maskedTextBoxRepeatNewPassword.Name = "maskedTextBoxRepeatNewPassword";
            this.maskedTextBoxRepeatNewPassword.Size = new System.Drawing.Size(143, 20);
            this.maskedTextBoxRepeatNewPassword.TabIndex = 7;
            this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar = true;
            // 
            // maskedTextBoxNewPassword
            // 
            this.maskedTextBoxNewPassword.Location = new System.Drawing.Point(387, 19);
            this.maskedTextBoxNewPassword.Name = "maskedTextBoxNewPassword";
            this.maskedTextBoxNewPassword.Size = new System.Drawing.Size(143, 20);
            this.maskedTextBoxNewPassword.TabIndex = 6;
            this.maskedTextBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // labelRepeatNewPassword
            // 
            this.labelRepeatNewPassword.AutoSize = true;
            this.labelRepeatNewPassword.Location = new System.Drawing.Point(265, 48);
            this.labelRepeatNewPassword.Name = "labelRepeatNewPassword";
            this.labelRepeatNewPassword.Size = new System.Drawing.Size(116, 13);
            this.labelRepeatNewPassword.TabIndex = 5;
            this.labelRepeatNewPassword.Text = "Repeat new password:";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(301, 22);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(80, 13);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "New password:";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.username,
            this.password,
            this.ipAddress,
            this.hostType});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(576, 154);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 116;
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 106;
            // 
            // password
            // 
            this.password.Text = "Password";
            this.password.Width = 115;
            // 
            // ipAddress
            // 
            this.ipAddress.Text = "IP Address";
            this.ipAddress.Width = 115;
            // 
            // hostType
            // 
            this.hostType.Text = "Host Type";
            this.hostType.Width = 68;
            // 
            // buttonStartChangePasswords
            // 
            this.buttonStartChangePasswords.Location = new System.Drawing.Point(665, 405);
            this.buttonStartChangePasswords.Name = "buttonStartChangePasswords";
            this.buttonStartChangePasswords.Size = new System.Drawing.Size(138, 25);
            this.buttonStartChangePasswords.TabIndex = 3;
            this.buttonStartChangePasswords.Text = "Start Change Passwords";
            this.buttonStartChangePasswords.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLog,
            this.toolStripMenuItemView});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(819, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemLog
            // 
            this.toolStripMenuItemLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItemSaveLogAs,
            this.toolStripMenuItemClearLog});
            this.toolStripMenuItemLog.Name = "toolStripMenuItemLog";
            this.toolStripMenuItemLog.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemLog.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripMenuItemSaveLogAs
            // 
            this.toolStripMenuItemSaveLogAs.Name = "toolStripMenuItemSaveLogAs";
            this.toolStripMenuItemSaveLogAs.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemSaveLogAs.Text = "&Save Log As...";
            // 
            // toolStripMenuItemClearLog
            // 
            this.toolStripMenuItemClearLog.Name = "toolStripMenuItemClearLog";
            this.toolStripMenuItemClearLog.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemClearLog.Text = "Clear Log";
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowEntriesOfSubgroups,
            this.showPasswordsToolStripMenuItem});
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemView.Text = "View";
            // 
            // toolStripMenuItemShowEntriesOfSubgroups
            // 
            this.toolStripMenuItemShowEntriesOfSubgroups.Name = "toolStripMenuItemShowEntriesOfSubgroups";
            this.toolStripMenuItemShowEntriesOfSubgroups.Size = new System.Drawing.Size(215, 22);
            this.toolStripMenuItemShowEntriesOfSubgroups.Text = "Show Entries of Subgroups";
            // 
            // showPasswordsToolStripMenuItem
            // 
            this.showPasswordsToolStripMenuItem.CheckOnClick = true;
            this.showPasswordsToolStripMenuItem.Name = "showPasswordsToolStripMenuItem";
            this.showPasswordsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showPasswordsToolStripMenuItem.Text = "Show Passwords";
            this.showPasswordsToolStripMenuItem.Click += new System.EventHandler(this.showPasswordsClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 405);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(644, 25);
            this.progressBar.TabIndex = 12;
            // 
            // FormBatchPasswordChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(819, 442);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonStartChangePasswords);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBatchPasswordChanger";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Password Changer";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonStartChangePasswords;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ColumnHeader ipAddress;
        private System.Windows.Forms.Label labelRepeatNewPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRepeatNewPassword;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNewPassword;
        private System.Windows.Forms.Label labelHostType;
        private System.Windows.Forms.ComboBox comboBoxHostType;
        private System.Windows.Forms.CheckBox checkBoxOverrideHostType;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLog;
        private MenuStrip menuStrip2;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItemSaveLogAs;
        private ToolStripMenuItem toolStripMenuItemClearLog;
        private ProgressBar progressBar;
        private ToolStripMenuItem toolStripMenuItemView;
        private ToolStripMenuItem toolStripMenuItemShowEntriesOfSubgroups;
        private ColumnHeader hostType;
        private ToolStripMenuItem showPasswordsToolStripMenuItem;
        private Button buttonShowHidePassword;
    }
}