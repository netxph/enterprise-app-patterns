using FluentAssertions;
using Liner.Ticketing.Core;
using Xunit;

namespace Liner.Ticketing.Tests
{
    public class PassengerTests
    {
        public class Init_Should
        {
            [Fact]
            public void RequireParams()
            {
                var passenger = new Passenger("John Doe", 22);

                passenger.Name.Should().Be("John Doe");
                passenger.Age.Should().Be(22);
            }
        }
    }
}
