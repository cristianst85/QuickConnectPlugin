using System;

namespace QuickConnectPlugin {

    public class SettingsFieldMapper : IFieldMapper {

        private IQuickConnectPluginSettings settings;

        public SettingsFieldMapper(IQuickConnectPluginSettings settings) {
            this.settings = settings;
        }

        public string HostAddress {
            get {
                return this.settings.HostAddressMapFieldName;
            }
        }

        public string ConnectionMethod {
            get {
                return this.settings.ConnectionMethodMapFieldName;
            }
        }

        public string AdditionalOptions {
            get {
                return this.settings.AdditionalOptionsMapFieldName;
            }
        }
    }
}
