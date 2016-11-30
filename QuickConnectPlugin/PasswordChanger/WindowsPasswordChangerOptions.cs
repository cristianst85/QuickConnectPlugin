using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class WindowsPasswordChangerOptions : IEquatable<WindowsPasswordChangerOptions> {

        public WindowsADSIProvider? Provider { get; set; }

        public static bool TryParse(String str, out WindowsPasswordChangerOptions options) {
            options = new WindowsPasswordChangerOptions();

            if (str == null || str.Trim(' ').Length == 0)
            {
                return false;
            }
            
            String[] tokens = str.Split(';');

            bool hasAnyOptions = false;

            foreach (var token in tokens) {
               if (token.Trim().StartsWith("provider")) {
                    var nameValue = token.Split(':');

                    if (nameValue.Length == 2) {
                        if (nameValue[1].Trim().Equals("WinNT")) {
                            options.Provider = WindowsADSIProvider.WinNT;
                            hasAnyOptions = true;
                        }
                    }
                }
            }

            return hasAnyOptions;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as WindowsPasswordChangerOptions);
        }

        public bool Equals(WindowsPasswordChangerOptions other) {
            if (other == null) {
                return false;
            }
            else {
                return this.Provider == other.Provider;
            }
        }
    }
}
