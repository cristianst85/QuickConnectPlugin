using System;
using System.Collections.Generic;
using QuickConnectPlugin.PasswordChanger.Services;
using QuickConnectPlugin.Workers;

namespace QuickConnectPlugin.PasswordChanger {

    public delegate void PasswordChangedEventHandler(object sender, BatchPasswordChangerEventArgs e);
    public delegate void PasswordChangeErrorEventHandler(object sender, BatchPasswordChangerErrorEventArgs e);
    public delegate void PasswordChangeCompletedEventHandler(object sender, EventArgs e);

    public class BatchPasswordChangerWorker : CancelableWorker {

        public bool SaveDatabaseAfterEachUpdate { get; set; }

        public event PasswordChangedEventHandler Changed;
        public event PasswordChangeErrorEventHandler Error;
        public event PasswordChangeCompletedEventHandler Completed;

        private IPasswordChangerService service;
        private IList<IHostPwEntry> entries;
        private String newPassword;

        public BatchPasswordChangerWorker(IPasswordChangerService service, ICollection<IHostPwEntry> entries, String newPassword) {
            this.service = service;
            this.entries = new List<IHostPwEntry>(entries);
            this.newPassword = newPassword;
        }

        protected override void OnRun() {
            bool databaseIsDirty = false;
            for (int i = 0; i < this.entries.Count; i++) {
                var entry = this.entries[i];
                try {
                    this.service.ChangePassword(entry, this.newPassword);
                    if (this.SaveDatabaseAfterEachUpdate) {
                        this.service.SaveDatabase();
                    }
                    else {
                        databaseIsDirty = true;
                    }
                    this.OnPasswordChanged(entry, i);
                }
                catch (Exception ex) {
                    this.OnPasswordChangeError(entry, ex, i);
                }

                if (this.WasCanceled) {
                    break;
                }
            }

            if (databaseIsDirty) {
                this.service.SaveDatabase();
            }

            this.OnCompleted();
        }

        protected virtual void OnPasswordChanged(IHostPwEntry hostPwEntry, int index) {
            PasswordChangedEventHandler handler = Changed;
            if (handler != null) {
                handler(this, new BatchPasswordChangerEventArgs(hostPwEntry) {
                    ProcessedEntries = index + 1,
                    TotalEntries = this.entries.Count
                });
            }
        }

        protected virtual void OnPasswordChangeError(IHostPwEntry hostPwEntry, Exception ex, int index) {
            PasswordChangeErrorEventHandler handler = Error;
            if (handler != null) {
                handler(this, new BatchPasswordChangerErrorEventArgs(hostPwEntry, ex) {
                    ProcessedEntries = index + 1,
                    TotalEntries = this.entries.Count
                });
            }
        }

        protected virtual void OnCompleted() {
            PasswordChangeCompletedEventHandler handler = Completed;
            if (handler != null) {
                handler(this, new EventArgs());
            }
        }
    }
}
