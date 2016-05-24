using System;
using System.Collections.Generic;
using QuickConnectPlugin.Services;

namespace QuickConnectPlugin.Tests.Services {

    public class InMemoryRegistryService : IRegistryService {

        private List<String> sessions = new List<String>();

        public InMemoryRegistryService(ICollection<String> sessions) {
            this.sessions.AddRange(sessions);
        }

        public ICollection<String> GetPuttySessions() {
            return new List<String>(sessions);
        }
    }
}
