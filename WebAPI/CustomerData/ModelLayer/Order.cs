namespace DatabaseData.ModelLayer
{
    public class Order
    {
        public Order() { }

        // Konstruktør til oprettelse af en ny ordre.
        // Parametre:
        // - totalPrice: Den samlede pris for ordren.
        // - purchaseDate: Datoen, hvor ordren blev foretaget.
        // - customerID: Unik identifikator for kunden, der oprettede ordren.
        // - flightID: Unik identifikator for flyvningen, der er knyttet til ordren.
        public Order(double totalPrice, DateTime purchaseDate, int customerID, int flightID)
        {
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        // Konstruktør til opdatering af en eksisterende ordre.
        // Bruger den tidligere definerede konstruktør til at initialisere grundlæggende egenskaber.
        // Parametre genbruges fra den tidligere konstruktør.
        // - orderID: Unik identifikator for ordren. Denne konstruktør bruges, hvis der allerede er et ID,
        //   eller hvis der skal tildeles en specifik ID.

        public Order(int? orderID, double totalPrice, DateTime purchaseDate, int customerID, int flightID)
            : this(totalPrice, purchaseDate, customerID, flightID)
        {
            OrderID = orderID;
        }

        public int? OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
    }
}
