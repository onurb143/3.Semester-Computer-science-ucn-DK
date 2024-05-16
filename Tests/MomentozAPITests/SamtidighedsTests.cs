using MomentozAPITests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozAPITests
{
    public class SamtidighedsTests
    {
        [Fact]
        public async void ClientVsClient()
        {
            // Arrange
            OrderDto customer1Order = null;
            OrderDto customer2Order = null;
            FlightDto testFlight = await setupFlightInDB();
            CustomerDto testCustomer1 = await getCustomerByEmail("bruno@ko.com");
            if (testCustomer1 != null)
            {
                customer1Order = new OrderDto(
                testFlight.Price, DateTime.Now, testCustomer1.CustomerID, testFlight.FlightID);
            }
            CustomerDto testCustomer2 = await getCustomerByEmail("paul@lol.dk");
            if (testCustomer2 != null)
            {
                customer2Order = new OrderDto(
                testFlight.Price, DateTime.Now, testCustomer2.CustomerID, testFlight.FlightID);
            }
            using var client = new HttpClient();
            string apiUrl = "https://localhost:5114/api/Orders";
            // Act

            Thread.Sleep(5000);

            var JSONcustomer1 = JsonConvert.SerializeObject(customer1Order);
            var JSONcustomer2 = JsonConvert.SerializeObject(customer2Order);
            var inContent1 = new StringContent(JSONcustomer1, Encoding.UTF8, "application/json");
            var inContent2 = new StringContent(JSONcustomer2, Encoding.UTF8, "application/json");

            var customer1Response = await client.PostAsync(apiUrl, inContent1);
            var customer2Response = await client.PostAsync(apiUrl, inContent2);
            Thread.Sleep(5000);

            var Customer1Content = await customer1Response.Content.ReadAsStringAsync();
            var Customer2Content = await customer1Response.Content.ReadAsStringAsync();
            Thread.Sleep(5000);
            
            if (Customer1Content != null)
            {
                int order1FromService = JsonConvert.DeserializeObject<int>(Customer1Content);
                customer1Order.OrderID = order1FromService;
            }
            if (Customer2Content != null)
            {
                int order2FromService = JsonConvert.DeserializeObject<int>(Customer2Content);
                customer2Order.OrderID = order2FromService;
            }

            var orderAPIresponse = await client.GetAsync(apiUrl);
            var ordersFromService = await orderAPIresponse.Content.ReadAsStringAsync();
            List<OrderDto> orderList = JsonConvert.DeserializeObject<List<OrderDto>>(ordersFromService);
            var distinctOrderIDs = orderList.Select(order => order.OrderID).Distinct();

            // Assert
            Assert.Equal(orderList.Count, distinctOrderIDs.Count());
        }

        private async Task<CustomerDto> getCustomerByEmail(string email)
        {
            using var client = new HttpClient();
            string apiUrl = "https://localhost:5114/api/Customers?email=" + email;
            var response = await client.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            List<CustomerDto> customerFromService = JsonConvert.DeserializeObject<List<CustomerDto>>(content);
            CustomerDto customer1 = customerFromService[0];
            return customer1;
        }

        private async Task<FlightDto> setupFlightInDB()
        {
            //prettelse af Flight til brug
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/flights/";
            FlightDto flight = new FlightDto();
            flight.Departure = "test";
            flight.Price = 1234;
            flight.DestinationAddress = "test123";
            flight.DestinationCountry = "test";
            var response = await client.GetAsync(apiUrl);
            // setup flight til JSON format
            var JSONflight = JsonConvert.SerializeObject(flight);
            var inContent = new StringContent(JSONflight, Encoding.UTF8, "application/json");
            // Post flight til DB
            var serviceResponse = await client.PostAsync(apiUrl, inContent);
            var content = await serviceResponse.Content.ReadAsStringAsync();
            FlightDto flightFromService = JsonConvert.DeserializeObject<FlightDto>(content);
            // get flightID
            var flightResponse = await client.GetAsync(apiUrl + flightFromService.FlightID);
            var flightContent = await flightResponse.Content.ReadAsStringAsync();
            FlightDto flightService = JsonConvert.DeserializeObject<FlightDto>(flightContent);

            return flightService;
        }
    }
}
