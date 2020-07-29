namespace Liner.Ticketing.Core
{
    public interface IInventoryClient
    {
        void Hold(string bus, int paxCount);
    }
}
