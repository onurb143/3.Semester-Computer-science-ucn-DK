namespace MomentozClientApp.Model
{
    // Order-klassen repræsenterer en ordre i systemet.
    public class Order
    {
        // Standardkonstruktør.
        public Order() { }

        // Konstruktør til oprettelse af en ny ordre med angivelse af detaljer.
        public Order(double totalPrice, DateTime purchaseDate, int customerID, int flightID)
        {
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        // Konstruktør til oprettelse af en ordre med angivelse af ID og detaljer.
        public Order(int orderID, double totalPrice, DateTime purchaseDate, int customerID, int flightID)
            : this(totalPrice, purchaseDate, customerID, flightID)
        {
            OrderID = orderID;
        }

        // Egenskab til at få eller indstille ordre-ID.
        public int OrderID { get; set; }

        // Egenskab til at få eller indstille den samlede pris for ordren.
        public double TotalPrice { get; set; }

        // Egenskab til at få eller indstille købsdatoen for ordren.
        public DateTime PurchaseDate { get; set; }

        // Egenskab til at få eller indstille kunde-ID for ordren.
        public int CustomerID { get; set; }

        // Egenskab til at få eller indstille fly-ID for ordren.
        public int FlightID { get; set; }
    }
}
