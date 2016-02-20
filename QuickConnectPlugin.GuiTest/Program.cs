using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace QuickConnectPlugin.OptionsFormLauncher {

    public class Program {

        [STAThread]
        static void Main(string[] args) {

            IQuickConnectPluginSettings settings = new InMemoryQuickConnectPluginSettings() {
                Enabled = true,
                CompatibleMode = true,
                HostAddressMapFieldName = "IP Address",
                ConnectionMethodMapFieldName = "OS Type",

            };
            ICollection<String> fields = new Collection<String>() {
                "Username",
                "Password",
                "OS Type",
                "IP Address"
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormOptions formOptions = new FormOptions(QuickConnectPluginExt.Title, settings, fields);
            Application.Run(formOptions);
        }
    }
}
