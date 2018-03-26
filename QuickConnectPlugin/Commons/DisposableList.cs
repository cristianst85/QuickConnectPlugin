using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickConnectPlugin.Commons {

    internal sealed class DisposableList<T> : List<T>, IDisposable where T : IDisposable {

        private bool disposed;

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    foreach (var item in this) {
                        item.Dispose();
                    }
                    this.Clear();
                    this.disposed = true;
                }
            }
        }
    }
}