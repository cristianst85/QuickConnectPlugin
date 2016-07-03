using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class BatchPasswordChangerErrorEventArgs : EventArgs {

        public IHostPwEntry HostPwEntry { get; private set; }
        public Exception Exception { get; private set; }
        public int ProcessedEntries { get; set; }
        public int TotalEntries { get; set; }

        public BatchPasswordChangerErrorEventArgs(IHostPwEntry hostPwEntry, Exception ex) {
            this.HostPwEntry = hostPwEntry;
            this.Exception = ex;
        }
    }
}
