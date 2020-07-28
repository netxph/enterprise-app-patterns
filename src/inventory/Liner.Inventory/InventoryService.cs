using System;

namespace Liner.Inventory
{
    public class InventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Buses Search(Route route, DateTime schedule, int paxCount)
        {
            var buses = _repository.Get(schedule.Date);

            return buses;
        }
    }
}
