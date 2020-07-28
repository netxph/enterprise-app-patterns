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
                buses.Add(new Bus(new Route("Manila", "Laoag")));
            }

            [Fact]
            public void ThrowException_WhenBusIsNull()
            {
                var buses = new Buses();

                Action sut = () => buses.Add(null);

                sut.Should().Throw<ArgumentNullException>();
            }
        }
    }
}
