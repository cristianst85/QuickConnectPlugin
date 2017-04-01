
namespace QuickConnectPlugin.PasswordChanger {
    
    public class FixedHostTypeMapper : IHostTypeMapper {

        public HostType HostType { get; private set; }

        public FixedHostTypeMapper(HostType hostType) {
            this.HostType = hostType;
        }

        public HostType Get(IHostPwEntry hostPwEntry) {
            return this.HostType;
        }
    }
}
