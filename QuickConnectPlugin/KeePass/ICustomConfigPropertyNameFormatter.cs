using System;

namespace QuickConnectPlugin.KeePass {

    public interface ICustomConfigPropertyNameFormatter {

        String Format(String propertyName);
    }
}
