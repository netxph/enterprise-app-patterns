using System;
using Xunit;
using FluentAssertions;
using Liner.Inventory.Core;

namespace Liner.Inventory.Tests
{
    public class BusesTests
    {
        public class Add_Should
        {
            [Fact]
            public void BeSuccessful()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 31, 8, 0, 0),
                        1));
            }

            [Fact]
            public void ThrowException_WhenBusIsNull()
            {
                var buses = new Buses();

                Action sut = () => buses.Add(null);

                sut.Should().Throw<ArgumentNullException>();
            }
        }

        public class GetAvailable_Should
        {
            
            [Fact]
            public void BeEmpty_WhenRouteNotMatch()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 31, 8, 0, 0),
                        1));

                var sut = buses.GetAvailable(
                    route: new Route("Laoag", "Manila"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                sut.Should().BeEmpty();
            }

            [Fact]
            public void BeEmpty_WhenDateNotMatch()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 30, 8, 0, 0),
                        1));

                var sut = buses.GetAvailable(
                    new Route("Laoag", "Manila"),
                    new DateTime(2020, 7, 31, 10, 0, 0),
                    1);

                sut.Should().BeEmpty();
            }

            [Fact]
            public void BeEmpty_WhenNoSlots()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 31, 8, 0, 0),
                        1));

                var sut = buses.GetAvailable(
                    new Route("Manila", "Laoag"),
                    new DateTime(2020, 7, 31, 10, 0, 0),
                    2);

                sut.Should().BeEmpty();
            }
            
        }

    }
}
