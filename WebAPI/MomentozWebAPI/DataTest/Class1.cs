using DatabaseData.DatabaseLayer;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class OrderDatabaseAccessTests
{
    [Fact]
    public void GetOrderAll_ShouldReturnListOfOrders_WhenCalled()
    {
        // Arrange
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration
            .Setup(c => c.GetConnectionString(It.IsAny<string>()))
            .Returns("Momentoz");

        var databaseAccess = new OrderDatabaseAccess(mockConfiguration.Object);

        // Act
        var result = databaseAccess.GetOrderAll();

        // Assert
        Assert.IsNotNull(result);
        // Flere assertions baseret på forventet adfærd...
    }
}