namespace QuickConnectPlugin.PasswordChanger {
    
    public interface IHostTypeMapper {

        HostType Get(IHostPwEntry hostPwEntry);
    }
}
