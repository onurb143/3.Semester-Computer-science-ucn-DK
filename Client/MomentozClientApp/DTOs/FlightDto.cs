namespace MomentozClientApp.DTOs
{
    public class FlightDto
    {
        public FlightDto() { }

        public FlightDto(int id, string address, string city, double price, string destinationAddress, string destinationCountry)
        {
            Id = id;
            Address = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationCountry { get; set; }

        public string CustomDisplay => $"{Address}, {City}, {Price}, {DestinationAddress}, {DestinationCountry}";
    }
}
