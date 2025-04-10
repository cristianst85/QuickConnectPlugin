﻿# Changelog

## 0.6.1 (2025-03-26)

 - Launching Remote Desktop Connection application will not force the use of full screen anymore. Fixes #21.
 - Updated the default shortcut keys for opening Remote Desktop / PuTTY / WinSCP so that they don't conflict with the default KeePass shortcut keys.
 - Other code optimizations and improvements.

## 0.6.0-rc.1 (2022-12-10)

 - Added the ability to set the protocol for WinSCP. Fixes #35.
 - Renci.SshNet.dll library was updated from version 2016.1.0 to 2020.0.2.
 - Bug fix: Fixed shortcut keys validations.
 - Other code optimizations and improvements.

 **NOTE:** KeePass version ≥ 2.52 is now required.

## 0.5.3 (2020-05-08)

- Enable compatibility with KeePass version 2.45. Fixes #32.

**NOTE:** KeePass version ≥ 2.45 is now required.

## 0.5.2 (2019-08-21)

- Bug fix: Putty - Fixes an issue with passwords containing double-quotes. Fixes #30.
- Bug fix: WinSCP - password must be URL encoded. Fixes #29.
- Shortcut keys can be configured to launch RDP/PuTTY/WnSCP. Fixes #23.
- Pass custom command line arguments for Putty. Fixes #27.
- Other code optimizations and improvements.

## 0.4.4 (2018-10-12)

- Enable compatibility with KeePass version 2.40.
- Renci.SshNet.dll library was updated from version 2016.0.0 to 2016.1.0.
- Bug fix: LastModificationTime field was not updated after changing the password.

**NOTE:** KeePass version ≥ 2.40 is now required.

## 0.4.3 (2018-03-31)

- Bug fix: Password changing for Linux hosts for non-root users was not working.
- Bug fix: Shell output is included in the error message when changing the password for Linux hosts fails (was always null).
- Other code optimizations and improvements.

## 0.4.2 (2017-08-27)

- Bug fix: Passwords are enclosed in double quotes with WinSCP. Fixes an issue with passwords that contain special characters.

## 0.4.1 (2017-04-02)

- Improved compatibility with KPEntryTemplates plugin.
- Added support for using SSH key files to connect via PuTTY/WinSCP.
- Improved support for changing passwords for Linux hosts.
- Other minor bug fixes and improvements.

## 0.4.0-rc.2 (2016-09-13)

- Added support for changing passwords for Linux hosts.
- Third-party library 'VMware.Vim.dll' (vShpere PowerCLI) is not mandatory when using the .plgx version of the plugin.
- Bug fix (previously incomplete): Stored credentials were not removed after connecting via RDP.
- Other minor bug fixes and improvements.
 
**NOTE:** .NET Framework 3.5 is now required when using the .dll version of the plugin.

## 0.4.0-rc.1 (2016-08-29)

- Added support for changing passwords for Windows and ESXi hosts.
- Bug fix: Stored credentials were not removed after connecting via RDP.
- Minor UI fixes.

## 0.3.0-rc.4 (2016-07-03)

- Added WinSCP support for connecting to linux hosts.
- Default port can be overridden via additional options when connecting with PuTTY.
- Minor UI fix.

## 0.3.0-rc.3 (2016-05-25)

- Bug fix: Unescape session names containing special characters.

## 0.3.0-rc.2 (2016-05-11)
- Bug fix: Removed '-pw' switch and password when connecting with PuTTY via Telnet.
- Minor UI fix.

## 0.3.0-rc.1 (2016-04-13)

- Added support for detecting connection method by specifying the protocol name (e.g.: ssh, telnet, rdp) instead of OS name/type.
- Added support for specifying additional options (e.g.: session name) to load with PuTTY.
- Other code optimizations and improvements.

## 0.2.5 (2016-03-22)

- Bug fix: Passwords are enclosed in double quotes with PuTTY. Fixes an issue with passwords that contain white-spaces.

## 0.2.4 (2016-03-18)

- Bug fix: Referenced fields (username/password) are properly compiled.

## 0.2.3 (2016-02-22)

- Minor improvements.

## 0.2.2 (2016-02-20)

- Added UpdateUrl so that KeePass can check for plugin updates.

## 0.2.1 (2016-02-20)

- Minor improvements and bug fixes.

## 0.2.0 (2016-02-19)

- Added the ability to configure plugin options.
- Other code optimizations and minor improvements.

## 0.1.0 (2016-02-08)

- First version. No release history before this.