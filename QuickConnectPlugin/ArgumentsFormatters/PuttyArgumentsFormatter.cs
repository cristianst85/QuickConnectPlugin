using System;
using System.Collections.Generic;
using System.Text;

namespace QuickConnectPlugin.ArgumentsFormatters {

    public class PuttyArgumentsFormatter : IArgumentsFormatter {

        public String ExecutablePath { get; private set; }
        public bool AppendPassword { get; private set; }
        public IPuttySessionFinder PuttySessionFinder { get; private set; }

        public PuttyArgumentsFormatter(String puttyPath, IPuttySessionFinder puttySessionFinder, bool appendPassword) {
            this.ExecutablePath = puttyPath;
            this.PuttySessionFinder = puttySessionFinder;
            this.AppendPassword = appendPassword;
        }

        public String Format(IHostPwEntry hostPwEntry) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\"{0}\"", this.ExecutablePath);

            string ipAddress = null;
            string port = null;

            if (hostPwEntry.IPAddress.Contains(":")) {
                ipAddress = hostPwEntry.IPAddress.Substring(0, hostPwEntry.IPAddress.IndexOf(':'));
                port = hostPwEntry.IPAddress.Substring(hostPwEntry.IPAddress.IndexOf(':') + 1);
            }
            else {
                ipAddress = hostPwEntry.IPAddress;
            }

            PuttyOptions options = null;
            bool success = PuttyOptions.TryParse(hostPwEntry.AdditionalOptions, out options);

            if (success && options.HasKeyFile()) {
                sb.AppendFormat(" -i \"{0}\"", options.KeyFilePath);
            }

            if (success && !String.IsNullOrEmpty(options.SessionName)) {
                ICollection<String> sessionNames = this.PuttySessionFinder.Find(options.SessionName);

                if (sessionNames.Count > 0) {
                    sb.AppendFormat(" -load \"{0}\"", new List<String>(sessionNames)[0]);
                }
            }

            if (port != null) {
                sb.AppendFormat(" -P {0}", port);
            }

            if (port == null && success && options.Port.HasValue) {
                sb.AppendFormat(" -P {0}", options.Port);
            }

            if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttySSH)) {
                sb.Append(" -ssh");
            }
            else if (hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttyTelnet)) {
                sb.Append(" -telnet");
            }

            sb.AppendFormat(" {0}@{1}", hostPwEntry.GetUsername(), ipAddress);

            // Specifying the password via -pw switch only works with SSH protocol.
            // See: http://the.earth.li/~sgtatham/putty/0.65/htmldoc/Chapter3.html.
            if (this.AppendPassword && hostPwEntry.ConnectionMethods.Contains(ConnectionMethodType.PuttySSH)) {
                // Allow passwords with white-spaces.
                if (!success || (success && !options.CommandContains("-pw "))) {
                    sb.AppendFormat(" -pw \"{0}\"", hostPwEntry.GetPassword());
                }
            }

            if (success && options.HasCommand()) {
                sb.AppendFormat(" {0}", options.Command);
            }

            return sb.ToString();
        }
    }
}
