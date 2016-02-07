using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePassLib;

namespace QuickConnectPlugin {

    public class QuickConnectPluginExt : Plugin {

        public const String Title = "Quick Connect";

        private const String PluginName = "QuickConnectPluginExt";

        private const String OpenRemoteDesktopMenuItemText = "Open Remote Desktop";
        private const String OpenRemoteDesktopConsoleMenuItemText = "Open Remote Desktop (console)";
        private const String OpenVMwareVSphereClientMenuItemText = "Open VMware vSphere Client";
        private const String OpenSshConsoleMenuItemText = "Open SSH Console";
        private const String IPAddressPropertyName = "IP Address";
        private const String OSTypePropertyName = "OS Type";

        private IPluginHost pluginHost = null;

        public bool Enabled { get; set; }
        public bool PutMenuItemsOnTop { get; set; }

        private ToolStripMenuItem pluginMenuItem;
        private EventHandler pluginMenuItemOnClickEventHandler;
        private IList<ToolStripItem> menuItems = new List<ToolStripItem>();

        private String rdcConsoleParameter;
        private String RDCConsoleParameter {
            get {
                if (rdcConsoleParameter == null) {
                    rdcConsoleParameter = Utils.IsOlderRemoteDesktopConnectionVersion() ? "console" : "admin";
                }
                return rdcConsoleParameter;
            }
        }

        public override bool Initialize(IPluginHost pluginHost) {

            Debug.Assert(pluginHost != null);

            if (pluginHost == null) {
                return false;
            }

            this.pluginHost = pluginHost;

            pluginMenuItem = new ToolStripMenuItem(String.Format("{0}...", Title));
            pluginMenuItem.Click += new EventHandler(
                pluginMenuItemOnClickEventHandler = delegate(object obj, EventArgs ev) {
                QuickConnectForm form = new QuickConnectForm();
                form.Text = Title;
                form.ShowDialog(pluginHost.MainWindow);
            });
            this.pluginHost.MainWindow.ToolsMenu.DropDownItems.Add(pluginMenuItem);

            // Configuration.
            this.PutMenuItemsOnTop = true;
            this.Enabled = true;

            // Add handlers.
            ContextMenuStrip entryContextMenu = pluginHost.MainWindow.EntryContextMenu;
            if (this.Enabled) {
                entryContextMenu.Opened += new EventHandler(entryContextMenu_Opened);
                entryContextMenu.Closed += new ToolStripDropDownClosedEventHandler(entryContextMenu_Closed);
            }

            return true;
        }

        private void entryContextMenu_Opened(object sender, EventArgs e) {
            PwEntry[] selectedEntries = this.pluginHost.MainWindow.GetSelectedEntries();
            if (selectedEntries != null && selectedEntries.Length == 1) {
                PwEntry pwEntry = selectedEntries[0];
                String ipAddress = pwEntry.Strings.ReadSafe(IPAddressPropertyName);
                OSType osType = OSTypeUtils.GetOSTypeFromString(pwEntry.Strings.ReadSafe(OSTypePropertyName));
                if (osType == OSType.Windows || osType == OSType.Linux || osType == OSType.ESXi) {
                    this.addMenuItems(osType, ipAddress, pwEntry);
                }
            }
        }

