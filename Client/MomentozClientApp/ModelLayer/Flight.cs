// Definerer navneområdet for modellen i MomentozClientApp-applikationen.
namespace MomentozClientApp.Model
{
    // Flight-klassen repræsenterer en flyvning med detaljer som afgang og ankomst.
    public class Flight
    {
        // Standardkonstruktør uden parametre.
        public Flight() { }

        // Konstruktør, der initialiserer en Flight-instans med oplysninger om afgang, ankomst og pris.
        public Flight(string? address, string? city, double price, string? destinationAddress, string? destinationCountry)
        {
            // Sætter egenskaberne for afgang (adresse og by), pris, og ankomst (adresse og land) til de givne værdier.
            Address = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

        // Udvidet konstruktør, der inkluderer et id samt de andre parametre.
        // Den kalder den anden konstruktør ved hjælp af 'this' nøgleordet.
        public Flight(int id, string? address, string? city, double price, string? destinationAddress, string? destinationCountry)
        {
            // Sætter egenskaberne Id, Address, City, Price, DestinationAddress og DestinationCountry til de givne værdier.
            Id = id;
            Address = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

        // Egenskaber for at holde flyvningens id, afgangsadresse, afgangsby, pris, ankomstadresse og ankomstland.
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }

        // En egenskab, der returnerer en brugerdefineret tekstrepræsentation af flyvningen.
        public string CustomDisplay => $"{Address}, {City}, {Price} {DestinationAddress}, {DestinationCountry}";
    }
}
