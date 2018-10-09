using System;

namespace DisruptiveSoftware.Time.Clocks {

    public class SystemClock : IClock {

        public DateTime Now {
            get {
                return DateTime.Now;
            }
        }
    }
}
