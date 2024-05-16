namespace MomentozAPITests
{
    public class ConnectionTest
    {
        [Fact]
        public async void MyApiMethod_Should_Return_Ok()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "http://localhost:7049/index.html";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}