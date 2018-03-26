using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace QuickConnectPlugin {

    internal static class QuickConnectUtils {

        internal static String GetVSphereClientPath() {
            RegistryKey regKey = null;
            try {
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\");
                if (regKey == null) {
                    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\");
                }
                if (regKey != null) {
                    using (RegistryKey subRegKey = regKey.OpenSubKey("VMware, Inc.\\VMware Virtual Infrastructure Client\\")) {
                        if (subRegKey != null) {
                            String path = (String)subRegKey.GetValue("LauncherPath", null);
                            return Path.Combine(path, "VpxClient.exe");
                        }
                        return null;
                    }
                }
                return null;
            }
            catch {
                throw;
            }
            finally {
                if (regKey != null) {
                    regKey.Close();
                }
            }
        }

        internal static bool IsVSpherePowerCLIInstalled() {
            return !String.IsNullOrEmpty(GetVSpherePowerCLIPath());
        }

        internal static string GetVSpherePowerCLIPath() {
            RegistryKey regKey = null;
            try {
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\");
                if (regKey == null) {
                    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\");
                }
                if (regKey != null) {
                    using (RegistryKey subRegKey = regKey.OpenSubKey("VMware, Inc.\\VMware vSphere PowerCLI\\")) {
                        if (subRegKey != null) {
                            return (String)subRegKey.GetValue("InstallPath", null);
                        }
                        return null;
                    }
                }
                return null;
            }
            catch {
                throw;
            }
            finally {
                if (regKey != null) {
                    regKey.Close();
                }
            }
        }

        internal static bool IsOlderRemoteDesktopConnectionVersion() {
            var fvi = FileVersionInfo.GetVersionInfo(Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"));
            return new Version(fvi.ProductVersion) < new Version("6.0.6001");
        }

        internal static String GetPuttyPath() {
            String filePath64 = @"C:\Program Files (x86)\PuTTY\putty.exe";
            String filePath32 = @"C:\Program Files\PuTTY\putty.exe";
            if (File.Exists(filePath64)) {
                return filePath64;
            }
            else if (File.Exists(filePath32)) {
                return filePath32;
            }
            else {
                return null;
            }
        }

        internal static String GetWinScpPath() {
            String filePath64 = @"C:\Program Files (x86)\WinSCP\WinSCP.exe";
            String filePath32 = @"C:\Program Files\WinSCP\WinSCP.exe";
            if (File.Exists(filePath64)) {
                return filePath64;
            }
            else if (File.Exists(filePath32)) {
                return filePath32;
            }
            else {
                return null;
            }
        }
    }
}