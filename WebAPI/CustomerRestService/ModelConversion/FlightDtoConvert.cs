using DatabaseData.ModelLayer;
using RESTfulService.DTOs;

namespace RESTfulService.ModelConversion
        {
        public class FlightDtoConvert
        {
        public static List<FlightDto> FromFlightCollection(List<Flight> inFlights)
        {
            if (inFlights == null)
                return null;
            
                var aFlightReadDtoList = new List<FlightDto>();
                foreach (Flight aFlight in inFlights)
                {
                    if (aFlight != null)
                    {
                        var tempDto = FromFlight(aFlight);
                        aFlightReadDtoList.Add(tempDto);
                    }

                }
                return aFlightReadDtoList;
            }

            public static FlightDto FromFlight(Flight inFlight)
            {
            if (inFlight == null)
                return null;
  

                return new FlightDto(inFlight.FlightID, inFlight.Departure, inFlight.DestinationAddress, inFlight.DestinationCountry, inFlight.Price);
            }

            public static Flight? ToFlight(FlightDto inDto)
            {
            if (inDto == null)
                return null;

                return new Flight(inDto.Departure, inDto.DestinationAddress, inDto.DestinationCountry, inDto.Price); 
            }
        }
    }

