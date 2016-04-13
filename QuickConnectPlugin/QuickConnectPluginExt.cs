using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePassLib;
using QuickConnectPlugin.ArgumentsFormatters;
using QuickConnectPlugin.Commons;
using QuickConnectPlugin.KeePass;

namespace QuickConnectPlugin {

    public class QuickConnectPluginExt : Plugin {

        public const String Title = "QuickConnect";

        private const String PluginName = "QuickConnectPlugin";
        private const String PluginUpdateUrl = "https://raw.githubusercontent.com/cristianst85/QuickConnectPlugin/master/VERSION";

        private const String OpenRemoteDesktopMenuItemText = "Open Remote Desktop";
        private const String OpenRemoteDesktopConsoleMenuItemText = "Open Remote Desktop (console)";
        private const String OpenVSphereClientMenuItemText = "Open vSphere Client";
        private const String OpenSSHConsoleMenuItemText = "Open PuTTY Console";

        private IPluginHost pluginHost = null;
        private IFieldMapper fieldsMapper = null;

        private ToolStripMenuItem pluginMenuItem;
        private ToolStripMenuItem pluginMenuItemOptions;
        private ToolStripMenuItem pluginMenuItemAbout;
        private EventHandler pluginMenuItemOptionsOnClickEventHandler;
        private EventHandler pluginMenuItemAboutOnClickEventHandler;
        private IList<ToolStripItem> menuItems = new List<ToolStripItem>();

        private bool? rdcIsOlderVersion;
        private bool RDCIsOlderVersion {
            get {
                if (!rdcIsOlderVersion.HasValue) {
                    rdcIsOlderVersion = QuickConnectUtils.IsOlderRemoteDesktopConnectionVersion();
                }
                return rdcIsOlderVersion.Value;
            }
        }

        public IQuickConnectPluginSettings Settings { get; private set; }

        public override string UpdateUrl {
            get {
                return PluginUpdateUrl;
            }
        }

        public override bool Initialize(IPluginHost pluginHost) {

            Debug.Assert(pluginHost != null);

            if (pluginHost == null) {
                return false;
            }

            this.pluginHost = pluginHost;

            this.Settings = QuickConnectPluginSettings.Load(pluginHost, new PluginCustomConfigPropertyNameFormatter(PluginName));

            this.fieldsMapper = new SettingsFieldMapper(this.Settings);

            pluginMenuItemOptions = new ToolStripMenuItem("Options...");
            pluginMenuItemOptions.Click += new EventHandler(
                pluginMenuItemOptionsOnClickEventHandler = delegate(object obj, EventArgs ev) {
                List<String> fields = null;
                // Check if database is open.
                if (this.pluginHost.Database != null && this.pluginHost.Database.IsOpen) {
                    fields = new List<String>();
                    foreach (var pwEntry in this.pluginHost.Database.RootGroup.GetEntries(true)) {
                        foreach (var str in pwEntry.Strings.GetKeys()) {
                            if (!fields.Contains(str)) {
                                fields.Add(str);
                            }
                        }
                    }
                    fields.Sort();
                }
                using (FormOptions form = new FormOptions(Title, this.Settings, fields)) {
                    form.ShowDialog(pluginHost.MainWindow);
                }
            });
            pluginMenuItemAbout = new ToolStripMenuItem("About");
            pluginMenuItemAbout.Click += new EventHandler(
                pluginMenuItemAboutOnClickEventHandler = delegate(object obj, EventArgs ev) {
                using (FormAbout form = new FormAbout()) {
                    form.Text = form.Text.Replace("{title}", Title);
                    form.ShowDialog(pluginHost.MainWindow);
                }
            });
            pluginMenuItem = new ToolStripMenuItem(String.Format("{0}", Title));
            pluginMenuItem.DropDownItems.Add(pluginMenuItemOptions);
            pluginMenuItem.DropDownItems.Add(pluginMenuItemAbout);

            this.pluginHost.MainWindow.ToolsMenu.DropDownItems.Add(pluginMenuItem);

            // Add handlers.
            ContextMenuStrip entryContextMenu = pluginHost.MainWindow.EntryContextMenu;
            entryContextMenu.Opened += new EventHandler(entryContextMenu_Opened);
            entryContextMenu.Closed += new ToolStripDropDownClosedEventHandler(entryContextMenu_Closed);

            return true;
        }

        private void entryContextMenu_Opened(object sender, EventArgs e) {

            if (!this.Settings.Enabled) {
                return;
            }

            PwEntry[] selectedEntries = this.pluginHost.MainWindow.GetSelectedEntries();
            if (selectedEntries != null && selectedEntries.Length == 1) {
                HostPwEntry hostPwEntry = new HostPwEntry(selectedEntries[0], this.pluginHost.Database, this.fieldsMapper);
                if (hostPwEntry.HasConnectionMethods) {
                    this.addMenuItems(hostPwEntry);
                }
            }
        }

