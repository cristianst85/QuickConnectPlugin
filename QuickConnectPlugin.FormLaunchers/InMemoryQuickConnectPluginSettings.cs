using System.Diagnostics;

namespace QuickConnectPlugin.FormLaunchers {

    public class InMemoryQuickConnectPluginSettings : AbstractQuickConnectPluginSettings {

        public override void Load() {
            Debug.WriteLine(this.GetType().Name + ".Load()");
        }

        public override void Save() {
            Debug.WriteLine(this.GetType().Name + ".Save()");
        }
    }
}
