using System;

namespace Liner.Inventory
{
    public interface IInventoryRepository
    {
        Buses Get(DateTime date);
    }
}
