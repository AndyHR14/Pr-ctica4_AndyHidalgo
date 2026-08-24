using System.Text.Json;

namespace AgileBoard.Web.Services
{
    public class PokeAPIClient : IPokeAPIClient
    {
        private readonly HttpClient _http;
        public PokeAPIClient(HttpClient http) => _http = http;

        public async Task<int> GetPokemonNumberAsync(CancellationToken cancellation = default)
        {
            try
            {
                var response = await _http.GetAsync("pokemon/number", cancellation);
                if (!response.IsSuccessStatusCode) return NumPok();

                var json = await response.Content.ReadAsStringAsync(cancellation);
                var doc = JsonDocument.Parse(json);
                return doc.RootElement.GetProperty("pokemonNumber").GetInt32();
            }
            catch
            {
                return NumPok();
            }
        }

        private int NumPok() => Random.Shared.Next(1, 152);
    }
}
