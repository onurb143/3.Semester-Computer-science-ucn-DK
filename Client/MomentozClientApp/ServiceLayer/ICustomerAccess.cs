using MomentozClientApp.Model;


// Definerer navneområdet for servicelaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Servicelayer
{
    // ICustomerAccess er et interface, der definerer kontrakten for kunde-adgang.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface ICustomerAccess
    {
        // Asynkron metode til at hente en kunde baseret på dets id.
        // Returnerer et Customer-objekt eller null, hvis kunden ikke findes.
        Task<Customer> GetCustomerByEmail(string email);

        // Asynkron metode til at hente alle tilgængelige kunder.
        // Returnerer en liste af Customer-objekter.
        Task<List<Customer>> GetCustomerAll();

        // Asynkron metode til at oprette en ny kunde.
        // Modtager et Customer-objekt som parameter og returnerer en identifikator for den oprettede kunde.
        Task<int> CreateCustomer(Customer customer);

        // Asynkron metode til at opdatere en eksisterende kunde.
        // Modtager et Customer-objekt som parameter. Returnerer 'true', hvis opdateringen lykkes, ellers 'false'.
        Task<bool> UpdateCustomer(Customer customer);

        // Asynkron metode til at slette en kunde baseret på dets id.
        // Returnerer 'true', hvis sletningen lykkes, ellers 'false'.
        Task<bool> DeleteCustomerById(int id);

        // Asynkron metode til at hente en kunde baseret på en brugers id.
        // Returnerer det relevante Customer-objekt, hvis det findes, ellers null.
        Task<Customer> GetCustomerByUserId(string loginUserId);
    }
}
