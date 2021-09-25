using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.ShortcutKeys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;

using HotKeyControlEx = QuickConnect.KeePass.UI.HotKeyControlEx;

namespace QuickConnectPlugin
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public partial class FormOptions : Form
    {
        private readonly IQuickConnectPluginSettings settings;

        private readonly HotKeyControlEx shortcutKeyControlRemoteDesktop;
        private readonly HotKeyControlEx shortcutKeyControlPutty;
        private readonly HotKeyControlEx shortcutKeyControlWinScp;

        private bool shortcutKeysSettingWasChanged;

        public FormOptions(string pluginName, IQuickConnectPluginSettings settings, ICollection<string> dbFields)
        {
            InitializeComponent();

            this.settings = settings;

            this.Text = this.Text.Replace("{title}", pluginName);

            this.checkBoxEnable.Checked = settings.Enabled;
            this.checkBoxCompatibleMode.Checked = settings.CompatibleMode;
            this.checkBoxAddChangePasswordItem.Checked = settings.AddChangePasswordMenuItem;
            this.checkBoxDisableCLIPasswordForPutty.Checked = settings.DisableCLIPasswordForPutty;

            this.textBoxPuttyPath.Text = settings.PuttyPath;
            this.textBoxPuttyPath.Select(this.textBoxPuttyPath.Text.Length, 0);

            this.textBoxWinScpPath.Text = settings.WinScpPath;
            this.textBoxWinScpPath.Select(this.textBoxWinScpPath.Text.Length, 0);

            this.textBoxPsPasswdPath.Text = settings.PsPasswdPath;
            this.textBoxPsPasswdPath.Select(this.textBoxPsPasswdPath.Text.Length, 0);

            // Always add empty items.
            this.comboBoxHostAddressMapFieldName.Items.Add(string.Empty);
            this.comboBoxConnectionMethodMapFieldName.Items.Add(string.Empty);
            this.comboBoxAdditionalOptionsMapFieldName.Items.Add(string.Empty);

            if (dbFields == null)
            {
                this.labelWarningMessage.Visible = true;
                this.comboBoxHostAddressMapFieldName.Enabled = false;
                this.comboBoxConnectionMethodMapFieldName.Enabled = false;
                this.comboBoxAdditionalOptionsMapFieldName.Enabled = false;

                if (!string.IsNullOrEmpty(settings.HostAddressMapFieldName))
                {
                    this.comboBoxHostAddressMapFieldName.Items.Add(settings.HostAddressMapFieldName);
                }
                if (!string.IsNullOrEmpty(settings.ConnectionMethodMapFieldName))
                {
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(settings.ConnectionMethodMapFieldName);
                }
                if (!string.IsNullOrEmpty(settings.AdditionalOptionsMapFieldName))
                {
                    this.comboBoxAdditionalOptionsMapFieldName.Items.Add(settings.AdditionalOptionsMapFieldName);
                }

                this.comboBoxHostAddressMapFieldName.SelectedValue = settings.HostAddressMapFieldName;
                this.comboBoxConnectionMethodMapFieldName.SelectedValue = settings.ConnectionMethodMapFieldName;
                this.comboBoxAdditionalOptionsMapFieldName.SelectedValue = settings.AdditionalOptionsMapFieldName;
            }
            else
            {
                this.labelWarningMessage.Visible = false;

                foreach (var field in dbFields)
                {
                    this.comboBoxHostAddressMapFieldName.Items.Add(field);
                    this.comboBoxConnectionMethodMapFieldName.Items.Add(field);
                    this.comboBoxAdditionalOptionsMapFieldName.Items.Add(field);
                }
            }

            if (string.IsNullOrEmpty(settings.HostAddressMapFieldName))
            {
                this.comboBoxHostAddressMapFieldName.SelectedIndex = this.comboBoxHostAddressMapFieldName.FindStringExact(string.Empty);
            }
            else
            {
                this.comboBoxHostAddressMapFieldName.SelectedIndex = this.comboBoxHostAddressMapFieldName.FindStringExact(this.settings.HostAddressMapFieldName);
            }

            if (string.IsNullOrEmpty(settings.ConnectionMethodMapFieldName))
            {
                this.comboBoxConnectionMethodMapFieldName.SelectedIndex = this.comboBoxConnectionMethodMapFieldName.FindStringExact(string.Empty);
            }
            else
            {
                this.comboBoxConnectionMethodMapFieldName.SelectedIndex = this.comboBoxConnectionMethodMapFieldName.FindStringExact(this.settings.ConnectionMethodMapFieldName);
            }

            if (string.IsNullOrEmpty(settings.AdditionalOptionsMapFieldName))
            {
                this.comboBoxAdditionalOptionsMapFieldName.SelectedIndex = this.comboBoxAdditionalOptionsMapFieldName.FindStringExact(string.Empty);
            }
            else
            {
                this.comboBoxAdditionalOptionsMapFieldName.SelectedIndex = this.comboBoxAdditionalOptionsMapFieldName.FindStringExact(this.settings.AdditionalOptionsMapFieldName);
            }

            // Shortcut Keys.
            checkBoxEnableShortcutKeys.Checked = settings.EnableShortcutKeys ?? false;
            shortcutKeysSettingWasChanged = settings.EnableShortcutKeys ?? false;

            // KeePass v2.42 API breaking change.
            shortcutKeyControlRemoteDesktop = HotKeyControlEx.ReplaceTextBox(this.textBoxRDShortcutKey.Parent, this.textBoxRDShortcutKey, false);
            shortcutKeyControlRemoteDesktop.HotKey = (settings.EnableShortcutKeys.HasValue ? settings.RemoteDesktopShortcutKey : QuickConnectPluginSettings.DefaultRemoteDesktopShortcutKey) & Keys.KeyCode;
            shortcutKeyControlRemoteDesktop.HotKeyModifiers = (settings.EnableShortcutKeys.HasValue ? settings.RemoteDesktopShortcutKey : QuickConnectPluginSettings.DefaultRemoteDesktopShortcutKey) & Keys.Modifiers;
            shortcutKeyControlRemoteDesktop.RenderHotKey();
            shortcutKeyControlRemoteDesktop.Enabled = settings.EnableShortcutKeys ?? false;
            shortcutKeyControlRemoteDesktop.Show();

            shortcutKeyControlPutty = HotKeyControlEx.ReplaceTextBox(this.textBoxPuttyShortcutKey.Parent, this.textBoxPuttyShortcutKey, false);
            shortcutKeyControlPutty.HotKey = (settings.EnableShortcutKeys.HasValue ? settings.PuttyShortcutKey : QuickConnectPluginSettings.DefaultPuttyShortcutKey) & Keys.KeyCode;
            shortcutKeyControlPutty.HotKeyModifiers = (settings.EnableShortcutKeys.HasValue ? settings.PuttyShortcutKey : QuickConnectPluginSettings.DefaultPuttyShortcutKey) & Keys.Modifiers;
            shortcutKeyControlPutty.RenderHotKey();
            shortcutKeyControlPutty.Enabled = settings.EnableShortcutKeys ?? false;
            shortcutKeyControlPutty.Show();

            shortcutKeyControlWinScp = HotKeyControlEx.ReplaceTextBox(this.textBoxWinScpShortcutKey.Parent, this.textBoxWinScpShortcutKey, false);
            shortcutKeyControlWinScp.HotKey = (settings.EnableShortcutKeys.HasValue ? settings.WinScpShortcutKey : QuickConnectPluginSettings.DefaultWinScpShortcutKey) & Keys.KeyCode;
            shortcutKeyControlWinScp.HotKeyModifiers = (settings.EnableShortcutKeys.HasValue ? settings.WinScpShortcutKey : QuickConnectPluginSettings.DefaultWinScpShortcutKey) & Keys.Modifiers;
            shortcutKeyControlWinScp.RenderHotKey();
            shortcutKeyControlWinScp.Enabled = settings.EnableShortcutKeys ?? false;
            shortcutKeyControlWinScp.Show();

            // Add handlers.
            this.checkBoxEnable.CheckedChanged += new EventHandler(SettingsChanged);
            this.checkBoxCompatibleMode.CheckedChanged += new EventHandler(SettingsChanged);
            this.checkBoxAddChangePasswordItem.CheckedChanged += new EventHandler(SettingsChanged);
            this.checkBoxDisableCLIPasswordForPutty.CheckedChanged += new EventHandler(SettingsChanged);
            this.textBoxPuttyPath.TextChanged += new EventHandler(SettingsChanged);
            this.textBoxWinScpPath.TextChanged += new EventHandler(SettingsChanged);
            this.textBoxPsPasswdPath.TextChanged += new EventHandler(SettingsChanged);
            this.comboBoxHostAddressMapFieldName.SelectedIndexChanged += new EventHandler(SettingsChanged);
            this.comboBoxConnectionMethodMapFieldName.SelectedIndexChanged += new EventHandler(SettingsChanged);
            this.comboBoxAdditionalOptionsMapFieldName.SelectedIndexChanged += new EventHandler(SettingsChanged);

            this.checkBoxEnableShortcutKeys.CheckedChanged += new EventHandler(SettingsChanged);
            this.checkBoxEnableShortcutKeys.CheckedChanged += (o, e) => { shortcutKeysSettingWasChanged = true; };
            this.shortcutKeyControlRemoteDesktop.KeyUp += (s, e) => { SettingsChanged(s, e); };
            this.shortcutKeyControlPutty.KeyUp += (s, e) => { SettingsChanged(s, e); };
            this.shortcutKeyControlWinScp.KeyUp += (s, e) => { SettingsChanged(s, e); };

            this.buttonApply.Enabled = false;

            // Check if VMware VSphere PowerCLI is installed.
            this.CheckVSpherePowerCLIStatus();

            // Force settings validation.
            this.ValidateSettings();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
            this.buttonApply.Enabled = false;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (this.buttonApply.Enabled)
            {
                this.SaveSettings();
            }

            this.Close();
        }

        private void SaveSettings()
        {
            this.settings.Enabled = this.checkBoxEnable.Checked;
            this.settings.CompatibleMode = this.checkBoxCompatibleMode.Checked;
            this.settings.DisableCLIPasswordForPutty = this.checkBoxDisableCLIPasswordForPutty.Checked;
            this.settings.AddChangePasswordMenuItem = this.checkBoxAddChangePasswordItem.Checked;
            this.settings.PuttyPath = this.textBoxPuttyPath.Text;
            this.settings.WinScpPath = this.textBoxWinScpPath.Text;
            this.settings.PsPasswdPath = this.textBoxPsPasswdPath.Text;
            this.settings.HostAddressMapFieldName = (string)this.comboBoxHostAddressMapFieldName.SelectedItem;
            this.settings.ConnectionMethodMapFieldName = (string)this.comboBoxConnectionMethodMapFieldName.SelectedItem;
            this.settings.AdditionalOptionsMapFieldName = (string)this.comboBoxAdditionalOptionsMapFieldName.SelectedItem;

            if (shortcutKeysSettingWasChanged)
            {
                this.settings.EnableShortcutKeys = this.checkBoxEnableShortcutKeys.Checked;
                this.settings.RemoteDesktopShortcutKey = (this.shortcutKeyControlRemoteDesktop.HotKey | this.shortcutKeyControlRemoteDesktop.HotKeyModifiers);
                this.settings.PuttyShortcutKey = (this.shortcutKeyControlPutty.HotKey | this.shortcutKeyControlPutty.HotKeyModifiers);
                this.settings.WinScpShortcutKey = (this.shortcutKeyControlWinScp.HotKey | this.shortcutKeyControlWinScp.HotKeyModifiers);
            }

            this.settings.Save();
        }

        private bool IsPuttyPathValid()
        {
            if (this.textBoxPuttyPath.Text.Length == 0 || !File.Exists(this.textBoxPuttyPath.Text))
            {
                return (this.textBoxPuttyPath.Text.Length == 0);
            }
            else
            {
                this.textBoxPuttyPath.BackColor = default(Color);
                return true;
            }
        }

        private bool IsWinScpPathValid()
        {
            if (this.textBoxWinScpPath.Text.Length == 0 || !File.Exists(this.textBoxWinScpPath.Text))
            {
                return (this.textBoxWinScpPath.Text.Length == 0); // Allow empty path.
            }
            else
            {
                this.textBoxWinScpPath.BackColor = default(Color);
                return true;
            }
        }

        private bool IsPsPasswdPathValid()
        {
            if (this.textBoxPsPasswdPath.Text.Length == 0)
            {
                this.pictureBoxPsPasswdPathWarningIcon.Visible = false;
                this.labelPsPasswdPathWarningMessage.Visible = false;
                this.textBoxPsPasswdPath.BackColor = default(Color);

                return true;
            }
            else
            {
                this.pictureBoxPsPasswdPathWarningIcon.Visible = true;
                this.labelPsPasswdPathWarningMessage.Visible = true;

                if (File.Exists(this.textBoxPsPasswdPath.Text))
                {
                    if (!PsPasswdWrapper.IsPsPasswdUtility(this.textBoxPsPasswdPath.Text))
                    {
                        this.labelPsPasswdPathWarningMessage.Text = string.Format("Specified file is not valid.");
                        return false;
                    }
                    else if (!PsPasswdWrapper.IsSupportedVersion(this.textBoxPsPasswdPath.Text))
                    {
                        this.labelPsPasswdPathWarningMessage.Text = string.Format("Only version {0} is supported.", PsPasswdWrapper.SupportedVersion);
                        return false;
                    }
                    else
                    {
                        this.pictureBoxPsPasswdPathWarningIcon.Visible = false;
                        this.labelPsPasswdPathWarningMessage.Visible = false;
                        return true;
                    }
                }
                else
                {
                    this.pictureBoxPsPasswdPathWarningIcon.Image = global::QuickConnectPlugin.Properties.Resources.important;
                    this.labelPsPasswdPathWarningMessage.Text = "Specified path does not exists.";
                    return false;
                }
            }
        }

        private void SettingsChanged(Object sender, EventArgs e)
        {
            this.buttonApply.Enabled = ValidateSettings();
        }

        private bool ValidateSettings()
        {
            bool isValidPuttyPath = IsPuttyPathValid();
            this.pictureBoxPuttyPathWarningIcon.Visible = !isValidPuttyPath;
            this.labelPuttyPathWarningMessage.Visible = !isValidPuttyPath;

            bool isValidWinScpPath = IsWinScpPathValid();
            this.pictureBoxWinScpPathWarningIcon.Visible = !isValidWinScpPath;
            this.labelWinScpPathWarningMessage.Visible = !isValidWinScpPath;

            this.shortcutKeyControlRemoteDesktop.Enabled = this.checkBoxEnableShortcutKeys.Checked;
            this.shortcutKeyControlPutty.Enabled = this.checkBoxEnableShortcutKeys.Checked;
            this.shortcutKeyControlWinScp.Enabled = this.checkBoxEnableShortcutKeys.Checked;

            return isValidPuttyPath && isValidWinScpPath && IsPsPasswdPathValid() && HasNoConflictingShortcutKeys();
        }

        private void ButtonConfigurePuttyPath_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;

                if (File.Exists(this.textBoxPuttyPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxPuttyPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxPuttyPath.Text);
                }

                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "PuTTY executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select PuTTY Path";

                var result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    this.textBoxPuttyPath.Text = openFileDialog.FileName;
                    this.textBoxPuttyPath.Select(this.textBoxPuttyPath.Text.Length, 0);
                }
            }
        }

        private void ButtonConfigureWinScpPath_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;

                if (File.Exists(this.textBoxWinScpPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxWinScpPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxWinScpPath.Text);
                }

                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "WinSCP executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select WinSCP Path";

                var result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    this.textBoxWinScpPath.Text = openFileDialog.FileName;
                    this.textBoxWinScpPath.Select(this.textBoxWinScpPath.Text.Length, 0);
                }
            }
        }

        private void ButtonConfigurePsPasswdPath_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;

                if (File.Exists(this.textBoxPsPasswdPath.Text))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textBoxPsPasswdPath.Text);
                    openFileDialog.FileName = Path.GetFileName(this.textBoxPsPasswdPath.Text);
                }

                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "PsPasswd executable (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.Title = "Select PsPasswd Path";

                var result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    this.textBoxPsPasswdPath.Text = openFileDialog.FileName;
                    this.textBoxPsPasswdPath.Select(this.textBoxPsPasswdPath.Text.Length, 0);
                }
            }
        }

        private void CheckVSpherePowerCLIStatus()
        {
            var status = QuickConnectUtils.IsVSpherePowerCLIInstalled();

            this.labelVSpherePowerCLIStatusMessage.Text = this.labelVSpherePowerCLIStatusMessage.Text.Replace("{status}",
                status ? "installed" : "not installed"
            );

            if (status)
            {
                this.pictureBoxVSpherePowerCLIStatusIcon.Image = global::QuickConnectPlugin.Properties.Resources.success;
            }
        }

        private bool HasNoConflictingShortcutKeys()
        {
            if (checkBoxEnableShortcutKeys.Checked)
            {
                var remoteDesktopShortcutKey = (this.shortcutKeyControlRemoteDesktop.HotKey | this.shortcutKeyControlRemoteDesktop.HotKeyModifiers);
                var puttyShortcutKey = (this.shortcutKeyControlPutty.HotKey | this.shortcutKeyControlPutty.HotKeyModifiers);
                var winScpShortcutKey = (this.shortcutKeyControlWinScp.HotKey | this.shortcutKeyControlWinScp.HotKeyModifiers);

                bool conflictsWithKeePass = false;

                conflictsWithKeePass |= CheckRemoteDesktopShortcutKey(remoteDesktopShortcutKey);
                conflictsWithKeePass |= CheckPuttyShortcutKey(puttyShortcutKey);
                conflictsWithKeePass |= CheckWinScpShortcutKey(winScpShortcutKey);

                // Reset warning text.
                labelShortcutKeysWarning.Text = Properties.Resources.ShortcutKeysConflictsWithKeePassConfiguration;

                var configuredShortcuts = new List<Keys>
                {
                    remoteDesktopShortcutKey,
                    puttyShortcutKey,
                    winScpShortcutKey
                };

                var conflictsWithSelf = configuredShortcuts.Where(x => x != Keys.None).GroupBy(x => x).Any(g => g.Count() > 1);
                var hasConflicts = conflictsWithKeePass || conflictsWithSelf;

                if (!conflictsWithKeePass && conflictsWithSelf)
                {
                    labelShortcutKeysWarning.Text = Properties.Resources.ShortcutKeysCannotAssignToMultiplePrograms;
                }

                pictureBoxShortcutKeysWarning.Visible = hasConflicts;
                labelShortcutKeysWarning.Visible = hasConflicts;

                return !hasConflicts;
            }
            else
            {
                pictureBoxShortcutKeysWarning.Visible = false;
                labelShortcutKeysWarning.Visible = false;

                return true;
            }
        }

        private bool CheckRemoteDesktopShortcutKey(Keys remoteDesktopShortcutKeys)
        {
            var conflictsWithKeePass = remoteDesktopShortcutKeys != Keys.None && KeysHelper.ConflictsWithKeePassShortcutKeys(remoteDesktopShortcutKeys);
            this.shortcutKeyControlRemoteDesktop.BackColor = conflictsWithKeePass ? ColorTranslator.FromHtml("#FFC0C0") : default(Color);

            return conflictsWithKeePass;
        }

        private bool CheckPuttyShortcutKey(Keys puttyShortcutKeys)
        {
            var conflictsWithKeePass = puttyShortcutKeys != Keys.None && KeysHelper.ConflictsWithKeePassShortcutKeys(puttyShortcutKeys);
            this.shortcutKeyControlPutty.BackColor = conflictsWithKeePass ? ColorTranslator.FromHtml("#FFC0C0") : default(Color);

            return conflictsWithKeePass;
        }

        private bool CheckWinScpShortcutKey(Keys winScpShortcutKeys)
        {
            var conflictsWithKeePass = winScpShortcutKeys != Keys.None && KeysHelper.ConflictsWithKeePassShortcutKeys(winScpShortcutKeys);
            this.shortcutKeyControlWinScp.BackColor = conflictsWithKeePass ? ColorTranslator.FromHtml("#FFC0C0") : default(Color);

            return conflictsWithKeePass;
        }
    }
}
