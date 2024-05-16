using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;

namespace MomentozClientApp.ModelConversion
{
    public class OrderDtoConvert
    {
        public static List<OrderDto> FromOrderCollection(List<Order> inOrder)
        {
            var aOrderReadDtoList = new List<OrderDto>();
            foreach (Order aOrder in inOrder)
            {
                var tempDto = FromOrder(aOrder);
                aOrderReadDtoList.Add(tempDto);
            }
            return aOrderReadDtoList;
        }
        public static OrderDto FromOrder(Order inOrder)
        {
            return new OrderDto
            {
                ID = inOrder.ID,
                TotalPrice = inOrder.TotalPrice,
                PurchaseDate = inOrder.PurchaseDate,
                TicketID = inOrder.TicketID,
                CustomerID = inOrder.CustomerID
            };
        }
        public static Order ToOrder(OrderDto inDto)
        {
            Order? aOrder = null;
            if (inDto != null)
            {
                aOrder = new Order(inDto.TotalPrice, inDto.PurchaseDate, inDto.TicketID, inDto.CustomerID);
            }
            return aOrder;
        }
    }
}
