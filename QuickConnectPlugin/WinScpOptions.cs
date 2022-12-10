using QuickConnectPlugin.WinScp;
using System;

namespace QuickConnectPlugin
{
    public class WinScpOptions
    {
        public int? Port { get; set; }

        public string KeyFilePath { get; set; }

        public Protocol? Protocol { get; set; }

        public static bool TryParse(string str, out WinScpOptions options)
        {
            var puttyOptions = new PuttyOptions();

            if (PuttyOptions.TryParse(str, out puttyOptions))
            {
                options = new WinScpOptions()
                {
                    Port = puttyOptions.Port,
                    KeyFilePath = puttyOptions.KeyFilePath
                };

                TrySetProtocol(str, ref options);
                return true;
            }

            options = new WinScpOptions();

            if (TrySetProtocol(str, ref options))
            {
                return true;
            }

            options = null;
            return false;
        }

        private static bool TrySetProtocol(string str, ref WinScpOptions options)
        {
            if (str == null || str.Trim().Length == 0)
            {
                return false;
            }

            string[] tokens = str.Split(';');

            foreach (var token in tokens)
            {
                if (token.Trim().StartsWith("protocol"))
                {
                    var protocolString = token.Substring(token.IndexOf(':') + 1).Trim().Trim('\"');
                    Protocol protocol;

                    if (Enum.TryParse(protocolString, true, out protocol))
                    {
                        if (options == null)
                        {
                            options = new WinScpOptions();
                        }

                        options.Protocol = protocol;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasKeyFile()
        {
            return !string.IsNullOrEmpty(KeyFilePath);
        }
    }
}
