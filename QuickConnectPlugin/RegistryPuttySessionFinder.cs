using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace QuickConnectPlugin {

    public class RegistryPuttySessionFinder : IPuttySessionFinder {

        public ICollection<String> Find(String pattern) {
            if (String.IsNullOrEmpty(pattern)) {
                return new Collection<String>();
            }
            ICollection<String> results = new Collection<String>();
            using (RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\SimonTatham\\PuTTY\\Sessions")) {
                if (key != null) {
                    String[] sessions = key.GetSubKeyNames();
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    foreach (String session in sessions) {
                        if (regex.IsMatch(session)) {
                            results.Add(session);
                        }
                    }
                }
            }
            return results;
        }
    }
}
