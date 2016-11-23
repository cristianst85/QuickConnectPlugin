using System;

namespace QuickConnectPlugin {

    public class PuttyOptions : IEquatable<PuttyOptions> {

        public int? Port { get; set; }
        public String SessionName { get; set; }
        public String KeyFilePath { get; set; }

        public bool HasKeyFile() {
            return !String.IsNullOrEmpty(KeyFilePath);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PuttyOptions);
        }

        public bool Equals(PuttyOptions other) {
            if (other == null) {
                return false;
            }
            else {
                return
                    this.Port == other.Port &&
                    this.SessionName == other.SessionName &&
                    this.KeyFilePath == other.KeyFilePath;
            }
        }
    }
}
