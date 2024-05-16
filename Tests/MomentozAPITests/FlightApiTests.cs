using MomentozAPITests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MomentozAPITests
{
    public class FlightApiTests
    {
        [Fact]
        public async void GetFlights_Should_Return_Ok()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/flights";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            // You can further assert the content, assuming it's JSON
            var content = await response.Content.ReadAsStringAsync();
            var flightList = System.Text.Json.JsonSerializer.Deserialize<List<FlightDto>>(content);
            Assert.NotNull(flightList);
        }
        [Fact]
        public async void GetFlightsWithoutTestFlights()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/flights";
            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var flightList = System.Text.Json.JsonSerializer.Deserialize<List<FlightDto>>(content);
            Assert.NotNull(flightList);
            Assert.All(flightList, f => Assert.DoesNotContain("test", f.Departure));
        }
    }
}
