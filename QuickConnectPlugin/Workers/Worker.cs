using System;

namespace QuickConnectPlugin.Workers {

    public abstract class Worker : IWorker {

        private object _locker = new object();
        private volatile bool running;

        public bool IsRunning {
            get {
                lock (_locker) {
                    return this.running;
                }
            }
            private set {
                lock (_locker) {
                    this.running = value;
                }
            }
        }

        public void Run() {
            if (this.IsRunning) {
                throw new Exception("Worker is already running.");
            }
            this.IsRunning = true;
            try {
                this.OnRun();
            }
            finally {
                this.IsRunning = false;
            }
        }

        protected abstract void OnRun();
    }
}
