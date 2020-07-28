using Liner.Inventory.Api;
using Liner.Inventory.Core;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Liner.Inventory.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddTransient<IInventoryService, InventoryService>()
                .AddTransient<IInventoryRepository, InMemoryInventoryRepository>();
        }
    }
}
