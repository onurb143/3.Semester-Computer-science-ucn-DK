        using RESTfulService.DTOs;
        using DatabaseData.ModelLayer;

        namespace RESTfulService.ModelConversion
        {
        public class OrderDtoConvert
        {
        public static List<OrderDto> FromOrderCollection(List<Order> inOrders)
        {
            if (inOrders == null)
                return null;
            var aOrderReadDtoList = new List<OrderDto>();
            foreach (Order aOrder in inOrders)
            {
                var tempDto = FromOrder(aOrder);
                aOrderReadDtoList.Add(tempDto);
            }
            return aOrderReadDtoList;
        }

        public static OrderDto FromOrder(Order inOrder)
        {
            if (inOrder == null)
                return null;

            return new OrderDto(inOrder.OrderID, inOrder.TotalPrice, inOrder.PurchaseDate, inOrder.CustomerID, inOrder.FlightID);
        }

        public static Order ToOrder(OrderDto inDto)
        {
                if (inDto == null)
                    return null;
           
            return new Order(inDto.OrderID, inDto.TotalPrice, inDto.PurchaseDate, inDto.CustomerID, inDto.FlightID);
        }
    }
}
