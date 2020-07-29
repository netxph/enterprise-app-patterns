using FluentAssertions;
using Liner.Ticketing.Core;
using Xunit;

namespace Liner.Ticketing.Tests
{
    public class TicketTests
    {
        public class Init_Should
        {
            [Fact]
            public void RequireParams()
            {
                var ticket = new Ticket(
                    passenger: new Passenger("John Doe", 22),
                    bus: "L0820200731");

                ticket.Bus.Should().Be("L0820200731");
                ticket.Passengers.Should().HaveCount(1);
            }

            [Fact]
            public void IDIsZeroByDefault()
            {
                var ticket = new Ticket(
                    passenger: new Passenger("John Doe", 22),
                    bus: "L0820200731");

                ticket.Id.Should().Be(0);
            }

            [Fact]
            public void AcceptId()
            {
                var ticket = new Ticket(
                    id: 1,
                    passenger: new Passenger("John Doe", 22),
                    bus: "L0820200731");

                ticket.Id.Should().Be(1);
            }
        }
    }
}
