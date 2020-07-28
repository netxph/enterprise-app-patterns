using Xunit;
using FluentAssertions;

namespace Liner.Inventory.Tests
{
    public class RouteTests
    {
        public class Init_Should
        {
            [Fact]
            public void Require_OriginDestination()
            {
                var route = new Route("Manila", "Laoag");
                route.Origin.Should().Be("Manila");
                route.Destination.Should().Be("Laoag");
            }
        }
    }

}
