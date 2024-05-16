// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ModelLayer
{
    // Baggage-klassen repræsenterer en bagageenhed med vægt og pris.
    public class Baggage
    {
        // Standardkonstruktør uden parametre.
        public Baggage() { }

        // Konstruktør, der initialiserer en ny Baggage-instans med totalvægt og pris.
        public Baggage(double totalWeight, double price)
        {
            // Sætter egenskaberne TotalWeight og Price til de givne værdier.
            this.TotalWeight = totalWeight;
            this.Price = price;
        }

        // Udvidet konstruktør, der inkluderer et id samt totalvægt og pris.
        // Den kalder den anden konstruktør ved hjælp af 'this' nøgleordet.
        public Baggage(int id, double totalWeight, double price) : this(totalWeight, price)
        {
            // Sætter egenskaben Id til den givne værdi.
            Id = id;
        }

        // Egenskaber for at holde bagageens id, totalvægt og pris.
        public int Id { get; set; }
        public double TotalWeight { get; set; }
        public double Price { get; set; }
    }
}
