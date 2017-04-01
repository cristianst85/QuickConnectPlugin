namespace QuickConnectPlugin.PasswordChanger {
    
    public interface IHostTypeConverter {

        HostType Convert(ConnectionMethodType connectionMethod);
    }
}
