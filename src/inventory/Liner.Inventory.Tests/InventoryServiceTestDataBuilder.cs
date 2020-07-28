﻿using System;
using Moq;

namespace Liner.Inventory.Tests
{
    public partial class InventoryServiceTests
    {
        public class InventoryServiceTestDataBuilder
        {
            public IInventoryRepository Repository { get; set; }

            public InventoryServiceTestDataBuilder UsingMock()
            {
                var buses = new Buses();
                buses.Add(
                    new Bus(
                        new Route("Manila", "Laoag"),
                        new DateTime(2020, 7, 31, 8, 0, 0)));

                var repository = new Mock<IInventoryRepository>();
                repository
                    .Setup(r => r.Get(It.IsAny<DateTime>()))
                    .Returns(() => buses);

                Repository = repository.Object;

                return this;
            }

            public InventoryService Build()
            {
                return new InventoryService(Repository);
            }

            public static implicit operator InventoryService(InventoryServiceTestDataBuilder obj)
            {
                return obj.Build();
            }
        }

    }
}