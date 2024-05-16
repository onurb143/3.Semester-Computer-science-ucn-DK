namespace MomentozClientApp.DTOs
{
    public class TicketDto
    {
        public TicketDto() { }
        public TicketDto(string inType, int inTicketNumber, int inBaggageID, int inFlightID)
        {
            Type = inType;
            TicketNumber = inTicketNumber;
            BaggageID = inBaggageID;
            FlightID = inFlightID;
        }
        public int Id { get; set; }
        public string? Type { get; set; }
        public int TicketNumber { get; set; }
        public int? BaggageID { get; set; }
        public int? FlightID { get; set; }
    }
}
