namespace Liner.Ticketing.Api
{
    internal class TicketRequest
    {
        public TicketRequest()
        {
        }

        public string Bus { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}