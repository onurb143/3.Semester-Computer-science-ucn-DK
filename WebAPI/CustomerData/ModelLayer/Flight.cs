namespace DatabaseData.ModelLayer
{
    // Flight-klassen repræsenterer oplysninger om en flyvning.
    public class Flight
    {
        // Standardkonstruktør uden parametre.
        public Flight() { }

        // Konstruktør med parametre til at oprette en ny flyvning.
        // Parametre:
        // - departure: Afgangsstedet for flyvningen.
        // - destinationAddress: Adresse for destinationen.
        // - destinationCountry: Land for destinationen.
        // - homeTrip: Dato for hjemrejsen (kan være null).
        // - price: Prisen for flyvningen.
        public Flight(string departure, string destinationAddress, string destinationCountry, double price)
        {
            Departure = departure;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
            Price = price;
        }

        // Konstruktør med parametre, der inkluderer FlightID.
        // Dette koncept kaldes "constructor chaining" eller "construction delegation," 
        // hvor den bruger den tidligere definerede konstruktør for at initialisere egenskaber.
        // Parametre genbruges fra den tidligere konstruktør.
        // - flightID: Unik identifikator for flyvningen. Denne konstruktør bruges, hvis der allerede er et ID,
        //   eller hvis der skal tildeles en specifik ID.
        public Flight(int flightID, string departure, string destinationAddress, string destinationCountry, double price)
            : this(departure, destinationAddress, destinationCountry, price)
        {
            FlightID = flightID;
        }

  
        public int FlightID { get; set; }

        public string Departure { get; set; }

        public double Price { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationCountry { get; set; }


        // Egenskab som bruger string concatenation til at danne en brugerdefineret displaystreng, der viser afgang, destination og land.
        public string? CustomDisplay => $"{Departure}, {DestinationAddress}, {DestinationCountry}";
    }
}
