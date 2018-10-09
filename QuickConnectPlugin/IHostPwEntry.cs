using System;
using System.Collections.Generic;

namespace QuickConnectPlugin {

    public interface IHostPwEntry {
        ICollection<ConnectionMethodType> ConnectionMethods { get; }
        string GetPassword();
        string GetUsername();
        bool HasConnectionMethods { get; }
        bool HasIPAddress { get; }
        string IPAddress { get; }
        string AdditionalOptions { get; }
        void UpdatePassword(string newPassword);
        DateTime LastModificationTime { get; set; }
    }
}
