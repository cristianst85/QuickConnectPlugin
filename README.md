# QuickConnect Plugin

QuickConnect is a plugin for [KeePass](http://keepass.info) password manager that allows you to connect to Windows/Linux/ESXi hosts.

## Requirements

- Microsoft Windows XP/7 with .NET Framework 2.0;
- [KeePass](http://keepass.info) version 2.31 or newer.

## Installation

- Download the latest release;
- Verify that the checksum for QuickConnectPlugin.dll matches the one published with the release;
- Copy the QuickConnectPlugin.dll in the KeePass plugins directory and restart the application.

## Usage

- The plugin adds a new menu item named **QuickConnect** under **Tools** menu;
- Use the **Map Fields** tab in the **Options** dialog to configure the custom fields from which the plugin gets the host address (IP address or hostname) and the connection method;
- Connection method is determined based on the text found in the mapped field. For example, if one of the following strings (case-insensitive) is found, then the corresponding items are added to the entry context menu (right-click):
    * `windows` - *Remote Desktop* and *Open Remote Desktop (console)*;
	* `esxi` or `vcenter` - *Open vSphere Client*;
	* `linux` or a known Linux distribution name - *Open PuTTY Console*.
	 
## Security Considerations

- Please take note that when launching *vSphere Client* or *PuTTY* the plugin exposes the password via command-line arguments and it is visible during the entire lifetime of the child process.

## Repository

The main repository is hosted on [GitHub](https://github.com/cristianst85/QuickConnectPlugin).

## Changelog

See [CHANGELOG](https://github.com/cristianst85/QuickConnectPlugin/blob/master/CHANGELOG.md) file for details.

## Download

You can download compiled binaries from [here](http://www.disruptivesoftware.ro/projects/QuickConnectPlugin/) and [here](https://github.com/cristianst85/QuickConnectPlugin/releases).

## License

* The source code in this repository is released under the GNU GPLv2 or later license. See the [bundled LICENSE](https://github.com/cristianst85/QuickConnectPlugin/blob/master/LICENSE) file for details.
* The menu items icons are from Crystal Clear icon set by [Everaldo Coelho](http://www.everaldo.com/) licensed under LGPL v2.1 or later.
