namespace RESTfulService.DTOs
{
    public class OrderDto
    {
        public OrderDto(int? orderID, double totalPrice, DateTime purchaseDate, int customerID, int flightID)
        {
            OrderID = orderID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        public int? OrderID { get; set; }

        public double TotalPrice { get; set; }
  
        public DateTime PurchaseDate { get; set; }

        public int CustomerID { get; set; }

        public int FlightID { get; set; }
    }
}
