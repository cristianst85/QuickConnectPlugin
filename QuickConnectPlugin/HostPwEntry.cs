using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KeePassLib;

namespace QuickConnectPlugin {

    public class HostPwEntry : IHostPwEntry {

        private String ipAddress;
        public String IPAddress {
            get {
                if (this.ipAddress == null) {
                    this.ipAddress = this.pwEntry.Strings.ReadSafe(this.fieldsMapper.HostAddress);
                }
                return ipAddress;
            }
        }

        private IList<ConnectionMethodType> connectionMethods = null;
        public ICollection<ConnectionMethodType> ConnectionMethods {
            get {
                if (this.connectionMethods == null) {
                    var value = this.pwEntry.Strings.ReadSafe(this.fieldsMapper.ConnectionMethod);
                    this.connectionMethods = new List<ConnectionMethodType>(ConnectionMethodTypeUtils.GetConnectionMethodsFromString(value));
                }
                return new Collection<ConnectionMethodType>(this.connectionMethods);
            }
        }

        private string additionOptions = null;
        public string AdditionalOptions {
            get {
                if (this.additionOptions == null) {
                    this.additionOptions = this.fieldsMapper.AdditionalOptions;
                }
                return this.additionOptions;
            }
        }

        private PwEntry pwEntry;
        private PwDatabase pwDatabase;
        private IFieldMapper fieldsMapper;

        public HostPwEntry(PwEntry pwEntry, PwDatabase pwDatabase, IFieldMapper fieldsMapper) {
            this.pwEntry = pwEntry;
            this.pwDatabase = pwDatabase;
            this.fieldsMapper = fieldsMapper;
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
