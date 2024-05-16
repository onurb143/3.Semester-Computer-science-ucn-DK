// Inkluderer ModelLayer-navneområdet, som indeholder data-modellerne, herunder Customer-modellen.
// Inkluderer også nødvendige navneområder for konfiguration og JSON-håndtering.
using System.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using MomentozClientApp.Model;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // CustomerAccess-klassen implementerer ICustomerAccess-interface og håndterer adgang til kundeoplysninger.
    public class CustomerAccess : ICustomerAccess
    {
        // readonly instans af IServiceConnection, der bruges til at håndtere forbindelser til webtjenester.
        readonly IServiceConnection _customerServiceConnection;
        // Basis-URL'en til servicen, hentet fra applikationskonfigurationen.
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        // Konstruktøren initialiserer CustomerAccess-klassen.
        public CustomerAccess()
        {
            _customerServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public async Task<List<Customer>> GetCustomerAll()
        {
            List<Customer> listFromService = new List<Customer>();
            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl + "customers";

            try
            {
                var serviceResponse = await _customerServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Customer>>(content) ?? listFromService;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while fetching all customers: {ex.Message}");
            }

            return listFromService;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer  foundCustomer = null;
            List<Customer> foundCustomers = null;

            _customerServiceConnection.UseUrl = $"{_customerServiceConnection.BaseUrl}customers?email={Uri.EscapeDataString(email)}";

            try
            {
                var serviceResponse = await _customerServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundCustomers = JsonConvert.DeserializeObject<List<Customer>>(content);
                    foundCustomer = foundCustomers.First();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while fetching customer by email: {ex.Message}");
            }

            return foundCustomer;
        }

        public Task<int> CreateCustomer(string newUsername, Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();


        }
    }
}