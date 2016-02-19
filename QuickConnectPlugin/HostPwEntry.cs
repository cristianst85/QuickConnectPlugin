using System;
using KeePassLib;
using System.Collections.Generic;

namespace QuickConnectPlugin {

    public class HostPwEntry {

        public PwEntry PwEntry { get; private set; }
        public String IPAddress { get; private set; }
        public ICollection<ConnectionMethodType> ConnectionMethods { get; private set; }

        public HostPwEntry(PwEntry pwEntry, String ipAddress, ICollection<ConnectionMethodType> connectionMethods) {
            this.PwEntry = pwEntry;
            this.IPAddress = ipAddress;
            this.ConnectionMethods = connectionMethods;
        }

        public bool HasIPAddress() {
            return !String.IsNullOrEmpty(this.IPAddress);
        }

        public String GetUsername() {
            return this.PwEntry.Strings.GetSafe("UserName").ReadString();

        }

        public String GetPassword() {
            return this.PwEntry.Strings.GetSafe("Password").ReadString();
        }
    }
}
