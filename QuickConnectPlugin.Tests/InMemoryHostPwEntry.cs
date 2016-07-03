using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickConnectPlugin.Tests {

    public class InMemoryHostPwEntry : IHostPwEntry {

        public String Username { get; set; }
        public String Password { get; set; }
        public string IPAddress { get; set; }
        public string AdditionalOptions { get; set; }

        private IList<ConnectionMethodType> connectionMethods;

        public InMemoryHostPwEntry() {
            this.connectionMethods = new List<ConnectionMethodType>();
        }

        public ICollection<ConnectionMethodType> ConnectionMethods {
            get { return new Collection<ConnectionMethodType>(this.connectionMethods); }
        }

        public string GetPassword() {
            return this.Password;
        }

        public string GetUsername() {
            return this.Username;
        }

        public bool HasConnectionMethods {
            get { return this.ConnectionMethods.Count > 0; }
        }

        public bool HasIPAddress {
            get { return String.IsNullOrEmpty(this.IPAddress); }
        }

        public void UpdatePassword(string newPassword) {
            this.Password = newPassword;
        }
    }
}
