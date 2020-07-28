using System;

namespace Liner.Inventory.Core
{
    public interface IInventoryRepository
    {
        Buses Get(DateTime date);
    }
}
