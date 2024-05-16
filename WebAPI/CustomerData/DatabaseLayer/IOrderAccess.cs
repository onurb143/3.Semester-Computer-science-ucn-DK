using DatabaseData.ModelLayer;

namespace DatabaseData.DatabaseLayer
{
    public interface IOrderAccess
    {
        Order GetOrderById(int id);
        List<Order> GetOrderAll();
        int CreateOrder(Order orderToAdd);
        bool UpdateOrder(Order orderToUpdate);
        bool DeleteOrderById(int id);
        Order? GetOrderByCustomerId(int customerId);
    }
}
