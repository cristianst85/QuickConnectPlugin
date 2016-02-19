using System;

namespace QuickConnectPlugin.KeePass {

    public class PluginCustomConfigPropertyNameFormatter : ICustomConfigPropertyNameFormatter {

        public String PluginName { get; private set; }

        public PluginCustomConfigPropertyNameFormatter(String pluginName) {
            if (pluginName == null) {
                throw new ArgumentNullException("pluginName");
            }
            if (pluginName.Trim().Length == 0) {
                throw new ArgumentException("pluginName");
            }
            this.PluginName = pluginName;
        }

        public string Format(string propertyName) {
            return String.Format("{0}.{1}", this.PluginName, propertyName);
        }
    }
}
