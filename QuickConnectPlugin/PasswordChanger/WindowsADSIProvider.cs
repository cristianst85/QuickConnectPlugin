namespace QuickConnectPlugin.PasswordChanger {

    /// <summary>
    /// Windows Active Directory Service Interfaces (ADSI) providers.
    /// https://msdn.microsoft.com/en-us/library/aa772235(v=vs.85).aspx
    /// </summary>
    public enum WindowsADSIProvider {

        None = 0,
        WinNT = 1,
        LDAP = 2
    }
}
