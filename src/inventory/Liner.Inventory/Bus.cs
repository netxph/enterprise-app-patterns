using System;

namespace Liner.Inventory
{
    public class Bus
    {
        public Route Route { get; }
        public DateTime Schedule { get; }
        public int Slots { get; }

        public Bus(Route route, DateTime schedule, int slots)
        {
            Route = route ?? throw new ArgumentNullException(nameof(route));
            Schedule = schedule;

            if(slots < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(slots));
            }

            Slots = slots;
        }
    }
}
