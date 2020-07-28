using Xunit;
using FluentAssertions;
using Liner.Inventory.Core;

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
        
        public class ToString_Should
        {
            [Fact]
            public void Return_ReadableResult()
            {
                var route = new Route("Manila", "Laoag");

                route.ToString().Should().Be("Manila-Laoag");
            }
        }
    }

}
