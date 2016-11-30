using System;
using System.Windows.Forms;
using KeePass.Plugins;
using QuickConnectPlugin.ShortcutKeys;
using QuickConnectPlugin.KeePass;

namespace QuickConnectPlugin {

    public class QuickConnectPluginSettings : AbstractQuickConnectPluginSettings
    {
        public const Keys DefaultPuttyShortcutKey = Keys.Control | Keys.Shift | Keys.P;
        public const Keys DefaultWinScpShortcutKey = Keys.Control | Keys.Shift | Keys.W;
        public const Keys DefaultRemoteDesktopShortcutKey = Keys.Control | Keys.Shift | Keys.D;

        private readonly ICustomConfigPropertyNameFormatter formatter;
        private readonly IPluginHost plugin;

        public static QuickConnectPluginSettings Load(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            QuickConnectPluginSettings options = new QuickConnectPluginSettings(pluginHost, propertyNameFormatter);
            options.Load();
            return options;
        }

        private QuickConnectPluginSettings(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            this.plugin = pluginHost;
            this.formatter = propertyNameFormatter;
        }

        /// <summary>
        /// Loads the plugin settings from the KeePass configuration file.
        /// </summary>
        public override void Load() {
            this.Enabled = this.plugin.CustomConfig.GetBool(this.formatter.Format("Enabled"), true);
            this.CompatibleMode = this.plugin.CustomConfig.GetBool(this.formatter.Format("CompatibleMode"), false);
            this.AddChangePasswordMenuItem = this.plugin.CustomConfig.GetBool(this.formatter.Format("AddChangePasswordMenuItem"), false);
            this.PuttyPath = this.plugin.CustomConfig.GetString(this.formatter.Format("SSHClientPath"), String.Empty);
            this.WinScpPath = this.plugin.CustomConfig.GetString(this.formatter.Format("WinScpPath"), String.Empty);
            this.HostAddressMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("HostAddressMapFieldName"), String.Empty);
            this.ConnectionMethodMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("ConnectionMethodMapFieldName"), String.Empty);
            this.AdditionalOptionsMapFieldName = this.plugin.CustomConfig.GetString(this.formatter.Format("AdditionalOptionsMapFieldName"), String.Empty);
            this.DisableCLIPasswordForPutty = this.plugin.CustomConfig.GetBool(this.formatter.Format("DisableCLIPasswordForPutty"), false);

            // Shortcut Keys Settings.
            this.EnableShortcutKeys = GetConfigIfSet<bool?>(this.formatter.Format("EnableShortcutKeys"));

            var remoteDesktopShortcutKey = Keys.None;
            KeysHelper.TryParse(this.plugin.CustomConfig.GetString(this.formatter.Format("RemoteDesktopShortcutKey"), String.Empty), out remoteDesktopShortcutKey);
            this.RemoteDesktopShortcutKey = remoteDesktopShortcutKey;

            var puttyShortcutKey = Keys.None;
            KeysHelper.TryParse(this.plugin.CustomConfig.GetString(this.formatter.Format("PuttyShortcutKey"), String.Empty), out puttyShortcutKey);
            this.PuttyShortcutKey = puttyShortcutKey;

            var winScpShortcutKey = Keys.None;
            KeysHelper.TryParse(this.plugin.CustomConfig.GetString(this.formatter.Format("WinScpShortcutKey"), String.Empty), out winScpShortcutKey);
            this.WinScpShortcutKey = winScpShortcutKey;
        }


        /// <summary>
        /// Saves the plugin settings to the KeePass configuration file.
        /// </summary>
        public override void Save() {
            this.plugin.CustomConfig.SetBool(this.formatter.Format("Enabled"), this.Enabled);
            this.plugin.CustomConfig.SetBool(this.formatter.Format("CompatibleMode"), this.CompatibleMode);
            this.plugin.CustomConfig.SetBool(this.formatter.Format("AddChangePasswordMenuItem"), this.AddChangePasswordMenuItem);
            this.plugin.CustomConfig.SetString(this.formatter.Format("SSHClientPath"), this.PuttyPath);
            this.plugin.CustomConfig.SetString(this.formatter.Format("WinScpPath"), this.WinScpPath);
            this.plugin.CustomConfig.SetString(this.formatter.Format("HostAddressMapFieldName"), this.HostAddressMapFieldName);
            this.plugin.CustomConfig.SetString(this.formatter.Format("ConnectionMethodMapFieldName"), this.ConnectionMethodMapFieldName);
            this.plugin.CustomConfig.SetString(this.formatter.Format("AdditionalOptionsMapFieldName"), this.AdditionalOptionsMapFieldName);
            this.plugin.CustomConfig.SetBool(this.formatter.Format("DisableCLIPasswordForPutty"), this.DisableCLIPasswordForPutty);

            if (EnableShortcutKeys.HasValue)
            {
                this.plugin.CustomConfig.SetBool(this.formatter.Format("EnableShortcutKeys"), EnableShortcutKeys.Value);
                this.plugin.CustomConfig.SetString(this.formatter.Format("RemoteDesktopShortcutKey"), ((int)this.RemoteDesktopShortcutKey).ToString());
                this.plugin.CustomConfig.SetString(this.formatter.Format("PuttyShortcutKey"), ((int)this.PuttyShortcutKey).ToString());
                this.plugin.CustomConfig.SetString(this.formatter.Format("WinScpShortcutKey"), ((int)this.WinScpShortcutKey).ToString());
            }
        }

        private T GetConfigIfSet<T>(string strID)
        {
            object obj = this.plugin.CustomConfig.GetString(strID, null);

            Type underlyingType = Nullable.GetUnderlyingType(typeof(T));

            if (underlyingType != null)
            {
                return (obj == null) ? default(T) : (T)Convert.ChangeType(obj, underlyingType);
            }
            else
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }
    }
}
