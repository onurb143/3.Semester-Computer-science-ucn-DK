namespace MomentozDataTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "http://localhost:5114/api";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}