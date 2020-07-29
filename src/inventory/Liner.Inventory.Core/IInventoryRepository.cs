using System;

namespace Liner.Inventory.Core
{
    public interface IInventoryRepository
    {
        Buses GetByDate(DateTime date);
        void Update(Bus bus);
        Bus GetById(string id);
    }
}
