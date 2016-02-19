using System;
using KeePass.Plugins;
using QuickConnectPlugin.KeePass;

namespace QuickConnectPlugin {

    public class QuickConnectPluginSettings : IQuickConnectPluginSettings {

        public bool Enabled { get; set; }
        public bool CompatibleMode { get; set; }
        public String SSHClientPath { get; set; }
        public String HostAddressMapFieldName { get; set; }
        public String ConnectionMethodMapFieldName { get; set; }

        private ICustomConfigPropertyNameFormatter propertyNameFormatter;
        private IPluginHost pluginHost;

        public static QuickConnectPluginSettings Load(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            QuickConnectPluginSettings options = new QuickConnectPluginSettings(pluginHost, propertyNameFormatter);
            options.Load();
            return options;
        }

        private QuickConnectPluginSettings(IPluginHost pluginHost, ICustomConfigPropertyNameFormatter propertyNameFormatter) {
            this.pluginHost = pluginHost;
            this.propertyNameFormatter = propertyNameFormatter;
        }

        /// <summary>
        /// Loads the plugin settings from the KeePass configuration file.
        /// </summary>
        public void Load() {
            this.Enabled = this.pluginHost.CustomConfig.GetBool(this.propertyNameFormatter.Format("Enabled"), true);
            this.CompatibleMode = this.pluginHost.CustomConfig.GetBool(this.propertyNameFormatter.Format("CompatibleMode"), false);
            this.SSHClientPath = this.pluginHost.CustomConfig.GetString(this.propertyNameFormatter.Format("SSHClientPath"), String.Empty);
            this.HostAddressMapFieldName = this.pluginHost.CustomConfig.GetString(this.propertyNameFormatter.Format("HostAddressMapFieldName"), String.Empty);
            this.ConnectionMethodMapFieldName = this.pluginHost.CustomConfig.GetString(this.propertyNameFormatter.Format("ConnectionMethodMapFieldName"), String.Empty);
        }

        /// <summary>
        /// Saves the plugin settings to the KeePass configuration file.
        /// </summary>
        public void Save() {
            this.pluginHost.CustomConfig.SetBool(this.propertyNameFormatter.Format("Enabled"), this.Enabled);
            this.pluginHost.CustomConfig.SetBool(this.propertyNameFormatter.Format("CompatibleMode"), this.CompatibleMode);
            this.pluginHost.CustomConfig.SetString(this.propertyNameFormatter.Format("SSHClientPath"), this.SSHClientPath);
            this.pluginHost.CustomConfig.SetString(this.propertyNameFormatter.Format("HostAddressMapFieldName"), this.HostAddressMapFieldName);
            this.pluginHost.CustomConfig.SetString(this.propertyNameFormatter.Format("ConnectionMethodMapFieldName"), this.ConnectionMethodMapFieldName);
        }
    }
}
