namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerHostPwEntry : IHasTitle, IHostPwEntry {

        HostType HostType { get; }
    }
}
