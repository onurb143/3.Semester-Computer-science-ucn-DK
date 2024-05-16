namespace MomentozClientApp.Servicelayer
{
    // ServiceConnection-klassen implementerer IServiceConnection-grænsefladen.
    // Denne klasse bruges til at håndtere HTTP-forbindelser til API.
    public class ServiceConnection : IServiceConnection
    {
        public HttpClient HttpClient { get; private set; }


        // Konstruktøren initialiserer klassen med en basis-URL for serviceforbindelsen.
        public ServiceConnection(String? inBaseUrl)
        {
            // Initialiserer HttpClient, som bruges til at foretage HTTP-anmodninger.
            HttpEnabler = new HttpClient();
            // Sætter den grundlæggende URL for forbindelsen.
            BaseUrl = inBaseUrl;
            // UseUrl bruges til at sætte den specifikke URL for en anmodning. 

            // Den initialiseres til BaseUrl som standard.
            UseUrl = BaseUrl;
            HttpClient = new HttpClient();
        }

        // HttpEnabler er en instans af HttpClient og er skjult for eksterne klasser (private get).
        // 'init' betyder, at denne ejendom kun kan sættes under objektets initialisering.
        public HttpClient HttpEnabler { private get; init; }

        // BaseUrl indeholder den grundlæggende URL for HTTP-forbindelser.
        public string? BaseUrl { get; init; }

        // UseUrl kan ændres og indeholder den aktuelle URL, der anvendes for HTTP-anmodninger.
        public string? UseUrl { get; set; }

        // Asynkront kalder en webtjeneste ved hjælp af HTTP GET-metoden.
        public async Task<HttpResponseMessage?> CallServiceGet()
        {
            // Initialiserer en variabel til at holde svaret fra HTTP-anmodningen.
            HttpResponseMessage? hrm = null;
            // Hvis UseUrl ikke er null, foretages der en GET-anmodning.
            if (UseUrl != null)
            {
                hrm = await HttpEnabler.GetAsync(UseUrl);
            }
            // Returnerer HTTP-svaret fra tjenesten.
            return hrm;
        }


        // Asynkront kalder en webtjeneste ved hjælp af HTTP POST-metoden.
        public async Task<HttpResponseMessage?> CallServicePost(StringContent postJson)
        {
            // Initialiserer en variabel til at holde svaret fra HTTP-anmodningen.
            HttpResponseMessage? hrm = null;
            // Hvis UseUrl ikke er null, foretages der en POST-anmodning med den givne JSON-indhold.
            if (UseUrl != null)
            {
                hrm = await HttpEnabler.PostAsync(UseUrl, postJson);
            }
            // Returnerer HTTP-svaret fra tjenesten.
            return hrm;
        }

        public Task<HttpResponseMessage?> CallServicePut(StringContent postJson)
        {
            throw new NotImplementedException();
        }
        public Task<HttpResponseMessage?> CallServiceDelete()
        {
            throw new NotImplementedException();
        }
    }
}
