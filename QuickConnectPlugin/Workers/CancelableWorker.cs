using System;

namespace QuickConnectPlugin.Workers {
    
    public abstract class CancelableWorker : Worker, ICancelable {

        private object _locker = new object();
        private volatile bool canceled; 

        public bool WasCanceled {
            get {
                lock (_locker) {
                    return this.canceled;
                }
            }
            private set {
                lock (_locker) {
                    this.canceled = value;
                }
            }
        }

        public void Cancel() {
            this.WasCanceled = true;
        }
    }
}
