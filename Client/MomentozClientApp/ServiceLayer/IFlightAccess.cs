using MomentozClientApp.Model;

namespace MomentozClientApp.Servicelayer
{
    // IFlightAccess er et interface, der definerer kontrakten for flyadgang.
    // Alle klasser, der implementerer dette interface, skal implementere disse metoder.
    public interface IFlightAccess
    {
        // Asynkron metode til at hente et fly baseret på dets id.
        // Returnerer et Flight-objekt eller null, hvis flyet ikke findes.
        Task<Flight> GetFlightById(int id);

        // Asynkron metode til at hente alle tilgængelige flyvninger.
        // Returnerer en liste af Flight-objekter.
        Task<List<Flight>> GetAllFlights();


        // Asynkron metode til at oprette en ny flyvning.
        // Modtager et Flight-objekt som parameter og returnerer en identifikator for den oprettede flyvning.
        Task<int> CreateFlight(Flight flight);

        // Asynkron metode til at opdatere en eksisterende flyvning.
        // Modtager et Flight-objekt som parameter. Returnerer 'true', hvis opdateringen lykkes, ellers 'false'.
        Task<bool> UpdateFlight(Flight flight);

        // Asynkron metode til at slette et fly baseret på dets id.
        // Returnerer 'true', hvis sletningen lykkes, ellers 'false'.
        Task<bool> DeleteFlightById(int id);

        // Asynkron metode til at hente en flyvning baseret på en brugers id.
        // Returnerer det relevante Flight-objekt, hvis det findes, ellers null.
        Task<Flight> GetFlightByUserId(string loginUserId);
    }
}
