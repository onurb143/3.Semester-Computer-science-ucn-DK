namespace MomentozAPITests.Models
{
    public class FlightDto
    {
        public FlightDto(int flightID, string? departure, string? destinationAddress, string? destinationCountry, double price)
        {
            FlightID = flightID;
            Departure = departure;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
            Price = price;
        }
        public FlightDto() { }
        public int FlightID { get; set; }
        public string? Departure { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }
        public double Price { get; set; }
        public string CustomDisplay { get; set; }
    }
}
