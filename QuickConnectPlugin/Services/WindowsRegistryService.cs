using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace QuickConnectPlugin.Services {

    public class WindowsRegistryService : IRegistryService {

        public ICollection<String> GetPuttySessions() {
            ICollection<String> results = new Collection<String>();
            using (RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\SimonTatham\\PuTTY\\Sessions")) {
                if (key != null) {
                    foreach (String sessionName in key.GetSubKeyNames()) {
                        results.Add(Uri.UnescapeDataString(sessionName));
                    }
                }
            }
            return results;
        }
    }
}
