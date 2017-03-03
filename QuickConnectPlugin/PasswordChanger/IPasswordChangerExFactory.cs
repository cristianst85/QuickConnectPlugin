namespace QuickConnectPlugin.PasswordChanger {

    public interface IPasswordChangerExFactory {

        IPasswordChangerEx Create(HostType hostType);
    }
}
