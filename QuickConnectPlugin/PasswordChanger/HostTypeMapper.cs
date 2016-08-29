using System.Collections.Generic;

namespace QuickConnectPlugin.PasswordChanger {

    public class HostTypeMapper : IHostTypeMapper {

        public HostType Get(IHostPwEntry hostPwEntry) {
            if (hostPwEntry.HasConnectionMethods) {
                return HostTypeUtils.Convert(new List<ConnectionMethodType>(hostPwEntry.ConnectionMethods)[0]);
            }
            else {
                return HostType.Unknown;
            }
        }
    }
}
