using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using QuickConnectPlugin.Commons;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;

namespace QuickConnectPlugin {

    public partial class FormBatchPasswordChanger : Form {

        private IPasswordChangerServiceFactory pwChangerServiceFactory;
        private BatchPasswordChangerWorker pwChangerWorker;

        public FormBatchPasswordChanger(
            IPasswordChangerTreeNode pwChangerTreeNode,
            IPasswordChangerServiceFactory pwChangerServiceFactory
            ) {

            InitializeComponent();

            this.pwChangerServiceFactory = pwChangerServiceFactory;

            // Smooth resize.
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable) {
                this.treeView.Dock = DockStyle.Fill;
                this.listView.Dock = DockStyle.Fill;
                this.splitContainer.IsSplitterFixed = false;
            }
            else {
                this.splitContainer.IsSplitterFixed = true;
            }

            this.buttonStartChangePasswords.Enabled = false;
            this.checkBoxOverrideHostType.Checked = false;
            this.comboBoxHostType.Enabled = false;
            this.toolStripMenuItemSaveLogAs.Enabled = false;
            this.toolStripMenuItemClearLog.Enabled = false;

            foreach (var hostType in this.pwChangerServiceFactory.GetSupported()) {
                this.comboBoxHostType.Items.Add(hostType);
            }
            this.checkBoxOverrideHostType.Enabled = this.comboBoxHostType.Items.Count > 0;

            this.listView.FullRowSelect = true;

            this.treeView.Nodes.Add(pwChangerTreeNode.Root);
            this.treeView.Nodes[0].Expand();
            this.treeView.AfterSelect += new TreeViewEventHandler(treeViewAfterSelect);

            ContextMenuStrip listViewContextMenuStrip = new ContextMenuStrip();
            listViewContextMenuStrip.Items.Add("Select all");
            listViewContextMenuStrip.Items.Add("Deselect all");
            listViewContextMenuStrip.Items[0].Click += new EventHandler(selectAllClick);
            listViewContextMenuStrip.Items[1].Click += new EventHandler(deselectAllClick);
            this.listView.ContextMenuStrip = listViewContextMenuStrip;

            this.toolStripMenuItemSaveLogAs.Click += new EventHandler(saveLogAsClick);
            this.toolStripMenuItemClearLog.Click += new EventHandler(clearLogClick);

            this.maskedTextBoxNewPassword.TextChanged += new EventHandler(checkPasswords);
            this.maskedTextBoxRepeatNewPassword.TextChanged += new EventHandler(checkPasswords);
            this.checkBoxOverrideHostType.Click += new EventHandler(overrideHostTypeClick);
            this.buttonStartChangePasswords.Click += new EventHandler(startChangePasswordsClick);
            this.textBox.TextChanged += new EventHandler(textBoxTextChanged);

            this.listView.ItemChecked += new ItemCheckedEventHandler(checkControls);
            this.maskedTextBoxNewPassword.TextChanged += new EventHandler(checkControls);
            this.maskedTextBoxRepeatNewPassword.TextChanged += new EventHandler(checkControls);
            this.checkBoxOverrideHostType.CheckStateChanged += new EventHandler(checkControls);
            this.comboBoxHostType.SelectedIndexChanged += new EventHandler(checkControls);

            this.FormClosing += new FormClosingEventHandler(formClosing);
        }

        private bool showPasswordIsChecked() {
            Debug.WriteLine("showPasswordIsChecked");
            var viewMenuItem = this.menuStrip.Items[1] as ToolStripMenuItem;
            ToolStripMenuItem showPasswordsMenuItem = viewMenuItem.DropDownItems[1] as ToolStripMenuItem;
            return showPasswordsMenuItem != null && showPasswordsMenuItem.Checked;
        }

        private void toogleControls(bool state) {
            this.treeView.Enabled = state;
            this.listView.Enabled = state;
            this.checkBoxOverrideHostType.Enabled = state && this.comboBoxHostType.Items.Count > 0;
            this.comboBoxHostType.Enabled = state && this.checkBoxOverrideHostType.Checked;
            this.maskedTextBoxNewPassword.Enabled = state;
            this.maskedTextBoxRepeatNewPassword.Enabled = state;
            this.buttonStartChangePasswords.Enabled = state;
            this.buttonShowHidePassword.Enabled = state;
        }

        private bool isHostTypeConfigured() {
            if (!this.checkBoxOverrideHostType.Checked) {
                return true;
            }
            else {
                return (this.comboBoxHostType.SelectedIndex > -1);
            }
        }

        private void overrideHostTypeClick(object sender, EventArgs e) {
            this.comboBoxHostType.Enabled = this.checkBoxOverrideHostType.Checked;
        }

        private void selectAllClick(object sender, EventArgs e) {
            foreach (ListViewItem item in this.listView.Items) {
                item.Checked = true;
            }
        }

        private void deselectAllClick(object sender, EventArgs e) {
            foreach (ListViewItem item in this.listView.Items) {
                item.Checked = false;
            }
        }

