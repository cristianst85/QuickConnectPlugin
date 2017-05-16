using System;
using System.Diagnostics;

namespace QuickConnectPlugin.FormLauchers {

    public class InMemoryQuickConnectPluginSettings : IQuickConnectPluginSettings {

        public bool Enabled { get; set; }
        public bool CompatibleMode { get; set; }
        public bool AddChangePasswordMenuItem { get; set; }
        public string SSHClientPath { get; set; }
        public string WinScpPath { get; set; }
        public string PsPasswdPath { get; set; }
        public string HostAddressMapFieldName { get; set; }
        public string ConnectionMethodMapFieldName { get; set; }
        public string AdditionalOptionsMapFieldName { get; set; }
        public string RdpPlusPath { get; set; }

        public void Load() {
            Debug.WriteLine(this.GetType().Name + ".Load()");
        }

        public void Save() {
            Debug.WriteLine(this.GetType().Name + ".Save()");
        }
    }
}
