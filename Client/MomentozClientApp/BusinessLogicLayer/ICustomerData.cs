using MomentozClientApp.Model;  // Bruger Customer-klassen fra MomentozClientApp.Model namespace.

namespace MomentozClientApp.BusinessLogicLayer
{
    // ICustomerdata-grænsefladen definerer kontraktmetoder til behandling af kundedata.
    public interface ICustomerdata
    {
        // Metode til at hente en kunde efter e-mail.
        Customer Get(string email);

        // Metode til at hente alle kunder som en liste.
        List<Customer>? Get();

        // Metode til at tilføje en ny kunde.
        int Add(Customer customerToAdd);

        // Metode til at opdatere en eksisterende kunde.
        bool Put(Customer customerToUpdate);

        // Metode til at slette en kunde efter ID.
        bool Delete(int id);

        // Metode til at hente en kunde efter login-brugerID.
        Customer? GetByUserId(string loginid);
    }
}
