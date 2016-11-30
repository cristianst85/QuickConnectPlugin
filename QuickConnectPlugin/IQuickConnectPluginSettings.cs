using System;
using System.Windows.Forms;

namespace QuickConnectPlugin {

    public interface IQuickConnectPluginSettings {
        /// <summary>
        /// Gets or sets a value indicating whether the plugin is enabled.
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the plugin is run in 
        /// compatible mode. If the value is <c>true</c> the menu items 
        /// are added at the bottom of the context menu, otherwise the menu 
        /// items are added at the top of the context menu.
        /// </summary>
        bool CompatibleMode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the 'Change password'
        /// menu item is shown in the entry context menu.
        /// </summary>
        bool AddChangePasswordMenuItem { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the path of the PuTTY client.
        /// </summary>
        String PuttyPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the path of the WinSCP client.
        /// </summary>
        String WinScpPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the field name from the KeePass 
        /// database that is used to get the remote host address (IP address 
        /// or hostname).
        /// </summary>
        String HostAddressMapFieldName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the field name from the KeePass 
        /// database that is used to determine the connection method for 
        /// connecting to the remote host.
        /// </summary>
        String ConnectionMethodMapFieldName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the field name from the KeePass
        /// database that is used to specify additional options for the 
        /// remote host client.
        /// </summary>
        String AdditionalOptionsMapFieldName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the password is sent 
        /// via command line arguments for Putty.
        /// </summary>
        bool DisableCLIPasswordForPutty { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether shortcut keys are enabled.
        /// </summary>
        bool? EnableShortcutKeys { get; set; }
        /// <summary>
        /// Gets or sets a value indicating shortcut keys for opening Remote Desktop client.
        /// </summary>
        Keys RemoteDesktopShortcutKey { get; set; }
        /// <summary>
        /// Gets or sets a value indicating shortcut keys for opening Putty client.
        /// </summary>
        Keys PuttyShortcutKey { get; set; }
        /// <summary>
        ///  Gets or sets a value indicating shortcut keys for opening WinSCP client.
        /// </summary>
        Keys WinScpShortcutKey { get; set; }
        /// <summary>
        /// Loads the plugin settings.
        /// </summary>
        void Load();
        /// <summary>
        /// Saves the plugin settings.
        /// </summary>
        void Save();

    }
}
