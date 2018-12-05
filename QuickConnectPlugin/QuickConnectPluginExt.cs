using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;
using DisruptiveSoftware.Time.Clocks;
using KeePass.Plugins;
using KeePassLib;
using QuickConnectPlugin.ArgumentsFormatters;
using QuickConnectPlugin.Commons;
using QuickConnectPlugin.Extensions;
using QuickConnectPlugin.KeePass;
using QuickConnectPlugin.PasswordChanger;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Services;

namespace QuickConnectPlugin {

    public class QuickConnectPluginExt : Plugin, IDisposable {

        public const String Title = "QuickConnect";

        private const String PluginName = "QuickConnectPlugin";
        private const String PluginUpdateUrl = "https://raw.githubusercontent.com/cristianst85/QuickConnectPlugin/master/VERSION";

        private const String OpenRemoteDesktopMenuItemText = "Open Remote Desktop";
        private const String OpenRemoteDesktopConsoleMenuItemText = "Open Remote Desktop (console)";
        private const String OpenVSphereClientMenuItemText = "Open vSphere Client";
        private const String OpenSSHConsoleMenuItemText = "Open PuTTY Console";
        private const String OpenWinScpMenuItemText = "Open WinSCP";
        private const String ChangePasswordMenuItemText = "Change Password...";

        private static readonly TimeSpan RemoveCredentialsDelay = TimeSpan.FromSeconds(5);

        private IPluginHost pluginHost = null;
        private IFieldMapper fieldsMapper = null;

        private ToolStripMenuItem pluginMenuItem;
        private ToolStripMenuItem pluginMenuItemOptions;
        private ToolStripMenuItem pluginMenuItemAbout;
        private ToolStripMenuItem pluginMenuItemBatchPasswordChanger;
        private EventHandler pluginMenuItemOptionsOnClickEventHandler;
        private EventHandler pluginMenuItemAboutOnClickEventHandler;
        private EventHandler pluginMenuItemBatchPasswordChangerOnClickEventHandler;
        private ResolveEventHandler resourcesEventHandler;
        private DisposableList<ToolStripItem> menuItems;

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

        private bool disposed;

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public QuickConnectPluginExt() {
            // Workaround for Plugin Compatibility Check changes in KeePass 2.40.
            // https://sourceforge.net/p/keepass/discussion/329220/thread/3c8b8128/
            resourcesEventHandler = new ResolveEventHandler(AssemblyUtils.AssemblyResolverFromResources);
            AppDomain.CurrentDomain.AssemblyResolve += resourcesEventHandler;
        }

