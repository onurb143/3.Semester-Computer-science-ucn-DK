using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
namespace MomentozClientApp.ModelConversion
{
    public class BaggageDtoConvert
    {
        public static List<BaggageDto> FromBaggageCollection(List<Baggage> inBaggage)
        {
            var aBaggageReadDtoList = new List<BaggageDto>();
            foreach (Baggage aBaggage in inBaggage)
            {
                var tempDto = FromBaggage(aBaggage);
                aBaggageReadDtoList.Add(tempDto);
            }
            return aBaggageReadDtoList;
        }
        public static BaggageDto FromBaggage(Baggage inBaggage)
        {
            return new BaggageDto
            {
                Id = inBaggage.Id,
                TotalWeight = inBaggage.TotalWeight,
                Price = inBaggage.Price
            };
        }
        public static Baggage ToBaggage(BaggageDto inDto)
        {
            Baggage? aBaggage = null;
            if (inDto != null)
            {
                aBaggage = new Baggage(inDto.TotalWeight, inDto.Price);
            }
            return aBaggage;
        }
    }
}