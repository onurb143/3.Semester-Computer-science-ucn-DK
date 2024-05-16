namespace MomentozClientApp.Model
{
    // Flight-klassen repræsenterer oplysninger om en flyvning i systemet.
    public class Flight
    {
        // Standardkonstruktør.
        public Flight() { }

        // Konstruktør til oprettelse af en ny flyvning med angivelse af detaljer.
        public Flight(string? departure, double price, string? destinationAddress, string? destinationCountry)
        {
            Departure = departure;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

        // Konstruktør til oprettelse af en flyvning med angivelse af ID og detaljer.
        public Flight(int flightID, string? departure, double price, string? destinationAddress, string? destinationCountry)
            : this(departure, price, destinationAddress, destinationCountry)
        {
            FlightID = flightID;
        }

        // Egenskab til at få eller indstille flyvningens ID.
        public int FlightID { get; set; }

        // Egenskab til at få eller indstille afgang for flyvningen.
        public string? Departure { get; set; }

        // Egenskab til at få eller indstille prisen for flyvningen.
        public double Price { get; set; }

        // Egenskab til at få eller indstille destinationens adresse for flyvningen.
        public string? DestinationAddress { get; set; }

        // Egenskab til at få eller indstille destinationens land for flyvningen.
        public string? DestinationCountry { get; set; }

        // Egenskab, der genererer en brugerdefineret streng til visning af destinationen.
        public string CustomDisplay => $"{DestinationAddress}, {DestinationCountry}";
    }
}
