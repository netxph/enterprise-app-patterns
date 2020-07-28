using System;
using Xunit;
using FluentAssertions;
using Moq;
using Liner.Inventory;

namespace Liner.Inventory.Tests
{
    public class InventoryServiceTests
    {
        public class Search_Should
        {

            [Fact]
            public void ReturnsNone()
            {
                var repository = new Mock<IInventoryRepository>();
                repository
                    .Setup(r => r.Get(It.IsAny<DateTime>()))
                    .Returns(new Buses());

                var sut = new InventoryService(repository.Object);

                var buses = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                buses.Should().BeEmpty();

            }

            [Fact]
            public void ReturnsMatch()
            {
                var buses = new Buses();
                buses.Add(new Bus(new Route("Manila", "Laoag")));

                var repository = new Mock<IInventoryRepository>();
                repository
                    .Setup(r => r.Get(new DateTime(2020, 7, 31)))
                    .Returns(() => buses);

                var sut = new InventoryService(repository.Object);

                var result = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                result.Should().HaveCount(1);
            }

            [Fact]
            public void ReturnsNone_WhenRouteNotMatch()
            {
                var buses = new Buses();
                buses.Add(new Bus(
                    route: new Route("Laoag", "Manila")));

                var repository = new Mock<IInventoryRepository>();
                repository
                    .Setup(r => r.Get(new DateTime(2020, 7, 31)))
                    .Returns(() => buses);

                var sut = new InventoryService(repository.Object);

                var result = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                result.Should().HaveCount(1);
            }

        }

        public class BusTests
        {
            public class Init_Should
            {
                [Fact]
                public void RequireRoute()
                {
                    var bus = new Bus(
                        new Route("Manila", "Laoag"));

                    bus.Route.Origin.Should().Be("Manila");
                    bus.Route.Destination.Should().Be("Laoag");
                }
            }
        }

        public class RouteTests
        {
            public class Init_Should
            {
                [Fact]
                public void Require_OriginDestination()
                {
                    var route = new Route("Manila", "Laoag");
                    route.Origin.Should().Be("Manila");
                    route.Destination.Should().Be("Manila");
                }
            }
        }

    }
}
