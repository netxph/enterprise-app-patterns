using System;
using System.Collections.Generic;
using System.Linq;

namespace Liner.Ticketing.Core
{
    public class Ticket
    {
        private readonly List<Passenger> _passengers;

        public Ticket(Passenger passenger, string bus)
            : this(0, passenger, bus)
        {
        }

        public Ticket(long id, Passenger passenger, string bus)
        {
            if (passenger == null)
            {
                throw new ArgumentNullException(nameof(passenger));
            }

            _passengers = new List<Passenger>();
            _passengers.Add(passenger);

            if (string.IsNullOrEmpty(bus))
            {
                throw new ArgumentNullException(nameof(bus));
            }

            Bus = bus;

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            Id = id;
        }

        public IEnumerable<Passenger> Passengers { get { return _passengers; } }
        public string Bus { get; }
        public long Id { get; }

        public int GetTotalPassengers()
        {
            return Passengers.Count();
        }
    }
}
