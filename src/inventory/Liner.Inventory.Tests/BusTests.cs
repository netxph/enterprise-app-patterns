using Xunit;
using FluentAssertions;
using System;
using Liner.Inventory.Core;

namespace Liner.Inventory.Tests
{
    public class BusTests
    {
        public class Init_Should
        {
            [Fact]
            public void RequireParams()
            {
                var bus = new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    1);

                bus.Route.Origin.Should().Be("Manila");
                bus.Route.Destination.Should().Be("Laoag");
                bus.Schedule.Should().Be(new DateTime(2020, 7, 31, 8, 0, 0));
                bus.Slots.Should().Be(1);
            }

            [Fact]
            public void GenerateId()
            {
                var bus = new Bus(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    1);

                bus.Id.Should().Be("L0820200731");

            }
        }
    }

}
