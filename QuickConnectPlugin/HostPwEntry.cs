using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KeePassLib;

namespace QuickConnectPlugin {

    public class HostPwEntry {

        private String ipAddress;
        public String IPAddress {
            get {
                if (this.ipAddress == null) {
                    this.ipAddress = this.pwEntry.Strings.ReadSafe(this.hostAddressFieldName);
                }
                return ipAddress;
            }
        }

        private IList<ConnectionMethodType> connectionMethods = null;
        public ICollection<ConnectionMethodType> ConnectionMethods {
            get {
                if (this.connectionMethods == null) {
                    var value = this.pwEntry.Strings.ReadSafe(this.connectionMethodFieldName);
                    this.connectionMethods = new List<ConnectionMethodType>(ConnectionMethodTypeUtils.GetConnectionMethodsFromString(value));
                }
                return new Collection<ConnectionMethodType>(this.connectionMethods);
            }
        }

        private PwEntry pwEntry;
        private PwDatabase pwDatabase;
        private String connectionMethodFieldName;
        private String hostAddressFieldName;

        public HostPwEntry(PwEntry pwEntry, PwDatabase pwDatabase, String connectionMethodFieldName, String hostAddressFieldName) {
            this.pwEntry = pwEntry;
            this.pwDatabase = pwDatabase;
            this.connectionMethodFieldName = connectionMethodFieldName;
            this.hostAddressFieldName = hostAddressFieldName;
        }

        public bool HasIPAddress {
            get {
                return !String.IsNullOrEmpty(this.IPAddress);
            }
        }

        public bool HasConnectionMethods {
            get {
                return this.ConnectionMethods.Count > 0;
            }
        }

        public String GetUsername() {
            return PwEntryUtils.ReadCompiledSafeString(this.pwDatabase, this.pwEntry, "UserName");
        }

        public String GetPassword() {
            return PwEntryUtils.ReadCompiledSafeString(this.pwDatabase, this.pwEntry, "Password");
        }
    }
}
