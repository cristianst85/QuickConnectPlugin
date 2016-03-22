using System;
using System.Collections.Generic;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class PuttyArgumentsFormatter : IArgumentsFormatter {

        public String ExecutablePath { get; private set; }
        public IPuttySessionFinder PuttySessionFinder { get; private set; }

        public PuttyArgumentsFormatter(String puttyPath, IPuttySessionFinder puttySessionFinder) {
            this.ExecutablePath = puttyPath;
            this.PuttySessionFinder = puttySessionFinder;
        }

        public String Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", this.ExecutablePath);

            PuttyOptions options = null;
            bool success = PuttyOptionsParser.TryParse(hostPwEntry.AdditionalOptions, out options);

            if (success && !String.IsNullOrEmpty(options.SessionName)) {
                ICollection<String> sessionNames = this.PuttySessionFinder.Find(options.SessionName);

                if (sessionNames.Count > 0) {
                    sb.AppendFormat(" -load \"{0}\"", new List<String>(sessionNames)[0]);
                }
            }

            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttySSH)) {
                sb.Append(" -ssh");
            }
            else if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttyTelnet)) {
                sb.Append(" -telnet");
            }

            // Allow passwords with white-spaces.
            sb.AppendFormat(" {0}@{1} -pw \"{2}\"",
                hostPwEntry.GetUsername(),
                hostPwEntry.IPAddress,
                hostPwEntry.GetPassword()
            );

            return sb.ToString();
        }
    }
}
