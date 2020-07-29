using Liner.Ticketing.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Liner.Ticketing.Api
{
    public class TicketController
    {

        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [FunctionName("Ticket_Insert")]
        public async Task<IActionResult> Insert(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "ticket")]
            HttpRequest request)
        {
            string json = await new StreamReader(request.Body).ReadToEndAsync();

            var ticket = JsonSerializer.Deserialize<TicketRequest>(json);

            _service.Book(ticket.Bus, new Passenger(ticket.Name, ticket.Age));
            return new NoContentResult();
        }
    }
}
