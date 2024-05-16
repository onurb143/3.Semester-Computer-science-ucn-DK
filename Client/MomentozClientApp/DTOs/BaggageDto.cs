namespace MomentozClientApp.DTOs
{
    public class BaggageDto
    {
        public BaggageDto() { }
        public BaggageDto(double inTotalWeight, double inPrice)
        {
            TotalWeight = inTotalWeight;
            Price = inPrice;
   
        }
        public int Id { get; set; }
        public double TotalWeight { get; set; }
        public double Price { get; set; }
    
    }
}