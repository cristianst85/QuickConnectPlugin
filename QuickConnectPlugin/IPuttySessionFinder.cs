using System;
using System.Collections.Generic;

namespace QuickConnectPlugin {

    public interface IPuttySessionFinder {

        ICollection<String> Find(String pattern);
    }
}
