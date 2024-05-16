
namespace MomentozClientApp.Servicelayer
{
    // IServiceConnection er et intern interface, hvilket betyder, at det kun er tilgængeligt inden for samme assembly.
    internal interface IServiceConnection
    {
        // BaseUrl er en egenskab, der indeholder grundlæggende URL for webtjenesteforbindelsen. 
        // Det er markeret med 'init', hvilket betyder, at det kun kan sættes ved initialisering.
        public string? BaseUrl { get; init; }

        // UseUrl er en egenskab, der kan ændres og bruges til at definere den specifikke URL for en given anmodning.
        public string? UseUrl { get; set; }

        public interface IServiceConnection
        {
            HttpClient HttpClient { get; }
            // ... andre medlemmer af interfacet ...
        }

        // Asynkron metode til at foretage en GET-anmodning til webtjenesten.
        // Returnerer en HttpResponseMessage, som indeholder svaret fra anmodningen.
        Task<HttpResponseMessage?> CallServiceGet();

        // Asynkron metode til at foretage en POST-anmodning til webtjenesten med en given JSON-indhold.
        // Returnerer en HttpResponseMessage, som indeholder svaret fra anmodningen.
        Task<HttpResponseMessage?> CallServicePost(StringContent postJson);

        // Asynkron metode til at foretage en PUT-anmodning til webtjenesten med en given JSON-indhold.
        // Returnerer en HttpResponseMessage, som indeholder svaret fra anmodningen.
        Task<HttpResponseMessage?> CallServicePut(StringContent postJson);

        // Asynkron metode til at foretage en DELETE-anmodning til webtjenesten.
        // Returnerer en HttpResponseMessage, som indeholder svaret fra anmodningen.
        Task<HttpResponseMessage?> CallServiceDelete();
    }
}
