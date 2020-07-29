using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Xunit;
using FluentAssertions;
using Liner.Inventory.Api;
using System.Net;

namespace Liner.Inventory.Integration
{
    public class InventoryTests
    {

        public class GetAll_Should
        {
            private static readonly HttpClient _client = new HttpClient();

            [Fact]
            public async void ReturnResults()
            {
                var result = await _client.GetAsync("http://localhost:5000/api/inventory?from=Manila&to=Laoag&on=2020-07-31T08:00:00");
                var json = await result.Content.ReadAsStringAsync();

                var buses = JsonSerializer.Deserialize<List<BusResult>>(json);

                buses.Should().NotBeEmpty();
            }

            [Fact]
            public async void ReturnNoResults()
            {
                var result = await _client.GetAsync("http://localhost:5000/api/inventory?from=Laoag&to=Manila&on=2020-07-31T08:00:00");
                var json = await result.Content.ReadAsStringAsync();

                var buses = JsonSerializer.Deserialize<List<BusResult>>(json);

                buses.Should().BeEmpty();
            }
        }

        public class Hold_Should
        {
            private static readonly HttpClient _client = new HttpClient();

            [Fact]
            public async void BeSuccessful()
            {
                var request = JsonSerializer.Serialize(new 
                {
                    Bus = "L0820200731",
                    PaxCount = 1
                });

                var result = await _client.PutAsync("http://localhost:5000/api/inventory/hold", new StringContent(request));

                result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }
    }
}
