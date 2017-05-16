using System;

namespace QuickConnectPlugin {

    public interface IFieldMapper {

        String HostAddress { get; }
        String ConnectionMethod { get; }
        String AdditionalOptions { get; }
        
    }
}