        private void addMenuItems(OSType osType, String ipAddress, PwEntry pwEntry) {
            bool hasIpAddress = !String.IsNullOrEmpty(ipAddress);
            if (osType == OSType.Windows) {
                var openRemoteDesktopMenuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.remote,
                    Enabled = hasIpAddress
                };
                openRemoteDesktopMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            // Store credentials.
                            ProcessStartInfo cmdKey = new ProcessStartInfo() {
                                FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                Arguments = String.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}",
                                ipAddress,
                                pwEntry.Strings.GetSafe("UserName").ReadString(),
                                pwEntry.Strings.GetSafe("Password").ReadString()),
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
                            cmd.StandardInput.WriteLine(String.Format("\"{0}\" /f /v:{1}", Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"), ipAddress));
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                            // Delete stored credentials.
                            ThreadStart threadStart = delegate() {
                                Thread.Sleep(5000);
                                ProcessStartInfo cmdKeyDeleteCred = new ProcessStartInfo() {
                                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                    Arguments = String.Format("/delete:TERMSRV/{0}", ipAddress),
                                    WindowStyle = ProcessWindowStyle.Hidden
                                };
                                Process.Start(cmdKeyDeleteCred);
                            };
                            Thread thread = new Thread(threadStart);
                            thread.Start();
                        }
                        catch (Exception ex) {
                            Debug.WriteLine(ex.ToString());
                        }
                    }
                );
                var openRemoteDesktopConsoleMenuItem = new ToolStripMenuItem() {
                    Text = OpenRemoteDesktopConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.mycomputer,
                    Enabled = hasIpAddress
                };
                openRemoteDesktopConsoleMenuItem.Click += new EventHandler(
                  delegate(object obj, EventArgs ev) {
                      try {
                          // Store credentials.
                          ProcessStartInfo cmdKey = new ProcessStartInfo() {
                              FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                              Arguments = String.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}",
                              ipAddress,
                              pwEntry.Strings.GetSafe("UserName").ReadString(),
                              pwEntry.Strings.GetSafe("Password").ReadString()),
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
                          cmd.StandardInput.WriteLine(String.Format("\"{0}\" /f /v:{1} /{2}", Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"), ipAddress, this.RDCConsoleParameter));
                          cmd.StandardInput.Flush();
                          cmd.StandardInput.Close();
                          // Delete stored credentials.
                          ThreadStart threadStart = delegate() {
                              Thread.Sleep(5000);
                              ProcessStartInfo cmdKeyDeleteCred = new ProcessStartInfo() {
                                  FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                                  Arguments = String.Format("/delete:TERMSRV/{0}", ipAddress),
                                  WindowStyle = ProcessWindowStyle.Hidden
                              };
                              Process.Start(cmdKeyDeleteCred);
                          };
                          Thread thread = new Thread(threadStart);
                          thread.Start();
                      }
                      catch (Exception ex) {
                          Debug.WriteLine(ex.ToString());
                      }
                  }
                );
                this.menuItems.Add(openRemoteDesktopMenuItem);
                this.menuItems.Add(openRemoteDesktopConsoleMenuItem);
            }
            else if (osType == OSType.Linux) {
                var openSshConsoleMenuItem = new ToolStripMenuItem() {
                    Text = OpenSshConsoleMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.konsole,
                    Enabled = hasIpAddress
                };
                openSshConsoleMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            Debug.WriteLine("openSshConsoleMenuItem.Click");
                            // Start a detached process.
                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();
                            cmd.StandardInput.WriteLine(String.Format("\"{0}\" -ssh {2}@{1} -pw {3}",
                                Utils.GetPuttyPath(),
                                ipAddress,
                                pwEntry.Strings.GetSafe("UserName").ReadString(),
                                pwEntry.Strings.GetSafe("Password").ReadString())
                                );
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                        }
                        catch (Exception ex) {
                            Debug.WriteLine(ex.ToString());
                        };
                    }
                );
                this.menuItems.Add(openSshConsoleMenuItem);
            }
            else if (osType == OSType.ESXi) {
                var openVMWareVSphereClientMenuItem = new ToolStripMenuItem() {
                    Text = OpenVMwareVSphereClientMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.vmware,
                    Enabled = hasIpAddress
                };
                openVMWareVSphereClientMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            Debug.WriteLine("openVMWareVSphereClientMenuItem.Click");
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
                                Utils.GetVMwareVSphereClientPath(),
                                ipAddress,
                                pwEntry.Strings.GetSafe("UserName").ReadString(),
                                pwEntry.Strings.GetSafe("Password").ReadString())
                                );
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                        }
                        catch (Exception ex) {
                            Debug.WriteLine(ex.ToString());
                        }
                    }
                );
                this.menuItems.Add(openVMWareVSphereClientMenuItem);
            }
            else {
                throw new Exception(String.Format("OSType {0} is not supported.", osType.ToString()));
            }

            int separatorIndex = this.PutMenuItemsOnTop ? this.menuItems.Count : this.pluginHost.MainWindow.EntryContextMenu.Items.Count - this.menuItems.Count;

            if (this.PutMenuItemsOnTop) {
                for (int i = this.menuItems.Count - 1; i >= 0; i--) {
                    this.pluginHost.MainWindow.EntryContextMenu.Items.Insert(0, this.menuItems[i]);
                }
            }
            else {
                foreach (var item in this.menuItems) {
                    this.pluginHost.MainWindow.EntryContextMenu.Items.Add(item);
                }
            }
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

        public override void Terminate() {
            if (this.pluginMenuItem != null) {
                this.pluginHost.MainWindow.ToolsMenu.DropDownItems.Remove(pluginMenuItem);
                this.pluginMenuItem.Click -= this.pluginMenuItemOnClickEventHandler;
            }
        }
    }
}
