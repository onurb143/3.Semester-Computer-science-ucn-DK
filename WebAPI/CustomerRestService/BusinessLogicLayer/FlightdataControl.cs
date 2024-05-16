using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;

namespace RESTfulService.BusinesslogicLayer
{
    public class FlightdataControl : IFlightdata
    {
        private readonly IFlightAccess _flightAccess;

        public FlightdataControl(IFlightAccess inFlightAccess)
        {
            _flightAccess = inFlightAccess;
        }


        public FlightDto? Get(int flightId)
        {
            FlightDto? foundFlightDto;
            try
            {
                Flight? foundFlight = _flightAccess.GetFlightById(flightId);
                foundFlightDto = ModelConversion.FlightDtoConvert.FromFlight(foundFlight);
            }
            catch
            {
                foundFlightDto = null;
            }
            return foundFlightDto;
        }

        public List<FlightDto>? Get()
        {
            List<FlightDto>? foundDtos;
            try
            {
                List<Flight>? foundFlights = _flightAccess.GetFlightAll();
                foundDtos = ModelConversion.FlightDtoConvert.FromFlightCollection(foundFlights);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }

        public FlightDto Add(FlightDto flightToAdd)
        {
            FlightDto conversion = null;
            try
            {
                Flight? newFlight = ModelConversion.FlightDtoConvert.ToFlight(flightToAdd);
                if (newFlight != null)
                {
                    Flight insertedFlight = _flightAccess.CreateFlight(newFlight);
                    conversion = ModelConversion.FlightDtoConvert.FromFlight(insertedFlight);
                }
            }
            catch (Exception es)
            {
                Console.WriteLine("Caught exception:" + es);
            }
            return conversion;
        }

        public bool Put(FlightDto flightToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FlightDto? GetFlightById(int flightId)
        {
            FlightDto? foundDtos;
            try
            {
                Flight? foundFlight = _flightAccess.GetFlightById(flightId);
                foundDtos = ModelConversion.FlightDtoConvert.FromFlight(foundFlight);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }

    }
}
