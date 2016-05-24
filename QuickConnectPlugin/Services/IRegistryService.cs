using System;
using System.Collections.Generic;

namespace QuickConnectPlugin.Services {

    public interface IRegistryService {

        ICollection<String> GetPuttySessions();
    }
}
