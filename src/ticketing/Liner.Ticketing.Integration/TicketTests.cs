using System.Net.Http;
using System.Text.Json;
using Xunit;
using FluentAssertions;
using System.Net;

namespace Liner.Ticketing.Integration
{
    public class TicketTests
    {
        public class Book_Should
        {
            private static readonly HttpClient _client = new HttpClient();

            [Fact]
            public async void BeSuccessful()
            {
                var request = JsonSerializer.Serialize(new
                {
                    Bus = "L0820200731",
                    Name = "John Doe",
                    Age = 22
                });

                var result = await _client.PostAsync("http://localhost:6000/api/ticket", new StringContent(request));

                result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }
    }
}
