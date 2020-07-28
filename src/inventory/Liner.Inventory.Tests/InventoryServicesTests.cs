using System;
using Xunit;
using FluentAssertions;

namespace Liner.Inventory.Tests
{
    public partial class InventoryServiceTests
    {

        public class Search_Should
        {

            [Fact]
            public void ReturnsMatch()
            {
                InventoryService sut = 
                    new InventoryServiceTestDataBuilder()
                        .UsingMock();

                var result = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                result.Should().HaveCount(1);
            }

            [Fact]
            public void ReturnsNone_WhenRouteNotMatch()
            {
                InventoryService sut =
                    new InventoryServiceTestDataBuilder()
                        .UsingMock();

                var result = sut.Search(
                    route: new Route("Laoag", "Manila"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: 1);

                result.Should().BeEmpty();
            }

            [Fact]
            public void ReturnsNone_WhenDateDoesNotMatch()
            {
                InventoryService sut =
                    new InventoryServiceTestDataBuilder()
                        .UsingMock();

                var result = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 30, 8, 0, 0),
                    paxCount: 1);

                result.Should().BeEmpty();
            }

            [Theory]
            [InlineData(2)]
            [InlineData(3)]
            public void ReturnsNone_WhenNoAvailableSlot(int paxCount)
            {
                InventoryService sut =
                    new InventoryServiceTestDataBuilder()
                        .UsingMock();

                var result = sut.Search(
                    route: new Route("Manila", "Laoag"),
                    schedule: new DateTime(2020, 7, 31, 8, 0, 0),
                    paxCount: paxCount);

                result.Should().BeEmpty();
            }

        }

    }
}
