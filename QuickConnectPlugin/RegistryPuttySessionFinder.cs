using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using QuickConnectPlugin.Services;

namespace QuickConnectPlugin {

    public class RegistryPuttySessionFinder : IPuttySessionFinder {

        private IRegistryService registryService;

        public RegistryPuttySessionFinder(IRegistryService registryService) {
            this.registryService = registryService;
        }

        public ICollection<String> Find(String pattern) {
            ICollection<String> results = new Collection<String>();
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (String session in this.registryService.GetPuttySessions()) {
                if (regex.IsMatch(session)) {
                    results.Add(session);
                }
            }
            return results;
        }
    }
}
