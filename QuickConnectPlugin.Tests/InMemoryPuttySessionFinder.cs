using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace QuickConnectPlugin.Tests {

    public class InMemoryPuttySessionFinder : IPuttySessionFinder {

        public IList<String> Sessions { get; private set; }

        public InMemoryPuttySessionFinder() {
            this.Sessions = new Collection<String>();
        }

        public ICollection<string> Find(string pattern) {
            ICollection<String> results = new Collection<String>();
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (String session in this.Sessions) {
                if (regex.IsMatch(session)) {
                    results.Add(session);
                }
            }
            return results;
        }
    }
}
