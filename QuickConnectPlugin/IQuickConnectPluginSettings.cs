using System;

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
        /// Get or sets a value indicating the path of the SSH client path 
        /// used for connecting to Linux hosts.
        /// </summary>
        String SSHClientPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the field name from the KeePass 
        /// database that is used to get the remote host address (ip address 
        /// or hostname).
        /// </summary>
        String HostAddressMapFieldName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating the field name from the KeePass 
        /// database that is used to determine the connection method for 
        /// connecting to the remote host.
        /// </summary>
        String ConnectionMethodMapFieldName { get; set; }

        string WinScpPath { get; set; }

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
