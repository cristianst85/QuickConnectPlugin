# Changelog

## v0.5.2 (2019-07-25)
- Bug fix: WinSCP - password must be URL encoded. Fixes #29.
- Shortcut keys can be configured to launch RDP/PuTTY/WnSCP. Fixes #23.
- Pass custom command line arguments for Putty. Fixes #27.
- Other code optimizations and improvements.

## v0.4.4 (2018-10-12)
- Enable compatibility with KeePass version 2.40.
- Renci.SshNet.dll library was updated from version 2016.0.0 to 2016.1.0.
- Bug fix: LastModificationTime field was not updated after changing the password.

**NOTE:** KeePass version ≥ 2.40 is now required.

## v0.4.3 (2018-03-31)
- Bug fix: Password changing for Linux hosts for non-root users was not working.
- Bug fix: Shell output is included in the error message when changing the password for Linux hosts fails (was always null).
- Other code optimizations and improvements.

## v0.4.2 (2017-08-27)
- Bug fix: Passwords are enclosed in double quotes with WinSCP. Fixes an issue with passwords that contain special characters.

## v0.4.1 (2017-04-02)
- Improved compatibility with KPEntryTemplates plugin.
- Added support for using SSH key files to connect via PuTTY/WinSCP.
- Improved support for changing passwords for Linux hosts.
- Other minor bug fixes and improvements.

## v0.4.0-rc.2 (2016-09-13)
- Added support for changing passwords for Linux hosts.
- Third-party library 'VMware.Vim.dll' (vShpere PowerCLI) is not mandatory when using the .plgx version of the plugin.
- Bug fix (previously incomplete): Stored credentials were not removed after connecting via RDP.
- Other minor bug fixes and improvements.
 
**NOTE:** .NET Framework 3.5 is now required when using the .dll version of the plugin.

## v0.4.0-rc.1 (2016-08-29)
- Added support for changing passwords for Windows and ESXi hosts.
- Bug fix: Stored credentials were not removed after connecting via RDP.
- Minor UI fixes.

## v0.3.0-rc.4 (2016-07-03)
- Added WinSCP support for connecting to linux hosts.
- Default port can be overridden via additional options when connecting with PuTTY.
- Minor UI fix.

## v0.3.0-rc.3 (2016-05-25)
- Bug fix: Unescape session names containing special characters.

## v0.3.0-rc.2 (2016-05-11)
- Bug fix: Removed '-pw' switch and password when connecting with PuTTY via Telnet.
- Minor UI fix.

## v0.3.0-rc.1 (2016-04-13)
- Added support for detecting connection method by specifying the protocol name (e.g.: ssh, telnet, rdp) instead of OS name/type.
- Added support for specifying additional options (e.g.: session name) to load with PuTTY.
- Other code optimizations and improvements.

## v0.2.5 (2016-03-22)
- Bug fix: Passwords are enclosed in double quotes with PuTTY. Fixes an issue with passwords that contain white-spaces.

## v0.2.4 (2016-03-18)
- Bug fix: Referenced fields (username/password) are properly compiled.

## v0.2.3 (2016-02-22)
- Minor improvements.

## v0.2.2 (2016-02-20)
- Added UpdateUrl so that KeePass can check for plugin updates.

## v0.2.1 (2016-02-20)
- Minor improvements and bug fixes.

## v0.2.0 (2016-02-19)
- Added the ability to configure plugin options.
- Other code optimizations and minor improvements.

## v0.1.0 (2016-02-08)
- First version. No release history before this.