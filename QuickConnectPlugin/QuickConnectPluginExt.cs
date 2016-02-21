using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePassLib;
using QuickConnectPlugin.KeePass;

namespace QuickConnectPlugin {

    public class QuickConnectPluginExt : Plugin {

        public const String Title = "QuickConnect";

        private const String PluginName = "QuickConnectPlugin";
        // private const String PluginUpdateUrl = "http://www.disruptivesoftware.ro/projects/KeePassPluginsVersionFile.txt";
        private const String PluginUpdateUrl = "https://raw.githubusercontent.com/cristianst85/QuickConnectPlugin/master/VERSION";

        private const String OpenRemoteDesktopMenuItemText = "Open Remote Desktop";
        private const String OpenRemoteDesktopConsoleMenuItemText = "Open Remote Desktop (console)";
        private const String OpenVSphereClientMenuItemText = "Open vSphere Client";
        private const String OpenSSHConsoleMenuItemText = "Open PuTTY Console";
        private const String DefaultHostAddressFieldName = "IP Address";
        private const String DefaultConnectionMethodFieldName = "OS Type";

        private IPluginHost pluginHost = null;

        private ToolStripMenuItem pluginMenuItem;
        private ToolStripMenuItem pluginMenuItemOptions;
        private ToolStripMenuItem pluginMenuItemAbout;
        private EventHandler pluginMenuItemOptionsOnClickEventHandler;
        private EventHandler pluginMenuItemAboutOnClickEventHandler;
        private IList<ToolStripItem> menuItems = new List<ToolStripItem>();

        private String rdcConsoleParameter;
        private String RDCConsoleParameter {
            get {
                if (rdcConsoleParameter == null) {
                    rdcConsoleParameter = QuickConnectUtils.IsOlderRemoteDesktopConnectionVersion() ? "console" : "admin";
                }
                return rdcConsoleParameter;
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
                    form.Text = form.Text.Replace("{title}", Title);
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
                PwEntry pwEntry = selectedEntries[0];
                String ipAddress = pwEntry.Strings.ReadSafe(!String.IsNullOrEmpty(this.Settings.HostAddressMapFieldName) ? this.Settings.HostAddressMapFieldName : DefaultHostAddressFieldName);
                var connectionMethodFieldValue = pwEntry.Strings.ReadSafe(!String.IsNullOrEmpty(this.Settings.ConnectionMethodMapFieldName) ? this.Settings.ConnectionMethodMapFieldName : DefaultConnectionMethodFieldName);
                var connectionMethods = ConnectionMethodTypeUtils.GetConnectionMethodsFromString(connectionMethodFieldValue);
                if (connectionMethods.Count != 0) {
                    this.addMenuItems(new HostPwEntry(pwEntry, ipAddress, connectionMethods));
                }
            }
        }

