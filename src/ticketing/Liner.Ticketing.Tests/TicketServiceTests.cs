using FluentAssertions;
using Liner.Ticketing.Core;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Liner.Ticketing.Tests
{
    public class TicketServiceTests
    {
        public class Book_Should
        {

            [Fact]
            public void VerifySaved()
            {
                var repository = new Mock<ITicketRepository>();
                var inventory = new Mock<IInventoryClient>();
                var service = new TicketService(
                    repository.Object,
                    inventory.Object);

                service.Book("L0820200731", new Passenger("John Doe", 22));

                repository.Verify(r =>
                    r.Insert(
                        It.Is<Ticket>(t => t.Bus == "L0820200731" && t.Passengers.Any())), Times.Once());
            }

            [Fact]
            public void VerifySlotReserved()
            {
                var repository = new Mock<ITicketRepository>();
                var inventory = new Mock<IInventoryClient>();
                var service = new TicketService(
                    repository.Object,
                    inventory.Object);

                service.Book("L0820200731", new Passenger("John Doe", 22));

                inventory.Verify(i => i.Hold("L0820200731", 1), Times.Once());
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public void ThrowError_WhenNoBus(string bus)
            {
                var repository = new Mock<ITicketRepository>();
                var inventory = new Mock<IInventoryClient>();
                var service = new TicketService(
                    repository.Object,
                    inventory.Object);

                Action sut = () => service.Book(bus, new Passenger("John Doe", 22));
                sut.Should().Throw<ArgumentNullException>();
            }

            [Fact]
            public void ThrowError_WhenNoPassenger()
            {
                var repository = new Mock<ITicketRepository>();
                var inventory = new Mock<IInventoryClient>();
                var service = new TicketService(
                    repository.Object,
                    inventory.Object);

                Action sut = () => service.Book("L0820200731", null);
                sut.Should().Throw<ArgumentNullException>();
            }
        }
    }
}
