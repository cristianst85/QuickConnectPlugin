namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerFactory {

        IPasswordChanger Create(HostType hostType);
    }
}
