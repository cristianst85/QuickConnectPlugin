using System.Collections.Generic;

namespace QuickConnectPlugin.PasswordChanger {

    public class HostTypeMapper : IHostTypeMapper {

        private IHostTypeConverter converter;

        public HostTypeMapper(IHostTypeConverter converter) {
            this.converter = converter;
        }

        public HostType Get(IHostPwEntry hostPwEntry) {
            if (hostPwEntry.HasConnectionMethods) {
                return this.converter.Convert(new List<ConnectionMethodType>(hostPwEntry.ConnectionMethods)[0]);
            }
            else {
                return HostType.Unknown;
            }
        }
    }
}