        [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
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
                        fields = this.pluginHost.Database.GetAllFields(true).ToList();
                        fields.Sort();
                    }
                    using (FormOptions form = new FormOptions(Title, this.Settings, fields)) {
                        form.ShowDialog(pluginHost.MainWindow);
                    }
                }
            );
            pluginMenuItemBatchPasswordChanger = new ToolStripMenuItem("Batch Password Changer...");
            pluginMenuItemBatchPasswordChanger.Click += new EventHandler(
                pluginMenuItemBatchPasswordChangerOnClickEventHandler = delegate(object obj, EventArgs ev) {
                    IPasswordChangerTreeNode pwTreeNode = null;
                    // Check if database is open.
                    if (this.pluginHost.Database != null && this.pluginHost.Database.IsOpen) {
                        pwTreeNode = PasswordChangerTreeNode.Build(pluginHost.Database, fieldsMapper);
                    }
                    else {
                        pwTreeNode = new EmptyTreeNode("No database available.");
                    }
                    var pwChangerFactory = new DictionaryPasswordChangerExFactory();

                    if (QuickConnectUtils.IsVSpherePowerCLIInstalled()) {
                        pwChangerFactory.Factories.Add(HostType.ESXi, new PasswordChangerExFactory(new ESXiPasswordChangerFactory()));
                    }
                    if (!String.IsNullOrEmpty(this.Settings.PsPasswdPath) &&
                        File.Exists(this.Settings.PsPasswdPath) &&
                        PsPasswdWrapper.IsPsPasswdUtility(this.Settings.PsPasswdPath) &&
                        PsPasswdWrapper.IsSupportedVersion(this.Settings.PsPasswdPath)) {
                        pwChangerFactory.Factories.Add(HostType.Windows, new PasswordChangerExFactory(new WindowsPasswordChangerFactory(
                            new PsPasswdWrapper(this.Settings.PsPasswdPath)))
                        );
                    }
                    pwChangerFactory.Factories.Add(HostType.Linux, new LinuxPasswordChangerExFactory(new LinuxPasswordChangerFactory()));

                    var pwChangerServiceFactory = new PasswordChangerServiceFactory(
                        new PasswordDatabase(this.pluginHost.Database),
                        pwChangerFactory,
                        new SystemClock()
                    );
                    using (var form = new FormBatchPasswordChanger(pwTreeNode, pwChangerServiceFactory)) {
                        form.ShowDialog(pluginHost.MainWindow);
                        if (form.Changed) {
                            refreshUI();
                        }
                    }
                }
            );
            pluginMenuItemAbout = new ToolStripMenuItem("About");
            pluginMenuItemAbout.Click += new EventHandler(
                pluginMenuItemAboutOnClickEventHandler = delegate(object obj, EventArgs ev) {
                    using (FormAbout form = new FormAbout()) {
                        form.Text = form.Text.Replace("{title}", Title);
                        form.ShowDialog(pluginHost.MainWindow);
                    }
                }
            );
            pluginMenuItem = new ToolStripMenuItem(String.Format("{0}", Title));
            pluginMenuItem.DropDownItems.Add(pluginMenuItemBatchPasswordChanger);
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
                this.menuItems = new DisposableList<ToolStripItem>();
                HostPwEntry hostPwEntry = new HostPwEntry(selectedEntries[0], this.pluginHost.Database, this.fieldsMapper);
                var changePasswordMenuItem = this.createChangePasswordMenuItem(hostPwEntry);
                if (hostPwEntry.HasConnectionMethods) {
                    menuItems.AddRange(this.createMenuItems(hostPwEntry));
                    if (this.Settings.CompatibleMode) {
                        this.menuItems.Insert(0, new ToolStripSeparator());
                    }
                    else {
                        this.menuItems.Add(new ToolStripSeparator());
                    }
                    if (this.Settings.AddChangePasswordMenuItem) {
                        if (this.Settings.CompatibleMode) {
                            this.menuItems.Insert(0, changePasswordMenuItem);
                            this.menuItems.Insert(0, new ToolStripSeparator());
                        }
                        else {
                            this.menuItems.Add(changePasswordMenuItem);
                            this.menuItems.Add(new ToolStripSeparator());
                        }
                    }
                    if (this.Settings.CompatibleMode) {
                        foreach (var item in this.menuItems) {
                            this.pluginHost.MainWindow.EntryContextMenu.Items.Add(item);
                        }
                    }
                    else {
                        for (int i = this.menuItems.Count - 1; i >= 0; i--) {
                            this.pluginHost.MainWindow.EntryContextMenu.Items.Insert(0, this.menuItems[i]);
                        }
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "ToolStripItem objects are disposed inside entryContextMenu_Closed method")]
        private DisposableList<ToolStripItem> createMenuItems(HostPwEntry hostPwEntry) {
            var menuItems = new DisposableList<ToolStripItem>();
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
                            ProcessUtils.StartDetached(new CmdKeyUnregisterArgumentsFormatter() {
                                IncludePath = true 
                            }.Format(hostPwEntry), RemoveCredentialsDelay);
                        }
                        catch (Exception ex) {
                            log(ex);
                        }
                    }
                );
                menuItems.Add(menuItem);
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
                            ProcessUtils.Start(CmdKeyRegisterArgumentsFormatter.CmdKeyPath, new CmdKeyRegisterArgumentsFormatter()
                                .Format(hostPwEntry));
                            IArgumentsFormatter argsFormatter = new RemoteDesktopArgumentsFormatter() {
                                FullScreen = true,
                                UseConsole = true,
                                IsOlderVersion = RDCIsOlderVersion
                            };
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                            ProcessUtils.StartDetached(new CmdKeyUnregisterArgumentsFormatter() {
                                IncludePath = true
                            }.Format(hostPwEntry), RemoveCredentialsDelay);
                        }
                        catch (Exception ex) {
                            log(ex);
                        }
                    }
                );
                menuItems.Add(menuItem);
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
                menuItems.Add(menuItem);
            }
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
                            var sessionFinder = new RegistryPuttySessionFinder(new WindowsRegistryService());
                            IArgumentsFormatter argsFormatter = new PuttyArgumentsFormatter(sshClientPath, sessionFinder, !this.Settings.DisableCLIPasswordForPutty);
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                        }
                        catch (Exception ex) {
                            log(ex);
                        };
                    }
                );
                menuItems.Add(menuItem);
            };
            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.WinSCP)) {
                var winScpPath = !String.IsNullOrEmpty(this.Settings.WinScpPath) ? this.Settings.WinScpPath : QuickConnectUtils.GetWinScpPath();
                var winScpConsoleMenuItem = new ToolStripMenuItem() {
                    Text = OpenWinScpMenuItemText,
                    Image = (System.Drawing.Image)QuickConnectPlugin.Properties.Resources.winscp,
                    Enabled = hostPwEntry.HasIPAddress && !String.IsNullOrEmpty(winScpPath)
                };
                winScpConsoleMenuItem.Click += new EventHandler(
                    delegate(object obj, EventArgs ev) {
                        try {
                            IArgumentsFormatter argsFormatter = new WinScpArgumentsFormatter(winScpPath);
                            ProcessUtils.StartDetached(argsFormatter.Format(hostPwEntry));
                        }
                        catch (Exception ex) {
                            log(ex);
                        };
                    }
                );
                menuItems.Add(winScpConsoleMenuItem);
            };
            return menuItems;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "ToolStripMenuItem object is disposed inside entryContextMenu_Closed method")]
        private ToolStripMenuItem createChangePasswordMenuItem(HostPwEntry hostPwEntry) {
            IPasswordChanger pwChanger = null;
            var hostTypeMapper = new HostTypeMapper(new HostTypeSafeConverter());
            var hostType = hostTypeMapper.Get(hostPwEntry);
            if (hostType == HostType.ESXi && QuickConnectUtils.IsVSpherePowerCLIInstalled()) {
                pwChanger = new ESXiPasswordChanger();
            }
            else if (hostType == HostType.Windows &&
                                !String.IsNullOrEmpty(this.Settings.PsPasswdPath) &&
                                File.Exists(this.Settings.PsPasswdPath) &&
                                PsPasswdWrapper.IsPsPasswdUtility(this.Settings.PsPasswdPath) &&
                                PsPasswdWrapper.IsSupportedVersion(this.Settings.PsPasswdPath)
            ) {
                pwChanger = new WindowsPasswordChanger(new PsPasswdWrapper(this.Settings.PsPasswdPath));
            }
            else if (hostType == HostType.Linux) {
                PuttyOptions puttyOptions = null;
                bool success = PuttyOptions.TryParse(hostPwEntry.AdditionalOptions, out puttyOptions);
                // Disable change password menu item if authentication is done using SSH key file.
                if (!success || (success && !puttyOptions.HasKeyFile())) {
                    int? sshPort = null;
                    if (success) {
                        sshPort = puttyOptions.Port;
                    }
                    pwChanger = new LinuxPasswordChanger() { SshPort = sshPort };
                  }
            }
            var menuItem = new ToolStripMenuItem() {
                Text = ChangePasswordMenuItemText,
                Enabled = hostPwEntry.HasIPAddress && pwChanger != null
            };
            menuItem.Click += new EventHandler(
                delegate(object obj, EventArgs ev) {
                    try {
                        var pwDatabase = new PasswordDatabase(this.pluginHost.Database);
                        var pwChangerService = new PasswordChangerServiceWrapper(pwDatabase, pwChanger, new SystemClock());
                        using (var form = new FormPasswordChanger(hostPwEntry, pwChangerService)) {
                            form.ShowDialog();
                            if (form.Changed) {
                                refreshUI();
                            }
                        }
                    }
                    catch (Exception ex) {
                        log(ex);
                    }
                }
            );
            return menuItem;
        }

        private void refreshUI() {
            Debug.WriteLine(String.Format("[{0}] Call pluginHost.MainWindow.RefreshEntriesList()", GetType().Name));
            this.pluginHost.MainWindow.RefreshEntriesList();
        }

        private void entryContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
            if (this.menuItems != null) {
                foreach (var menuItem in this.menuItems) {
                    this.pluginHost.MainWindow.EntryContextMenu.Items.Remove(menuItem);
                }
                this.menuItems.Dispose();
                this.menuItems = null;
            }
        }

        private void log(Exception ex) {
            Debug.WriteLine(String.Format("[{0}] Error while launching process. Exception: {1}", this.GetType().Name, ex.ToString()));
            MessageBox.Show(String.Format("Error while launching process.\n\nError details: {0}", ex.ToString()), PluginName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
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
            if (this.pluginMenuItemBatchPasswordChanger != null) {
                this.pluginMenuItemBatchPasswordChanger.Click -= this.pluginMenuItemBatchPasswordChangerOnClickEventHandler;
            }
            if (this.resourcesEventHandler != null) {
                AppDomain.CurrentDomain.ResourceResolve -= this.resourcesEventHandler;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    if (this.pluginMenuItem != null) {
                        this.pluginMenuItem.Dispose();
                        this.pluginMenuItem = null;
                    }
                    if (this.pluginMenuItemAbout != null) {
                        this.pluginMenuItemAbout.Dispose();
                        this.pluginMenuItemAbout = null;
                    }
                    if (this.pluginMenuItemOptions != null) {
                        this.pluginMenuItemOptions.Dispose();
                        this.pluginMenuItemOptions = null;
                    }
                    if (this.pluginMenuItemBatchPasswordChanger != null) {
                        this.pluginMenuItemBatchPasswordChanger.Dispose();
                        this.pluginMenuItemBatchPasswordChanger = null;
                    }
                    if (this.menuItems != null) {
                        this.menuItems.Dispose();
                        this.menuItems = null;
                    }
                    this.disposed = true;
                }
            }
        }
    }
}
