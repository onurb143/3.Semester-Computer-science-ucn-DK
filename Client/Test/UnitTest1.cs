using MomentozClientApp.Servicelayer;
using MomentozClientApp.ServiceLayer;
using Xunit;

namespace MomentozClientApp.Tests
{
    public class CustomerAccessTests
    {
        [Fact]
        public async Task GetCustomerByEmail_Returns_Customer()
        {
            // Arrange
            var customerAccess = new CustomerAccess();
            var emailToTest = "bruno@ko.com";

            // Act
            var customer = await customerAccess.GetCustomerByEmail("bruno@ko.com");

            // Assert
            Assert.NotNull(customer);
            // Flere asserts kan tilføjes her for at bekræfte kundens data
        }
    }
}
