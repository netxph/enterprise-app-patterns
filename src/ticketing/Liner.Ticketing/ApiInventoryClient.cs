using Liner.Ticketing.Core;
using System.Net.Http;
using System.Text.Json;

namespace Liner.Ticketing
{
    public class ApiInventoryClient : IInventoryClient
    {

        private static readonly HttpClient _client = new HttpClient();

        public async void Hold(string bus, int paxCount)
        {
            var json = JsonSerializer.Serialize(new
            {
                Bus = bus,
                PaxCount = paxCount 
            });

            await _client.PutAsync("http://localhost:5000/api/inventory/hold", new StringContent(json));
        }
    }
}
