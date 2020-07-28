using System;

namespace Liner.Inventory
{
    public class Bus
    {
        public Route Route { get; }
        public DateTime Schedule { get; }

        public Bus(Route route, DateTime schedule)
        {
            Route = route ?? throw new ArgumentNullException(nameof(route));
            Schedule = schedule;
        }
    }
}
