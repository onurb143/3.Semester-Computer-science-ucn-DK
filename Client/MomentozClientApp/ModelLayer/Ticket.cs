// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ModelLayer
{
    // Ticket-klassen repræsenterer en billet med specifikke egenskaber som type, nummer og relaterede ID'er.
    public class Ticket
    {
        // Konstruktør, der initialiserer en Ticket-instans med type, billetnummer og mulige ID'er for bagage og fly.
        public Ticket(string tempTicketType, int tempTicketNumber, int? tempBaggageID, int? tempFlightID)
        {
            // Sætter egenskaberne Type, TicketNumber, BaggageID og FlightID til de givne værdier.
            this.Type = tempTicketType;
            this.TicketNumber = tempTicketNumber;
            this.BaggageID = tempBaggageID;
            this.FlightID = tempFlightID;
        }

        // Udvidet konstruktør, der inkluderer et id samt de andre parametre.
        public Ticket(int ID, string Type, int TicketNumber, int? tempBaggageID, int? tempFlightID)
        {
            // Sætter egenskaberne Id, Type, TicketNumber, BaggageID og FlightID til de givne værdier.
            this.Id = ID;
            this.Type = Type;
            this.TicketNumber = TicketNumber;
            this.BaggageID = tempBaggageID;
            this.FlightID = tempFlightID;
        }

        // Egenskaber for at holde billettens id, type, nummer og potentielle ID'er for relateret bagage og fly.
        public int Id { get; set; }
        public string Type { get; set; }
        public int TicketNumber { get; set; }
        public int? BaggageID { get; set; }
        public int? FlightID { get; set; }
    }
}
