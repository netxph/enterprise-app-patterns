using System;
using Xunit;
using FluentAssertions;

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
                        new DateTime(2020, 7, 31, 8, 0, 0)));
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
                        new DateTime(2020, 7, 31, 8, 0, 0)));

                var sut = buses.GetAvailable(
                    route: new Route("Laoag", "Manila"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0));

                sut.Should().BeEmpty();
            }

            [Fact]
            public void BeEmpty_WhenDateNotMatch()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 30, 8, 0, 0)));

                var sut = buses.GetAvailable(
                    new Route("Laoag", "Manila"),
                    new DateTime(2020, 7, 31, 10, 0, 0));

                sut.Should().BeEmpty();
            }
        }

    }
}
