using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace QuickConnectPlugin {

    public static class QuickConnectUtils {

        public static String GetVSphereClientPath() {
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

        public static bool IsOlderRemoteDesktopConnectionVersion() {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"));
            return new Version(fvi.ProductVersion) < new Version("6.0.6001");
        }

        public static String GetPuttyPath() {
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
    }
}