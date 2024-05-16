using MomentozAPITests.Models;
using System.Text.Json;

namespace MomentozAPITests
{
    public class CustomerApiTests
    {
        [Fact]
        public async void GetCustomers_Should_Return_Ok()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/customers?email=br.doe@example.com";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            // You can further assert the content, assuming it's JSON
            var content = await response.Content.ReadAsStringAsync();
            var customerList = JsonSerializer.Deserialize<List<CustomerDto>>(content);
            Assert.NotNull(customerList);
            Assert.True(customerList.Count > 0);
        }
    }
}
