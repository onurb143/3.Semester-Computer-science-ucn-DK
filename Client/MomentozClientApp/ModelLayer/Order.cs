// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ModelLayer
{
    // Order-klassen repræsenterer en ordre med totalpris, købsdato og relaterede ID'er til kunde og billet.
    public class Order
    {
        // Standardkonstruktør uden parametre.
        public Order() { }

        // Konstruktør, der initialiserer en ny Order-instans med totalpris, købsdato, kunde-ID og billet-ID.
        public Order(double totalPrice, DateTime purchaseDate, int? CustomerID, int? TicketID)
        {
            // Sætter egenskaberne TotalPrice, PurchaseDate, CustomerID og TicketID til de givne værdier.
            this.TotalPrice = totalPrice;
            this.PurchaseDate = purchaseDate;
            this.CustomerID = CustomerID;
            this.TicketID = TicketID;
        }

        // Udvidet konstruktør, der inkluderer et id samt de andre parametre.
        // Den kalder den anden konstruktør ved hjælp af 'this' nøgleordet.
        public Order(int id, double totalPrice, DateTime purchaseDate, int? CustomerID, int? TicketID) : this(totalPrice, purchaseDate, CustomerID, TicketID)
        {
            // Sætter egenskaben ID til den givne værdi.
            ID = id;
        }

        // Egenskaber for at holde ordreinformationer såsom ID, totalpris, købsdato, kunde-ID og billet-ID.
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? TicketID { get; set; }
    }
}
