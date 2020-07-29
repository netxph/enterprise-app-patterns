using Liner.Inventory.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liner.Inventory
{
    public class InMemoryInventoryRepository : IInventoryRepository
    {
        private static List<Bus> _memory;

        static InMemoryInventoryRepository()
        {
            _memory = new List<Bus>()
            {
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 10, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 12, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 14, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 16, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 18, 0, 0),
                    slots: 15),
                new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 20, 0, 0),
                    slots: 15),
            };
        }

        public Buses GetByDate(DateTime date)
        {
            return new Buses(_memory.Where(b => b.Schedule.Date.Equals(date)));
        }

        public Bus GetById(string id)
        {
            return _memory.FirstOrDefault(b => b.Id.Equals(id));
        }

        public void Update(Bus bus)
        {
            _memory.RemoveAll(b => b.Id == bus.Id);
            _memory.Add(bus);
        }
    }
}
