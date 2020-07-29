using System;

namespace Liner.Inventory.Core
{
    public interface IInventoryService
    {
        Buses Search(Route route, DateTime schedule, int paxCount);
        void Hold(string busId, int paxCount);
    }
}