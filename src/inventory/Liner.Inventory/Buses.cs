using System;
using System.Collections.Generic;
using System.Collections;

namespace Liner.Inventory
{
    public class Buses : IEnumerable<Bus>
    {
        private readonly List<Bus> _buses;

        public Buses()
        {
            _buses = new List<Bus>();
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
    }
}
