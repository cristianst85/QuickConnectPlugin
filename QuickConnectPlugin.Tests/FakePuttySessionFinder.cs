using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickConnectPlugin.Tests {

    public class FakePuttySessionFinder : IPuttySessionFinder {

        public IList<String> Sessions { get; private set; }

        public FakePuttySessionFinder() {
            this.Sessions = new Collection<String>();
        }

        public ICollection<string> Find(string pattern) {
            return new List<String>(this.Sessions);
        }
    }
}
