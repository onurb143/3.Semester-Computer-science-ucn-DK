using System.Configuration;
using Newtonsoft.Json;
using MomentozClientApp.Model;

// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{

    // FlightAccess-klassen implementerer IFlightAccess-interface og håndterer adgang til flyoplysninger.
    public class FlightAccess : IFlightAccess
    {
        // En privat readonly instans af IServiceConnection til at oprette forbindelse til flyservicen.
        private readonly IServiceConnection _serviceConnection;

        // Felt der holder basis-URL'en til flyservicen, hentet fra konfigurationsindstillingerne.
        private readonly string _serviceBaseUrl;
       // Konstruktøren initialiserer FlightAccess-klassen.
        public FlightAccess()
        {
            // Hent basis-URL fra konfigurationsindstillingerne.
            _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");
            // Initialiser serviceforbindelsen med basis-URL'en.
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);

        }

        public Task<Flight> GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flight>?> GetAllFlights()
        {
            List<Flight>? foundFlights = null;
            try
            {
                // Sætter den specifikke URL til flyvningers endepunkt.
                _serviceConnection.UseUrl = _serviceBaseUrl + "flights";

                // Forsøger at foretage et GET-kald til servicen.
                var serviceResponse = await _serviceConnection.CallServiceGet();

                // Hvis kaldet er succesfuldt, og svaret er positivt, deserialiseres indholdet til en liste af flyvninger.
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundFlights = JsonConvert.DeserializeObject<List<Flight>>(content);
                }
            }
            catch
            {
                // Håndter fejl her, hvis det er nødvendigt.
            }

            return foundFlights;
        }
        public Task<int> CreateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Flight> GetFlightByUserId(string loginUserId)
        {
            throw new NotImplementedException();
        }
    }
}
