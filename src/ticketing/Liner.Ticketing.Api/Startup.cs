using Liner.Ticketing.Api;
using Liner.Ticketing.Core;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Liner.Ticketing.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddTransient<ITicketService, TicketService>()
                .AddTransient<ITicketRepository, InMemoryTicketRepository>()
                .AddTransient<IInventoryClient, ApiInventoryClient>();

        }
    }
}
