using System;

namespace Liner.Inventory.Core
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Buses Search(Route route, DateTime schedule, int paxCount)
        {
            var buses = _repository.GetByDate(schedule.Date);

            return buses.GetAvailable(route, schedule, paxCount);
        }

        public void Hold(string busId, int paxCount)
        {
            var bus = _repository.GetById(busId);
            bus.Reserve(paxCount);

            _repository.Update(bus);
        }
    }
}
