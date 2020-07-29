namespace Liner.Ticketing.Core
{
    public interface ITicketService
    {
        void Book(string bus, Passenger passenger);
    }
}