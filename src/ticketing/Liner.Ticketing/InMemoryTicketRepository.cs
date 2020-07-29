using Liner.Ticketing.Core;
using System;
using System.Collections.Generic;

namespace Liner.Ticketing
{
    public class InMemoryTicketRepository : ITicketRepository
    {

        private static List<Ticket> _tickets;

        static InMemoryTicketRepository()
        {
            _tickets = new List<Ticket>();
        }

        public void Insert(Ticket ticket)
        {
            _tickets.Add(ticket);
        }
    }
}
