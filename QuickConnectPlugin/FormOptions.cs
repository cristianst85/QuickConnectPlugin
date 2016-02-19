using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuickConnectPlugin {

    public partial class FormOptions : Form {

        private IQuickConnectPluginSettings settings;

        public FormOptions(String pluginName, IQuickConnectPluginSettings settings, ICollection<String> dbFields) {

            InitializeComponent();

            this.settings = settings;

            this.Text = this.Text.Replace("{title}", pluginName);

            this.checkBoxEnable.Checked = settings.Enabled;
            this.checkBoxCompatibleMode.Checked = settings.CompatibleMode;

            this.textBoxSSHClientPath.Text = settings.SSHClientPath;
            this.textBoxSSHClientPath.Select(this.textBoxSSHClientPath.Text.Length, 0);

            if (String.IsNullOrEmpty(settings.SSHClientPath) && !File.Exists(settings.SSHClientPath)) {
                // TODO: Add tooltip.
            }

            // Always add empty items.
            this.comboBoxHostAddressMapFieldName.Items.Add(String.Empty);
            this.comboBoxConnectionMethodMapFieldName.Items.Add(String.Empty);

            if (dbFields == null) {
                this.labelWarningMessage.Visible = true;
                this.comboBoxHostAddressMapFieldName.Enabled = false;
                this.comboBoxConnectionMethodMapFieldName.Enabled = false;

                if (!String.IsNullOrEmpty(settings.HostAddressMapFieldName)) {
                    this.comboBoxHostAddressMapFieldName.Items.Add(settings.HostAddressMapFieldName);
                }
                if (!String.IsNullOrEmpty(settings.ConnectionMethodMapFieldName)) {
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(settings.ConnectionMethodMapFieldName);
                }

                this.comboBoxHostAddressMapFieldName.SelectedValue = settings.HostAddressMapFieldName;
                this.comboBoxConnectionMethodMapFieldName.SelectedValue = settings.ConnectionMethodMapFieldName;
            }
            else {
                this.labelWarningMessage.Visible = false;
                foreach (var field in dbFields) {
                    this.comboBoxHostAddressMapFieldName.Items.Add(field);
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(field);
                }
            }

            if (String.IsNullOrEmpty(settings.HostAddressMapFieldName)) {
                this.comboBoxHostAddressMapFieldName.SelectedValue = String.Empty;
            }
            else {
                this.comboBoxHostAddressMapFieldName.SelectedIndex =
                    this.comboBoxHostAddressMapFieldName.FindStringExact(this.settings.HostAddressMapFieldName);
            }
            if (String.IsNullOrEmpty(settings.ConnectionMethodMapFieldName)) {
                this.comboBoxConnectionMethodMapFieldName.SelectedValue = String.Empty;
            }
            else {
                this.comboBoxConnectionMethodMapFieldName.SelectedIndex =
                    this.comboBoxConnectionMethodMapFieldName.FindStringExact(this.settings.ConnectionMethodMapFieldName);
            }

            // Add handlers.
            this.checkBoxEnable.CheckedChanged += new EventHandler(settingsChanged);
            this.checkBoxCompatibleMode.CheckedChanged += new EventHandler(settingsChanged);
            this.textBoxSSHClientPath.TextChanged += new EventHandler(settingsChanged);
            this.comboBoxHostAddressMapFieldName.SelectedIndexChanged += new EventHandler(settingsChanged);
            this.comboBoxConnectionMethodMapFieldName.SelectedIndexChanged += new EventHandler(settingsChanged);
            
            this.buttonApply.Enabled = false;
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            this.saveSettings();
            this.buttonApply.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (this.buttonApply.Enabled) {
                this.saveSettings();
            }
            this.Close();
        }

        private void saveSettings() {
            this.settings.Enabled = this.checkBoxEnable.Checked;
            this.settings.CompatibleMode = this.checkBoxCompatibleMode.Checked;
            this.settings.SSHClientPath = this.textBoxSSHClientPath.Text;
            this.settings.HostAddressMapFieldName = (String)this.comboBoxHostAddressMapFieldName.SelectedItem;
            this.settings.ConnectionMethodMapFieldName = (String)this.comboBoxConnectionMethodMapFieldName.SelectedItem;
            this.settings.Save();
        }

        private bool isSSHClientPathValid() {
            if (this.textBoxSSHClientPath.Text.Length == 0 || !File.Exists(this.textBoxSSHClientPath.Text)) {
                // Allow path to be empty.
                return (this.textBoxSSHClientPath.Text.Length == 0);
            }
            else {
                this.textBoxSSHClientPath.BackColor = default(Color);
                return true;
            }
        }

        private void settingsChanged(Object sender, EventArgs e) {
            if (validateSettings()) {
                this.buttonApply.Enabled = true;
            }
            else {
                this.buttonApply.Enabled = false;
            }
        }

        private bool validateSettings() {
            return isSSHClientPathValid();
        }

        private void buttonConfigureSSHClientPath_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Multiselect = false;
                if (File.Exists(this.buttonConfigureSSHClientPath.Text)) {
                    openFileDialog.FileName = this.textBoxSSHClientPath.Text;
                }
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "PuTTY executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select SSH Client Path";
                DialogResult result = openFileDialog.ShowDialog();
                if (!String.IsNullOrEmpty(openFileDialog.FileName)) {
                    this.textBoxSSHClientPath.Text = openFileDialog.FileName;
                    this.textBoxSSHClientPath.Select(this.textBoxSSHClientPath.Text.Length, 0);
                }
            }
        }
    }
}
