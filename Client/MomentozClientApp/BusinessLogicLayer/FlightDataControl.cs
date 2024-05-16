using MomentozClientApp.Model;  // Bruger Flight-klassen fra MomentozClientApp.Model namespace.
using MomentozClientApp.Servicelayer;  // Bruger IFlightAccess-grænsefladen fra MomentozClientApp.Servicelayer namespace.

namespace MomentozClientApp.BusinessLogicLayer
{
    // FlightdataControl-klassen implementerer IFlightdata-grænsefladen og styrer adgangen til flydata.
    public class FlightdataControl : IFlightdata
    {
        private readonly IFlightAccess _flightAccess;

        // Konstruktør, der modtager en IFlightAccess-implementering som parameter.
        public FlightdataControl(IFlightAccess flightAccess)
        {
            _flightAccess = flightAccess;
        }

        // Metode til at hente en flyvning efter ID.
        public Flight? Get(int id)
        {
            try
            {
                return _flightAccess.GetFlightById(id).Result;
            }
            catch
            {
                return null;
            }
        }

        // Metode til at hente alle flyvninger som en liste.
        public List<Flight>? Get()
        {
            try
            {
                return _flightAccess.GetAllFlights().Result;
            }
            catch
            {
                return null;
            }
        }

        // Metode til at tilføje en ny flyvning.
        public int Add(Flight flightToAdd)
        {
            try
            {
                if (flightToAdd != null)
                {
                    return _flightAccess.CreateFlight(flightToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        // Metode til at opdatere en eksisterende flyvning (endnu ikke implementeret).
        public bool Put(Flight flightToUpdate)
        {
            throw new NotImplementedException();
        }

        // Metode til at slette en flyvning efter ID (endnu ikke implementeret).
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Metode til at hente en flyvning efter ID ved direkte kald til _flightAccess.
        public Flight? GetFlightById(int id)
        {
            try
            {
                return _flightAccess.GetFlightById(id).Result;
            }
            catch
            {
                return null;
            }
        }
    }
}
