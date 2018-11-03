# QuickConnect Plugin

QuickConnect is a plugin for [KeePass](http://keepass.info) password manager that allows you to connect to Windows/Linux/ESXi hosts.

[![Latest Release](https://img.shields.io/github/release/cristianst85/quickconnectplugin.svg)](https://github.com/cristianst85/quickconnectplugin/releases/latest)
[![Total Downloads](https://img.shields.io/github/downloads/cristianst85/quickconnectplugin/total.svg?maxAge=86400)](https://github.com/cristianst85/quickconnectplugin/releases/latest)

## Requirements

- Microsoft Windows XP/7/10 with .NET Framework 3.5;
- [KeePass](http://keepass.info) version 2.31 or newer.

## Installation

- Download the [latest](https://github.com/cristianst85/QuickConnectPlugin/releases/latest) release;
- Verify that the checksum for QuickConnectPlugin.plgx matches the one published with the release;
- Copy the QuickConnectPlugin.plgx in the KeePass plugins directory and restart the application.

## Usage

- The plugin adds a new menu item named **QuickConnect** under **Tools** menu;
- Use the **Map Fields** tab in the **Options** dialog to configure the custom fields from which the plugin gets the host address (IP address or hostname) and the connection method;
- Connection method is determined based on the text found in the mapped field. For example, if one of the following strings (case-insensitive) is found, then the corresponding items are added to the entry context menu (right-click):
    * `rdp` or `windows` - *Open Remote Desktop* and *Open Remote Desktop (console)*;
    * `esxi` or `vcenter` - *Open vSphere Client*;
    * `ssh`, `telnet`, `linux` or a known Linux distribution name - *Open PuTTY Console* and *Open WinSCP*.
- Additional options like session name or port can be specified to be used with PuTTY/WinSCP. The syntax is as follows:
    `[{ssh|telnet}|<os_type>[;session:"<regex_pattern>"[;port:<port>[;ssh_key:"<ssh_key_path.ppk>"]]]]`.

Connection method and Additional options can be mapped to the same field. This will avoid cluttering the database with too many custom fields.

<p align="center"><img src="https://raw.github.com/cristianst85/QuickConnectPlugin/master/docs/screenshot.png" alt="QuickConnectPlugin" /></p>

## Password Changer

This feature allows you to change passwords for Windows/Linux/ESXi hosts directly from KeePass.

### Requirements

- [PsPasswd](https://technet.microsoft.com/en-us/sysinternals/bb897543.aspx) utility version 1.22 for Windows hosts.
- [vSphere PowerCLI version 5.8.0](https://my.vmware.com/web/vmware/details?downloadGroup=PCLI58R1&productId=420) for ESXi hosts.

## Security Considerations

- Please take note that when launching *vSphere Client*, *PuTTY*, *WinSCP* or [*PsPasswd*](https://technet.microsoft.com/en-us/sysinternals/bb897543.aspx) (via Password Changer) the plugin exposes the password via command-line arguments and it is visible during the entire lifetime of the child process.

## Repository

The main repository is hosted on [GitHub](https://github.com/cristianst85/QuickConnectPlugin).

## Changelog

See [CHANGELOG](https://github.com/cristianst85/QuickConnectPlugin/blob/master/CHANGELOG.md) file for details.

## Download

You can download compiled binaries from [here](https://github.com/cristianst85/QuickConnectPlugin/releases/) and [here](http://www.disruptivesoftware.ro/projects/QuickConnectPlugin/).

Also, _nightly builds_ are available [here](http://www.disruptivesoftware.ro/projects/QuickConnectPlugin/nightly/).

## License

* The source code in this repository is released under the GNU GPLv2 or later license. See the [bundled LICENSE](https://github.com/cristianst85/QuickConnectPlugin/blob/master/LICENSE) file for details.
* The menu items icons are from Crystal Clear icon set by [Everaldo Coelho](http://www.everaldo.com/) licensed under LGPL v2.1 or later.
* Includes [SSH.NET](https://github.com/sshnet/SSH.NET) library copyrighted by RENCI and released under MIT License.
