using MomentozAPITests.Models;
using System.Text.Json;

namespace MomentozAPITests
{
    public class OrderApiTests
    {
        [Fact]
        public async void GetOrders_Should_Return_Ok()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/orders";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            
            var content = await response.Content.ReadAsStringAsync();
            var orderList = JsonSerializer.Deserialize<List<OrderDto>>(content);
            Assert.NotNull(orderList);
        }
    }
}
