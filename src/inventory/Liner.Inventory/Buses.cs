using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Liner.Inventory
{
    public class Buses : IEnumerable<Bus>
    {
        private readonly List<Bus> _buses;

        public Buses()
            : this(new List<Bus>())
        {
        }

        public Buses(IEnumerable<Bus> buses)
        {
            _buses = new List<Bus>(buses);
        }

        public IEnumerator<Bus> GetEnumerator()
        {
            return _buses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Bus bus)
        {
            if (bus == null)
            {
                throw new ArgumentNullException(nameof(bus));
            }

            _buses.Add(bus);
        }

        public Buses GetAvailable(Route route, DateTime schedule, int paxCount)
        {
            var results = _buses.Where(b => 
                b.Route.Equals(route) &&
                b.Schedule.Date.Equals(schedule.Date) &&
                b.Slots >= paxCount);

            return new Buses(results);
        }
    }
}
