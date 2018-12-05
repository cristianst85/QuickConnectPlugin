using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using QuickConnectPlugin.PasswordChanger;

namespace QuickConnectPlugin {

    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public partial class FormOptions : Form {

        private IQuickConnectPluginSettings settings;

        public FormOptions(String pluginName, IQuickConnectPluginSettings settings, ICollection<String> dbFields) {

            InitializeComponent();

            this.settings = settings;

            this.Text = this.Text.Replace("{title}", pluginName);

            this.checkBoxEnable.Checked = settings.Enabled;
            this.checkBoxCompatibleMode.Checked = settings.CompatibleMode;
            this.checkBoxAddChangePasswordItem.Checked = settings.AddChangePasswordMenuItem;
            this.checkBoxDisableCLIPasswordForPutty.Checked = settings.DisableCLIPasswordForPutty;

            this.textBoxSSHClientPath.Text = settings.SSHClientPath;
            this.textBoxSSHClientPath.Select(this.textBoxSSHClientPath.Text.Length, 0);

            this.textBoxWinScpPath.Text = settings.WinScpPath;
            this.textBoxWinScpPath.Select(this.textBoxWinScpPath.Text.Length, 0);

            this.textBoxPsPasswdPath.Text = settings.PsPasswdPath;
            this.textBoxPsPasswdPath.Select(this.textBoxPsPasswdPath.Text.Length, 0);

            // Always add empty items.
            this.comboBoxHostAddressMapFieldName.Items.Add(String.Empty);
            this.comboBoxConnectionMethodMapFieldName.Items.Add(String.Empty);
            this.comboBoxAdditionalOptionsMapFieldName.Items.Add(String.Empty);

            if (dbFields == null) {
                this.labelWarningMessage.Visible = true;
                this.comboBoxHostAddressMapFieldName.Enabled = false;
                this.comboBoxConnectionMethodMapFieldName.Enabled = false;
                this.comboBoxAdditionalOptionsMapFieldName.Enabled = false;

                if (!String.IsNullOrEmpty(settings.HostAddressMapFieldName)) {
                    this.comboBoxHostAddressMapFieldName.Items.Add(settings.HostAddressMapFieldName);
                }
                if (!String.IsNullOrEmpty(settings.ConnectionMethodMapFieldName)) {
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(settings.ConnectionMethodMapFieldName);
                }
                if (!String.IsNullOrEmpty(settings.AdditionalOptionsMapFieldName)) {
                    this.comboBoxAdditionalOptionsMapFieldName.Items.Add(settings.AdditionalOptionsMapFieldName);
                }

                this.comboBoxHostAddressMapFieldName.SelectedValue = settings.HostAddressMapFieldName;
                this.comboBoxConnectionMethodMapFieldName.SelectedValue = settings.ConnectionMethodMapFieldName;
                this.comboBoxAdditionalOptionsMapFieldName.SelectedValue = settings.AdditionalOptionsMapFieldName;
            }
            else {
                this.labelWarningMessage.Visible = false;
                foreach (var field in dbFields) {
                    this.comboBoxHostAddressMapFieldName.Items.Add(field);
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(field);
                    this.comboBoxAdditionalOptionsMapFieldName.Items.Add(field);
                }
            }

            if (String.IsNullOrEmpty(settings.HostAddressMapFieldName)) {
                this.comboBoxHostAddressMapFieldName.SelectedIndex = this.comboBoxHostAddressMapFieldName.FindStringExact(String.Empty);
            }
            else {
                this.comboBoxHostAddressMapFieldName.SelectedIndex =
                    this.comboBoxHostAddressMapFieldName.FindStringExact(this.settings.HostAddressMapFieldName);
            }
            if (String.IsNullOrEmpty(settings.ConnectionMethodMapFieldName)) {
                this.comboBoxConnectionMethodMapFieldName.SelectedIndex = this.comboBoxConnectionMethodMapFieldName.FindStringExact(String.Empty);
            }
            else {
                this.comboBoxConnectionMethodMapFieldName.SelectedIndex =
                    this.comboBoxConnectionMethodMapFieldName.FindStringExact(this.settings.ConnectionMethodMapFieldName);
            }
            if (String.IsNullOrEmpty(settings.AdditionalOptionsMapFieldName)) {
                this.comboBoxAdditionalOptionsMapFieldName.SelectedIndex = this.comboBoxAdditionalOptionsMapFieldName.FindStringExact(String.Empty);
            }
            else {
                this.comboBoxAdditionalOptionsMapFieldName.SelectedIndex =
                    this.comboBoxAdditionalOptionsMapFieldName.FindStringExact(this.settings.AdditionalOptionsMapFieldName);
            }

            // Add handlers.
            this.checkBoxEnable.CheckedChanged += new EventHandler(settingsChanged);
            this.checkBoxCompatibleMode.CheckedChanged += new EventHandler(settingsChanged);
            this.checkBoxAddChangePasswordItem.CheckedChanged += new EventHandler(settingsChanged);
            this.checkBoxDisableCLIPasswordForPutty.CheckedChanged += new EventHandler(settingsChanged);
            this.textBoxSSHClientPath.TextChanged += new EventHandler(settingsChanged);
            this.textBoxWinScpPath.TextChanged += new EventHandler(settingsChanged);
            this.textBoxPsPasswdPath.TextChanged += new EventHandler(settingsChanged);
            this.comboBoxHostAddressMapFieldName.SelectedIndexChanged += new EventHandler(settingsChanged);
            this.comboBoxConnectionMethodMapFieldName.SelectedIndexChanged += new EventHandler(settingsChanged);
            this.comboBoxAdditionalOptionsMapFieldName.SelectedIndexChanged += new EventHandler(settingsChanged);

            this.buttonApply.Enabled = false;

            // Check if VMware VSphere PowerCLI is installed.
            this.checkVSpherePowerCLIStatus();
            // Force settings validation.
            this.validateSettings();
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
            this.settings.DisableCLIPasswordForPutty = this.checkBoxDisableCLIPasswordForPutty.Checked;
            this.settings.AddChangePasswordMenuItem = this.checkBoxAddChangePasswordItem.Checked;
            this.settings.SSHClientPath = this.textBoxSSHClientPath.Text;
            this.settings.WinScpPath = this.textBoxWinScpPath.Text;
            this.settings.PsPasswdPath = this.textBoxPsPasswdPath.Text;
            this.settings.HostAddressMapFieldName = (String)this.comboBoxHostAddressMapFieldName.SelectedItem;
            this.settings.ConnectionMethodMapFieldName = (String)this.comboBoxConnectionMethodMapFieldName.SelectedItem;
            this.settings.AdditionalOptionsMapFieldName = (String)this.comboBoxAdditionalOptionsMapFieldName.SelectedItem;
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

        private bool isWinScpPathValid() {
            if (this.textBoxWinScpPath.Text.Length == 0 || !File.Exists(this.textBoxWinScpPath.Text)) {
                // Allow path to be empty.
                return (this.textBoxWinScpPath.Text.Length == 0);
            }
            else {
                this.textBoxWinScpPath.BackColor = default(Color);
                return true;
            }
        }

        private bool isPsPasswdPathValid() {
            if (this.textBoxPsPasswdPath.Text.Length == 0) {
                this.pictureBoxPsPasswdPathWarningIcon.Visible = false;
                this.labelPsPasswdPathWarningMessage.Visible = false;
                this.textBoxPsPasswdPath.BackColor = default(Color);
                return true;
            }
            else {
                this.pictureBoxPsPasswdPathWarningIcon.Visible = true;
                this.labelPsPasswdPathWarningMessage.Visible = true;
                if (File.Exists(this.textBoxPsPasswdPath.Text)) {
                    if (!PsPasswdWrapper.IsPsPasswdUtility(this.textBoxPsPasswdPath.Text)) {
                        this.labelPsPasswdPathWarningMessage.Text = String.Format("Specified file is not valid.");
                        return false;
                    }
                    else if (!PsPasswdWrapper.IsSupportedVersion(this.textBoxPsPasswdPath.Text)) {
                        this.labelPsPasswdPathWarningMessage.Text = String.Format("Only version {0} is supported.", PsPasswdWrapper.SupportedVersion);
                        return false;
                    }
                    else {
                        this.pictureBoxPsPasswdPathWarningIcon.Visible = false;
                        this.labelPsPasswdPathWarningMessage.Visible = false;
                        return true;
                    }
                }
                else {
                    this.pictureBoxPsPasswdPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
                    this.labelPsPasswdPathWarningMessage.Text = "Specified path does not exists.";
                    return false;
                }
            }
        }

        private void settingsChanged(Object sender, EventArgs e) {
            this.buttonApply.Enabled = validateSettings();
        }

        private bool validateSettings() {
            bool isValidSSHClientPath = isSSHClientPathValid();
            this.pictureBoxSSHClientPathWarningIcon.Visible = !isValidSSHClientPath;
            this.labelSSHClientPathWarningMessage.Visible = !isValidSSHClientPath;

            bool isValidWinScpPath = isWinScpPathValid();
            this.pictureBoxWinScpPathWarningIcon.Visible = !isValidWinScpPath;
            this.labelWinScpPathWarningMessage.Visible = !isValidWinScpPath;

            return isValidSSHClientPath && isValidWinScpPath && isPsPasswdPathValid();
        }

        private void buttonConfigureSSHClientPath_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Multiselect = false;
                if (File.Exists(this.textBoxSSHClientPath.Text)) {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxSSHClientPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxSSHClientPath.Text);
                }
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "PuTTY executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select SSH Client Path";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK && !String.IsNullOrEmpty(openFileDialog.FileName)) {
                    this.textBoxSSHClientPath.Text = openFileDialog.FileName;
                    this.textBoxSSHClientPath.Select(this.textBoxSSHClientPath.Text.Length, 0);
                }
            }
        }

        private void buttonConfigureWinScpPath_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Multiselect = false;
                if (File.Exists(this.textBoxWinScpPath.Text)) {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxWinScpPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxWinScpPath.Text);
                }
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "WinSCP executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select WinSCP Path";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK && !String.IsNullOrEmpty(openFileDialog.FileName)) {
                    this.textBoxWinScpPath.Text = openFileDialog.FileName;
                    this.textBoxWinScpPath.Select(this.textBoxWinScpPath.Text.Length, 0);
                }
            }
        }

        private void buttonConfigurePsPasswdPath_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Multiselect = false;
                if (File.Exists(this.textBoxPsPasswdPath.Text)) {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxPsPasswdPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxPsPasswdPath.Text);
                }
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "PsPasswd executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select PsPasswd Path";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK && !String.IsNullOrEmpty(openFileDialog.FileName)) {
                    this.textBoxPsPasswdPath.Text = openFileDialog.FileName;
                    this.textBoxPsPasswdPath.Select(this.textBoxPsPasswdPath.Text.Length, 0);
                }
            }
        }

        private void checkVSpherePowerCLIStatus() {
            var status = QuickConnectUtils.IsVSpherePowerCLIInstalled();
            this.labelVSpherePowerCLIStatusMessage.Text = this.labelVSpherePowerCLIStatusMessage.Text.Replace("{status}",
                status ? "installed" : "not installed"
            );
            if (status) {
                this.pictureBoxVSpherePowerCLIStatusIcon.Image = global::QuickConnectPlugin.Properties.Resources.success;
            }
        }
    }
}
