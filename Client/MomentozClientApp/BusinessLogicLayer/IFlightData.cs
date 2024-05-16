using MomentozClientApp.Model;

// Definerer navneområdet for forretningslogiklaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // IFlightdata er et interface, der definerer kontrakten for operationer relateret til fly-data.
    public interface IFlightdata
    {
        // Metode til at hente en specifik flyvning baseret på dens id og returnere den som en FlightDto.
        Flight Get(int id);

        // Metode til at hente en liste af alle flyvninger og returnere dem som FlightDto'er.
        List<Flight>? Get();

        // Metode til at tilføje en ny flyvning. Modtager en FlightDto og returnerer et id for den tilføjede flyvning.
        int Add(Flight flightToAdd);

        // Metode til at opdatere en eksisterende flyvning. Modtager en FlightDto og returnerer en boolsk værdi, der indikerer, om opdateringen var succesfuld.
        bool Put(Flight flightToUpdate);

        // Metode til at slette en flyvning baseret på dens id. Returnerer en boolsk værdi, der indikerer, om sletningen var succesfuld.
        bool Delete(int id);

        // Metode til at hente en flyvning baseret på dens id og returnere den som en FlightDto. 
        // Det er en ekstra metode, der ligner den første Get-metode og kan føre til forvirring.
        Flight? GetFlightById(int id);
    }
}
