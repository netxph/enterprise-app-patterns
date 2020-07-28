using System;

namespace Liner.Inventory
{
    public class Bus
    {
        public Route Route { get; }

        public Bus(Route route)
        {
            Route = route ?? throw new ArgumentNullException(nameof(route));
        }
    }
}
