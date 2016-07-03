namespace QuickConnectPlugin.PasswordChanger {

    public class NullPasswordChangerFactory : IPasswordChangerFactory {

        public IPasswordChanger Create(HostType hostType) {
            return new NullPasswordChanger();
        }
    }
}
