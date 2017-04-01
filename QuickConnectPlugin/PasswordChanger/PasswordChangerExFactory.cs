namespace QuickConnectPlugin.PasswordChanger {

    public class PasswordChangerExFactory : IPasswordChangerExGenericFactory<IPasswordChangerEx> {

        private IPasswordChangerGenericFactory<IPasswordChanger> passwordChangerFactory;

        public PasswordChangerExFactory(IPasswordChangerGenericFactory<IPasswordChanger> passwordChangerFactory) {
            this.passwordChangerFactory = passwordChangerFactory;
        }

        public IPasswordChangerEx Create() {
            return new PasswordChangerEx(this.passwordChangerFactory.Create());
        }
    }
}
