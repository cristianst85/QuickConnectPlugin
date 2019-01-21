using System;

namespace QuickConnectPlugin {

    public class PuttyOptions : IEquatable<PuttyOptions> {

        public int? Port { get; set; }
        public String SessionName { get; set; }
        public String KeyFilePath { get; set; }
        public String Command { get; set; }

        public static bool TryParse(String str, out PuttyOptions options) {
            options = new PuttyOptions();

            if (str == null || str.Trim().Length == 0) {
                return false;
            }

            String[] tokens = str.Split(';');

            bool hasAnyArguments = false;

            foreach (var token in tokens) {
                if (token.Trim().StartsWith("key")) {
                    options.KeyFilePath = token.Substring(token.IndexOf(':') + 1).Trim().Trim('\"');
                    hasAnyArguments = true;
                }
                else if (token.Trim().StartsWith("session")) {
                    options.SessionName = token.Substring(token.IndexOf(':') + 1).Trim().Trim('\"');
                    hasAnyArguments = true;
                }
                else if (token.Trim().StartsWith("port")) {
                    options.Port = int.Parse(token.Substring(token.IndexOf(':') + 1).Trim());
                    hasAnyArguments = true;
                }
                else if (token.Trim().StartsWith("command")) {

                    int? port;
                    options.Command = token.Substring(token.IndexOf(':') + 1).Trim();

                    if (TryParsePortFromCommand(options.Command, out port))
                    {
                        options.Port = port.Value;
                    }

                    hasAnyArguments = true;
                }
            }

            return hasAnyArguments;
        }

        private static bool TryParsePortFromCommand(string command, out int? port) {
            bool hasPort = false;
            port = null;

            if (String.IsNullOrEmpty(command)) {
                return false;
            }

            if (command.Contains("-P ")) {
                var portFromCommand = command.Substring(command.IndexOf("-P "));
                portFromCommand = portFromCommand.Substring(3);

                int index = portFromCommand.IndexOf(" ");
                portFromCommand = portFromCommand.Substring(0, index > 0 ? index : portFromCommand.Length).Trim();

                int parsedPort;
                if (int.TryParse(portFromCommand, out parsedPort)) {
                    port = parsedPort;
                    hasPort = true;
                }
            }

            string forwarding = null;
            if (command.Contains("-L ")) {
                forwarding = "-L ";
            }
            else if (command.Contains("-R ")) {
                forwarding = "-R ";
            }

            if (forwarding != null) {
                var portFromCommand = command.Substring(command.IndexOf(forwarding));
                portFromCommand = portFromCommand.Substring(3);

                int index = portFromCommand.IndexOf(" ");
                portFromCommand = portFromCommand.Substring(0, index > 0 ? index : portFromCommand.Length).Trim();
                portFromCommand = portFromCommand.Substring(portFromCommand.LastIndexOf(":")).TrimStart(':');

                int parsedPort;
                if (int.TryParse(portFromCommand, out parsedPort)) {
                    port = parsedPort;
                    hasPort = true;
                }
            }

            return hasPort;
        }


        public bool CommandContainsPort {
            get {
                int? port;
                return PuttyOptions.TryParsePortFromCommand(this.Command, out port);
            }
        }

        public bool HasKeyFile() {
            return !String.IsNullOrEmpty(KeyFilePath);
        }

        public bool HasCommand() {
            return !String.IsNullOrEmpty(Command);
        }

        public bool CommandContains(string argument) {
            return HasCommand() && this.Command.Contains(argument);
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
                    this.KeyFilePath == other.KeyFilePath &&
                    this.Command == other.Command;
            }
        }
    }
}
