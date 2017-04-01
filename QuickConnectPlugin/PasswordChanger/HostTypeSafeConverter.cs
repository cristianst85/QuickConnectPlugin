using System;

namespace QuickConnectPlugin.PasswordChanger {

    public class HostTypeSafeConverter : HostTypeConverter {

        public override HostType Convert(ConnectionMethodType connectionMethod) {
            try {
                return base.Convert(connectionMethod);
            }
            catch (NotSupportedException) {
                return HostType.Unknown;
            }
        }
    }
}
