using Liner.Inventory.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Liner.Inventory.Api
{
    public class InventoryController
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [FunctionName("Inventory_GetAll")]
        public IActionResult GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "inventory")]
            HttpRequest request)
        {
            var origin = request.Query["from"].FirstOrDefault();
            var destination = request.Query["to"].FirstOrDefault();
            var schedule = DateTime.Parse(request.Query["on"]);
            var paxCount = int.Parse(request.Query["count"].FirstOrDefault() ?? "1");

            var buses = _service.Search(
                new Route(origin, destination),
                schedule,
                paxCount);

            var results = buses.Select(b => new BusResult()
            {
                ID = b.Id,
                Route = b.Route.ToString(),
                Schedule = b.Schedule
            }).ToList();

            return new JsonResult(results);
            
        }
    }
}
