using System;

namespace QuickConnectPlugin {

    public static class PuttyOptionsParser {

        public static bool TryParse(String str, out PuttyOptions options) {
            return internalParse(str, out options);
        }

        private static bool internalParse(String str, out PuttyOptions options) {
            options = new PuttyOptions();
            if (str == null) {
                return false;
            }
            if (str.Trim(' ').Length == 0) {
                return false;
            }
            String[] tokens = str.Split(';');
            foreach (String token in tokens) {
                if (token.Contains(":")) {
                    String[] optionNameValue = token.Split(':');
                    if (optionNameValue.Length == 2 && optionNameValue[0].Trim().Equals("session")) {
                        options = new PuttyOptions() {
                            SessionName = optionNameValue[1].Trim('\"')
                        };
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
