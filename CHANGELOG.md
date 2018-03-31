0.4.3

 Bug fix: Password changing for Linux hosts for non-root users was not working.
 Bug fix: Shell output is included in the error message when changing the password for Linux hosts fails (was always null).
 Other code optimizations and improvements.

0.4.2

 Bug fix: Passwords are enclosed in double quotes with WinSCP. Fixes an issue with passwords that contain special characters.

0.4.1

 Improved compatibility with KPEntryTemplates plugin.
 Added support for using SSH key files to connect via PuTTY/WinSCP.
 Improved support for changing passwords for Linux hosts.
 Other minor bug fixes and improvements.

0.4.0-rc.2

 Added support for changing passwords for Linux hosts.
 Third-party library 'VMware.Vim.dll' (vShpere PowerCLI) is not mandatory when using the .plgx version of the plugin.
 Bug fix (previously incomplete): Stored credentials were not removed after connecting via RDP.
 Other minor bug fixes and improvements.
 NOTE: .NET Framework 3.5 is now required when using the .dll version of the plugin.

0.4.0-rc.1

 Added support for changing passwords for Windows and ESXi hosts.
 Bug fix: Stored credentials were not removed after connecting via RDP.
 Minor UI fixes.

0.3.0-rc.4

 Added WinSCP support for connecting to linux hosts.
 Default port can be overridden via additional options when connecting with PuTTY.
 Minor UI fix.

0.3.0-rc.3

 Bug fix: Unescape session names containing special characters.

0.3.0-rc.2

 Bug fix: Removed '-pw' switch and password when connecting with PuTTY via Telnet.
 Minor UI fix.

0.3.0-rc.1

 Added support for detecting connection method by specifying the protocol name (e.g.: ssh, telnet, rdp) instead of OS name/type.
 Added support for specifying additional options (e.g.: session name) to load with PuTTY.
 Other code optimizations and improvements.

0.2.5

 Bug fix: Passwords are enclosed in double quotes with PuTTY. Fixes an issue with passwords that contain white-spaces.

0.2.4

 Bug fix: Referenced fields (username/password) are properly compiled.

0.2.3

 Minor improvements.

0.2.2

 Added UpdateUrl so that KeePass can check for plugin updates.

0.2.1

 Minor improvements and bug fixes.

0.2.0

 Added the ability to configure plugin options.
 Other code optimizations and minor improvements.

0.1.0

 First version. No release history before this.