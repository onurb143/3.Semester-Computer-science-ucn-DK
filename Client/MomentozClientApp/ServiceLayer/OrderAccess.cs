using System.Configuration;
using System.Text;
using Newtonsoft.Json;
using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.ServiceLayer
{
    public class OrderAccess : IOrderAccess
    {
        readonly IServiceConnection _orderServiceConnection;
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        public OrderAccess()
        {
            // Initialiser OrderAccess klassen.
            _orderServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public async Task<Order> GetOrderById(int orderID)
        {
            Order foundOrder = null;

            // Sæt URL'en til at hente en bestemt ordre.
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders/" + orderID;

            try
            {
                // Kalder en asynkron tjeneste for at hente data.
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    // Læser JSON-indholdet og deserialiserer det til en Order-objekt.
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundOrder = JsonConvert.DeserializeObject<Order>(content);
                }
            }
            catch (Exception ex)
            {
                // Håndterer fejl, hvis der opstår en exception under hentning af ordre.
                Console.WriteLine("Fejl ved hentning af ordre: " + ex.Message);
            }

            return foundOrder;
        }

        public async Task<List<Order>> GetOrderAll()
        {
            List<Order> listFromService = new List<Order>();

            // Sæt URL'en til at hente alle ordrer.
            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl + "orders";

            try
            {
                // Kalder en asynkron tjeneste for at hente data.
                var serviceResponse = await _orderServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    // Læser JSON-indholdet og deserialiserer det til en liste af Order-objekter.
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Order>>(content) ?? listFromService;
                }
            }
            catch (Exception ex)
            {
                // Håndterer fejl, hvis der opstår en exception under hentning af ordrer.
                Console.WriteLine("Fejl ved hentning af ordrer: " + ex.Message);
            }

            return listFromService;
        }

        public async Task<Order> CreateOrder(Order orderToAdd)
        {
            var json = JsonConvert.SerializeObject(orderToAdd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Sæt URL'en til at oprette en ny ordre.
            _orderServiceConnection.UseUrl += "orders";

            if (_orderServiceConnection != null)
            {
                try
                {
                    // Sender en POST-anmodning med ordredata og modtager en respons.
                    var response = await _orderServiceConnection.CallServicePost(content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Hvis oprettelsen var vellykket, opdateres OrderID med den tildelte ID.
                        var responseContent = await response.Content.ReadAsStringAsync();
                        int createdOrderID = JsonConvert.DeserializeObject<int>(responseContent);
                        orderToAdd.OrderID = createdOrderID;

                        return orderToAdd;
                    }
                    else
                    {
                        // Håndterer fejlrespons fra tjenesten.
                        Console.WriteLine("Responsen var ikke vellykket: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Håndterer fejl, hvis der opstår en exception under oprettelsen af ordre.
                    Console.WriteLine("Der opstod en fejl: " + ex.Message);
                    return null;
                }
            }
            else
            {
                // Håndterer tilfælde, hvor serviceforbindelsen eller anmodnings-URL'en er null.
                Console.WriteLine("Serviceforbindelsen eller anmodnings-URL'en er null.");
                return null;
            }
        }

        // Resten af dine metoder ser ud til at være ufuldstændige og markeret som "NotImplemented."
        // Du skal implementere dem, hvis de er nødvendige for din applikation.

        public bool UpdateOrder(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderById(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order? GetOrderByCustomerId(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
