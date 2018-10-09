using System;

namespace DisruptiveSoftware.Time.Clocks {

    public interface IClock {

        DateTime Now { get; }
    }
}
