using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{
    public class OrderdataControl : IOrderdata
    {
        private readonly IOrderAccess _orderAccess;

        public OrderdataControl(IOrderAccess inOrderAccess){
            _orderAccess = inOrderAccess;
        }
        public OrderDto? Get(int idToMatch)
        {
            OrderDto? foundOrderDto;
            try
            {
                Order? foundOrder = _orderAccess.GetOrderById(idToMatch);
                foundOrderDto = ModelConversion.OrderDtoConvert.FromOrder(foundOrder);
            }
            catch
            {
                foundOrderDto = null;
            }
            return foundOrderDto;
        }

        public List<OrderDto>? Get()
        {
            List<OrderDto>? foundDtos;
            try
            {
                List<Order>? foundOrders = _orderAccess.GetOrderAll();
                foundDtos = ModelConversion.OrderDtoConvert.FromOrderCollection(foundOrders);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }

        public OrderDto CreateOrder(OrderDto orderToAdd)
        {
            Order? foundOrder = ModelConversion.OrderDtoConvert.ToOrder(orderToAdd);
            if (foundOrder != null)
            {
                int insertedId = _orderAccess.CreateOrder(foundOrder);
                if (insertedId > 0)
                {
                    // Antager at du kan hente det indsatte objekt ved hjælp af ID
                    Order insertedOrder = _orderAccess.GetOrderById(insertedId);
                    return ModelConversion.OrderDtoConvert.FromOrder(insertedOrder);
                }
            }
            // Håndter fejltilfælde, f.eks. ved at returnere null eller kaste en exception
            return null;
        }

        public OrderDto? GetOrderByCustomerId(int customerId)
        {
            OrderDto? foundOrderDto;
            try
            {
                Order? foundOrder = _orderAccess.GetOrderByCustomerId(customerId);
                foundOrderDto = ModelConversion.OrderDtoConvert.FromOrder(foundOrder);
            }
            catch
            {
                foundOrderDto = null;
            }
            return foundOrderDto;
        }

        public OrderDto Put(OrderDto orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
