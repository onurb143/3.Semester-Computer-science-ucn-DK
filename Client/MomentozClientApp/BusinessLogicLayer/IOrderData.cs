using MomentozClientApp.Model;  // Bruger Order-klassen fra MomentozClientApp.Model namespace.

namespace MomentozClientApp.BusinessLogicLayer
{
    // IOrderdata-grænsefladen definerer kontraktmetoder til behandling af ordredata.
    public interface IOrderdata
    {
        // Metode til at hente en ordre efter ID.
        Order? Get(int orderID);

        // Metode til at hente alle ordrer som en liste.
        List<Order>? Get();

        // Metode til at tilføje en ny ordre.
        int Add(Order orderToAdd);

        // Metode til at opdatere en eksisterende ordre.
        bool Put(Order orderToUpdate);

        // Metode til at slette en ordre efter ID.
        bool Delete(int orderID);
    }
}
