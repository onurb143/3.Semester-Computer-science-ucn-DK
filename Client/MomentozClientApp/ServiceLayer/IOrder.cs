using MomentozClientApp.Model;  // Bruger Order-klassen fra MomentozClientApp.Model namespace.

namespace MomentozClientApp.ServiceLayer
{
    public interface IOrderAccess
    {
        Task<Order> GetOrderById(int orderID);  // Metode til at hente en ordre efter ID.
        Task<List<Order>> GetOrderAll();  // Metode til at hente alle ordrer som en liste.
        Task<Order> CreateOrder(Order orderToAdd);  // Metode til at oprette en ny ordre.
        bool UpdateOrder(Order orderToUpdate);  // Metode til at opdatere en eksisterende ordre.
        bool DeleteOrderById(int orderID);  // Metode til at slette en ordre efter ID.
        Order? GetOrderByCustomerId(int customerID);  // Metode til at hente en ordre efter kunde-ID.
    }
}