        private void addMenuItems(HostPwEntry hostPwEntry) {
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.RemoteDesktop)) {
                var openRemoteDesktopMenuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.remote,
                    Enabled = hostPwEntry.HasIPAddress()
                };
                openRemoteDesktopMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            // Store credentials.
                            ProcessStartInfo cmdKey = new ProcessStartInfo() {
                                FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                Arguments = String.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}",
                                hostPwEntry.IPAddress,
                                hostPwEntry.GetUsername(),
                                hostPwEntry.GetPassword()),
                                WindowStyle = ProcessWindowStyle.Hidden
                            };
                            Process.Start(cmdKey);
                            // Start a detached process and open Remote Desktop Connection.
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();
                            cmd.StandardInput.WriteLine(String.Format("\"{0}\" /f /v:{1}", Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"), hostPwEntry.IPAddress));
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                            // Delete stored credentials.
                            ThreadStart threadStart = delegate() {
                                Thread.Sleep(5000);
                                ProcessStartInfo cmdKeyDeleteCred = new ProcessStartInfo() {
                                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                    Arguments = String.Format("/delete:TERMSRV/{0}", hostPwEntry.IPAddress),
                                    WindowStyle = ProcessWindowStyle.Hidden
                                };
                                Process.Start(cmdKeyDeleteCred);
                            };
                            Thread thread = new Thread(threadStart);
                            thread.Start();
                        }
                        catch (Exception ex) {
                            this.log(ex.ToString());
                        }
                    }
                );
                this.menuItems.Add(openRemoteDesktopMenuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.RemoteDesktopConsole)) {
                var openRemoteDesktopConsoleMenuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.mycomputer,
                    Enabled = hostPwEntry.HasIPAddress()
                };
                openRemoteDesktopConsoleMenuItem.Click += new EventHandler(
                  delegate(object obj, EventArgs ev) {
                      try {
                          // Store credentials.
                          ProcessStartInfo cmdKey = new ProcessStartInfo() {
                              FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                              Arguments = String.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}",
                              hostPwEntry.IPAddress,
                              hostPwEntry.GetUsername(),
                              hostPwEntry.GetPassword()),
                              WindowStyle = ProcessWindowStyle.Hidden
                          };
                          Process.Start(cmdKey);
                          // Start a detached process and open Remote Desktop Connection.
                          Process cmd = new Process();
                          cmd.StartInfo.FileName = "cmd.exe";
                          cmd.StartInfo.RedirectStandardInput = true;
                          cmd.StartInfo.RedirectStandardOutput = true;
                          cmd.StartInfo.CreateNoWindow = true;
                          cmd.StartInfo.UseShellExecute = false;
                          cmd.Start();
                          cmd.StandardInput.WriteLine(String.Format("\"{0}\" /f /v:{1} /{2}", Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"), hostPwEntry.IPAddress, this.RDCConsoleParameter));
                          cmd.StandardInput.Flush();
                          cmd.StandardInput.Close();
                          // Delete stored credentials.
                          ThreadStart threadStart = delegate() {
                              Thread.Sleep(5000);
                              ProcessStartInfo cmdKeyDeleteCred = new ProcessStartInfo() {
                                  FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                  Arguments = String.Format("/delete:TERMSRV/{0}", hostPwEntry.IPAddress),
                                  WindowStyle = ProcessWindowStyle.Hidden
                              };
                              Process.Start(cmdKeyDeleteCred);
                          };
                          Thread thread = new Thread(threadStart);
                          thread.Start();
                      }
                      catch (Exception ex) {
                          log(ex.ToString());
                      }
                  }
                );
                this.menuItems.Add(openRemoteDesktopConsoleMenuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttySSH)) {
                var sshClientPath = !String.IsNullOrEmpty(this.Settings.SSHClientPath) ? this.Settings.SSHClientPath : QuickConnectUtils.GetPuttyPath();
                var openSshConsoleMenuItem = new ToolStripMenuItem() {
                    Text = OpenSSHConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.konsole,
                    Enabled = hostPwEntry.HasIPAddress() && !String.IsNullOrEmpty(sshClientPath)
                };
                openSshConsoleMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            // Start a detached process.
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();
                            cmd.StandardInput.WriteLine(String.Format("\"{0}\" -ssh {2}@{1} -pw {3}",
                                sshClientPath,
                                hostPwEntry.IPAddress,
                                hostPwEntry.GetUsername(),
                                hostPwEntry.GetPassword())
                                );
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                        }
                        catch (Exception ex) {
                            log(ex.ToString());
                        };
                    }
                );
                this.menuItems.Add(openSshConsoleMenuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.vSphereClient)) {
                var vSphereClientPath = QuickConnectUtils.GetVSphereClientPath();
                var openVSphereClientMenuItem = new ToolStripMenuItem() {
                    Text = OpenVSphereClientMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.vmware,
                    Enabled = hostPwEntry.HasIPAddress() && !String.IsNullOrEmpty(vSphereClientPath)
                };
                openVSphereClientMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            // Start a detached process.
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();
                            // TODO: Find a way to hide password shown in command line arguments.
                            cmd.StandardInput.WriteLine(String.Format("\"{0}\" -s {1} -u {2} -p {3}",
                                vSphereClientPath,
                                hostPwEntry.IPAddress,
                                hostPwEntry.GetUsername(),
                                hostPwEntry.GetPassword())
                                );
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                        }
                        catch (Exception ex) {
                            log(ex.ToString());
                        }
                    }
                );
                this.menuItems.Add(openVSphereClientMenuItem);
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

        private void log(String message) {
            Debug.WriteLine(String.Format("[{0}] {1}", this.GetType().Name, message));
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
