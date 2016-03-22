using System;

namespace QuickConnectPlugin.ArgumentsFormatters {
    
    public interface IArgumentsFormatter {

        String Format(IHostPwEntry hostPwEntry);
    }
}
