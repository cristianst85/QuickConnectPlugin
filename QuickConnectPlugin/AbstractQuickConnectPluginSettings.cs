using System.Windows.Forms;

namespace QuickConnectPlugin {

    public abstract class AbstractQuickConnectPluginSettings : IQuickConnectPluginSettings
    {
        public virtual bool Enabled { get; set; }
        public virtual bool CompatibleMode { get; set; }
        public virtual bool AddChangePasswordMenuItem { get; set; }
        public virtual string PuttyPath { get; set; }
        public virtual string WinScpPath { get; set; }
        public virtual string PsPasswdPath { get; set; }
        public virtual string HostAddressMapFieldName { get; set; }
        public virtual string ConnectionMethodMapFieldName { get; set; }
        public virtual string AdditionalOptionsMapFieldName { get; set; }
        public virtual bool DisableCLIPasswordForPutty { get; set; }
        public virtual bool? EnableShortcutKeys { get; set; }
        public virtual Keys RemoteDesktopShortcutKey { get; set; }
        public virtual Keys PuttyShortcutKey { get; set; }
        public virtual Keys WinScpShortcutKey { get; set; }

        public abstract void Load();

        public abstract void Save();
    }
}
