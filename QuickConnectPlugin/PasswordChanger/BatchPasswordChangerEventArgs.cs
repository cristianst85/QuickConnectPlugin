using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class BatchPasswordChangerEventArgs : EventArgs {

        public IHostPwEntry HostPwEntry { get; private set; }
        public int ProcessedEntries { get; set; }
        public int TotalEntries { get; set; }

        public BatchPasswordChangerEventArgs(IHostPwEntry hostPwEntry) {
            this.HostPwEntry = hostPwEntry;
        }
    }
}