        private void addMenuItems(HostPwEntry hostPwEntry) {
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.RemoteDesktop)) {
                var menuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.remote,
                    Enabled = hostPwEntry.HasIPAddress
                };
                menuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            ProcessUtils.Start(CmdKeyRegisterArgumentsFormatter.CmdKeyPath, new CmdKeyRegisterArgumentsFormatter().Format(hostPwEntry));
                            IArgumentsFormatter argsFormatter = new RemoteDesktopArgumentsFormatter() {
                                FullScreen = true
                            };
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                            ProcessUtils.StartDetached(new CmdKeyUnregisterArgumentsFormatter().Format(hostPwEntry), TimeSpan.FromSeconds(5));
                        }
                        catch (Exception ex) {
                            log(ex);
                        }
                    }
                );
                this.menuItems.Add(menuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.RemoteDesktopConsole)) {
                var menuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.mycomputer,
                    Enabled = hostPwEntry.HasIPAddress
                };
                menuItem.Click += new EventHandler(
                  delegate(object obj, EventArgs ev) {
                      try {
                          ProcessUtils.Start(CmdKeyRegisterArgumentsFormatter.CmdKeyPath, new CmdKeyRegisterArgumentsFormatter().Format(hostPwEntry));
                          IArgumentsFormatter argsFormatter = new RemoteDesktopArgumentsFormatter() {
                              FullScreen = true,
                              UseConsole = true,
                              IsOlderVersion = RDCIsOlderVersion
                          };
                          ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                          ProcessUtils.StartDetached(new CmdKeyUnregisterArgumentsFormatter().Format(hostPwEntry), TimeSpan.FromSeconds(5));
                      }
                      catch (Exception ex) {
                          log(ex);
                      }
                  }
                );
                this.menuItems.Add(menuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttySSH) ||
                hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttyTelnet)) {
                var sshClientPath = !String.IsNullOrEmpty(this.Settings.SSHClientPath) ? this.Settings.SSHClientPath : QuickConnectUtils.GetPuttyPath();
                var menuItem = new ToolStripMenuItem() {
                    Text = OpenSSHConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.konsole,
                    Enabled = hostPwEntry.HasIPAddress && !String.IsNullOrEmpty(sshClientPath)
                };
                menuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            IArgumentsFormatter argsFormatter = new PuttyArgumentsFormatter(sshClientPath, new RegistryPuttySessionFinder());
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                        }
                        catch (Exception ex) {
                            log(ex);
                        };
                    }
                );
                this.menuItems.Add(menuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.vSphereClient)) {
                var vSphereClientPath = QuickConnectUtils.GetVSphereClientPath();
                var menuItem = new ToolStripMenuItem() {
                    Text = OpenVSphereClientMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.vmware,
                    Enabled = hostPwEntry.HasIPAddress && !String.IsNullOrEmpty(vSphereClientPath)
                };
                menuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            IArgumentsFormatter argsFormatter = new VSphereClientArgumentsFormatter(vSphereClientPath);
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                        }
                        catch (Exception ex) {
                            log(ex);
                        }
                    }
                );
                this.menuItems.Add(menuItem);
            }

            var putMenuItemsOnTop = !this.Settings.CompatibleMode;

            if (putMenuItemsOnTop) {
                for (int i = this.menuItems.Count - 1; i >= 0; i--) {
                    this.pluginHost.MainWindow.EntryContextMenu.Items.Insert(0, this.menuItems[i]);
                }
            }
            else {
                foreach (var item in this.menuItems) {
                    this.pluginHost.MainWindow.EntryContextMenu.Items.Add(item);
                }
            }
            int separatorIndex = putMenuItemsOnTop ? this.menuItems.Count :
                this.pluginHost.MainWindow.EntryContextMenu.Items.Count - this.menuItems.Count;
            var separator = new ToolStripSeparator();
            this.menuItems.Add(separator);
            this.pluginHost.MainWindow.EntryContextMenu.Items.Insert(separatorIndex, separator);
        }

        private void entryContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
            foreach (var menuItem in this.menuItems) {
                this.pluginHost.MainWindow.EntryContextMenu.Items.Remove(menuItem);
            }
            this.menuItems.Clear();
        }

        private void log(Exception ex) {
            Debug.WriteLine(String.Format("[{0}] Error while launching process. Exception: {1}", this.GetType().Name, ex.ToString()));
            MessageBox.Show(String.Format("Error while launching process.\n\nError details: {0}", ex.ToString()), PluginName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void Terminate() {
            if (this.pluginMenuItem != null) {
                this.pluginHost.MainWindow.ToolsMenu.DropDownItems.Remove(pluginMenuItem);
            }
            if (this.pluginMenuItemAbout != null) {
                this.pluginMenuItemAbout.Click -= this.pluginMenuItemAboutOnClickEventHandler;
            }
            if (this.pluginMenuItemOptions != null) {
                this.pluginMenuItemOptions.Click -= this.pluginMenuItemOptionsOnClickEventHandler;
            }
        }
    }
}
