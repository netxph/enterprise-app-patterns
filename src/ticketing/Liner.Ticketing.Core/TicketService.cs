using System;

namespace Liner.Ticketing.Core
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _repository;
        private IInventoryClient _inventory;

        public TicketService(ITicketRepository repository, IInventoryClient inventory)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public void Book(string bus, Passenger passenger)
        {
            var ticket = new Ticket(passenger, bus);

            _repository.Insert(ticket);
            _inventory.Hold(ticket.Bus, ticket.GetTotalPassengers());
        }
    }
}
