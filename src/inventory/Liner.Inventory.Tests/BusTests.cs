using Xunit;
using FluentAssertions;
using System;

namespace Liner.Inventory.Tests
{
    public class BusTests
    {
        public class Init_Should
        {
            [Fact]
            public void RequireRouteAndSchedule()
            {
                var bus = new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0));

                bus.Route.Origin.Should().Be("Manila");
                bus.Route.Destination.Should().Be("Laoag");
                bus.Schedule.Should().Be(new DateTime(2020, 7, 31, 8, 0, 0));
            }
        }
    }

}