        private void showPasswordsClick(object sender, EventArgs e) {
            foreach (var item in this.listView.Items) {
                PwEntryListViewItem pwEntryItem = item as PwEntryListViewItem;
                if (pwEntryItem != null) {
                    pwEntryItem.UpdatePassword(this.showPasswordIsChecked());
                };
            }
        }

        private void treeViewAfterSelect(object sender, TreeViewEventArgs e) {
            Debug.WriteLine("treeViewAfterSelect");
            IPasswordChangerTreeNode treeNode = e.Node as IPasswordChangerTreeNode;
            if (treeNode != null) {
                bool showPassword = this.showPasswordIsChecked();
                this.listView.Items.Clear();
                foreach (var pwEntry in treeNode.GetEntries()) {
                    PwEntryListViewItem item = new PwEntryListViewItem(pwEntry, showPassword);
                    this.listView.Items.Add(item);
                }
            }
        }

        private void saveLogAsClick(object sender, EventArgs e) {
            using (var dialog = new SaveFileDialog()) {
                dialog.Title = "Save Log As";
                dialog.Filter = "Log file (*.log)|*.log";
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = String.Format("{0}-{1:yyyyMMdd}.log", AssemblyUtils.GetExecutingAssemblyName(), DateTime.Now);
                var dialogResult = dialog.ShowDialog();
                if (dialog.FileName.Length > 0) {
                    try {
                        File.WriteAllText(dialog.FileName, this.textBox.Text);
                        MessageBox.Show("The log file was saved successfully.", "Save Log As",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(String.Format("Error saving log file.\n\nError details: {0}", ex.Message), "Save Log As",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void clearLogClick(object sender, EventArgs e) {
            this.textBox.Clear();
        }

        private void formClosing(object sender, FormClosingEventArgs e) {
            Debug.WriteLine("formClosing");
            if (this.pwChangerWorker != null && this.pwChangerWorker.IsRunning) {
                MessageBox.Show(
                    "Password changing is currently running. Press Stop button and wait for the current task to finish before closing the form.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                e.Cancel = true;
            }
        }

        private void textBoxTextChanged(object sender, EventArgs e) {
            this.toolStripMenuItemSaveLogAs.Enabled = (this.textBox.Text.Length > 0);
            this.toolStripMenuItemClearLog.Enabled = (this.textBox.Text.Length > 0);
        }

        private void startChangePasswordsClick(object sender, EventArgs e) {
            if (this.buttonStartChangePasswords.Text.Equals("Stop")) {
                if (this.pwChangerWorker != null && this.pwChangerWorker.IsRunning) {
                    this.buttonStartChangePasswords.Text = "Stopping...";
                    this.buttonStartChangePasswords.Enabled = false;
                    this.pwChangerWorker.Cancel();
                }
            }
            else {
                Debug.WriteLine("buttonStartChangePasswordsClick");
                if (this.pwChangerWorker == null || !this.pwChangerWorker.IsRunning) {
                    this.toogleControls(false);
                    var selectedEntries = getSelectedEntries();
                    // Reset progress bar in case batchPasswordChangerWorker was run before.
                    this.progressBar.Value = 0;
                    this.progressBar.Maximum = selectedEntries.Count;
                    Debug.WriteLine(String.Format("selectedEntries.Count: {0}", selectedEntries.Count));
                    var hostTypeMapper = this.checkBoxOverrideHostType.Checked && this.comboBoxHostType.SelectedIndex > -1 ?
                        (IHostTypeMapper)new FixedHostTypeMapper((HostType)this.comboBoxHostType.SelectedItem) :
                        new HostTypeMapper();
                    var passwordChangerService = this.pwChangerServiceFactory.Create(hostTypeMapper);
                    this.pwChangerWorker = new BatchPasswordChangerWorker(passwordChangerService, selectedEntries, maskedTextBoxNewPassword.Text);
                    var thread = new Thread(new ThreadStart(() => runBatchPasswordChangerWorker(passwordChangerService)));
                    thread.Name = "FormBatchPasswordChangerThread";
                    thread.IsBackground = true;
                    thread.Start();
                    this.buttonStartChangePasswords.Text = "Stop";
                    this.buttonStartChangePasswords.Enabled = true;
                }
            }
        }

        private ICollection<IHostPwEntry> getSelectedEntries() {
            var entries = new Collection<IHostPwEntry>();
            foreach (ListViewItem item in this.listView.Items) {
                var pwItem = item as PwEntryListViewItem;
                if (pwItem != null && item.Checked) {
                    entries.Add(pwItem.PwEntry);
                }
            }
            return entries;
        }

        private void runBatchPasswordChangerWorker(IPasswordChangerService passwordChangerService) {
            Debug.WriteLine("runBatchPasswordChangerWorker");
            this.pwChangerWorker.SaveDatabaseAfterEachUpdate = true;
            this.pwChangerWorker.Changed += new PasswordChangedEventHandler(batchPasswordChangerWorkerChanged);
            this.pwChangerWorker.Error += new PasswordChangeErrorEventHandler(batchPasswordChangerWorkerError);
            this.pwChangerWorker.Completed += new PasswordChangeCompletedEventHandler(batchPasswordChangerWorkerCompleted);
            this.pwChangerWorker.Run();
        }

        public void batchPasswordChangerWorkerChanged(object sender, BatchPasswordChangerEventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerChanged");
            this.Invoke((MethodInvoker)delegate {
                foreach (var item in this.listView.Items) {
                    PwEntryListViewItem pwEntryItem = item as PwEntryListViewItem;
                    if (pwEntryItem != null && e.HostPwEntry.Equals(pwEntryItem.PwEntry)) {
                        pwEntryItem.UpdatePassword(this.showPasswordIsChecked());
                        pwEntryItem.Checked = false;
                        this.log(String.Format("Password successfully changed for {0} on host {1}.", e.HostPwEntry.GetUsername(), e.HostPwEntry.IPAddress), true);
                        this.progressBar.Value = e.ProcessedEntries;
                    };
                }
            });
        }

        public void batchPasswordChangerWorkerError(object sender, BatchPasswordChangerErrorEventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerError");
            this.Invoke((MethodInvoker)delegate {
                this.log(e.Exception.ToString(), true);
                this.progressBar.Value = e.ProcessedEntries;
            });
        }

        private void log(String message, bool appendEOL) {
            if (this.textBox != null) {
                if (appendEOL) {
                    message += "\r\n";
                }
                if (this.textBox.Text.Length == 0 || this.textBox.Text.EndsWith("\r\n")) {
                    this.textBox.AppendText(String.Format("[{0:yyyy-MM-dd HH:mm:ss}] {1}", DateTime.Now, message));
                }
                else {
                    this.textBox.AppendText(String.Format(" {0}", message));
                }
            }
        }

        public void batchPasswordChangerWorkerCompleted(object sender, EventArgs e) {
            Debug.WriteLine("batchPasswordChangerWorkerCompleted");
            this.pwChangerWorker = null;
            this.Invoke((MethodInvoker)delegate {
                this.toogleControls(true);
                this.checkControls();
                this.buttonStartChangePasswords.Text = "Start Change Passwords";
            });
        }

        private void buttonShowHidePasswordClick(object sender, EventArgs e) {
            Debug.WriteLine("buttonShowHidePassword_Click");
            this.maskedTextBoxNewPassword.UseSystemPasswordChar = !this.maskedTextBoxNewPassword.UseSystemPasswordChar;
            this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar = !this.maskedTextBoxRepeatNewPassword.UseSystemPasswordChar;
            if (this.maskedTextBoxNewPassword.UseSystemPasswordChar) {
                this.maskedTextBoxRepeatNewPassword.Text = this.maskedTextBoxNewPassword.Text;
            }
            else {
                this.maskedTextBoxRepeatNewPassword.Text = String.Empty;
                this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
            }
            this.checkControls();
        }

        private void checkControls(object sender, EventArgs e) {
            this.checkControls();
        }

        private void checkControls() {
            Debug.WriteLine("checkControls");
            if (this.pwChangerWorker != null && this.pwChangerWorker.IsRunning) {
                return;
            }
            if (this.getSelectedEntries().Count > 0 &&
                (this.maskedTextBoxNewPassword.UseSystemPasswordChar && this.passwordsMatch() ||
                !this.maskedTextBoxNewPassword.UseSystemPasswordChar && TextBoxUtils.HasText(this.maskedTextBoxNewPassword)) &&
                this.isHostTypeConfigured()) {
                this.buttonStartChangePasswords.Enabled = true;
            }
            else {
                this.buttonStartChangePasswords.Enabled = false;
            }
            this.maskedTextBoxRepeatNewPassword.Enabled = this.maskedTextBoxNewPassword.UseSystemPasswordChar;
        }

        private bool passwordsMatch() {
            Debug.WriteLine("passwordsMatch");
            return TextBoxUtils.HasText(this.maskedTextBoxNewPassword) &&
                this.maskedTextBoxNewPassword.Text.Equals(this.maskedTextBoxRepeatNewPassword.Text);
        }

        private void checkPasswords(object sender, EventArgs e) {
            Debug.WriteLine("checkPasswords");
            if (this.maskedTextBoxNewPassword.UseSystemPasswordChar) {
                if (TextBoxUtils.HasText(this.maskedTextBoxNewPassword) && this.passwordsMatch()) {
                    this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
                }
                else if (!TextBoxUtils.HasText(this.maskedTextBoxNewPassword) && !TextBoxUtils.HasText(this.maskedTextBoxRepeatNewPassword)) {
                    this.maskedTextBoxRepeatNewPassword.BackColor = Color.Empty;
                }
                else {
                    this.maskedTextBoxRepeatNewPassword.BackColor = ColorTranslator.FromHtml("#FFC0C0");
                }
            }
            else {
                this.maskedTextBoxNewPassword.ResetBackColor();
                this.maskedTextBoxRepeatNewPassword.ResetBackColor();
            }
        }
    }
}
