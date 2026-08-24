using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace AgileBoard.Web.Services
{
    public class PokeAvatarService : IPokeAvatarService
    {
        private readonly HttpClient _http;
        private readonly IMemoryCache _cache;

        public PokeAvatarService(HttpClient http, IMemoryCache cache)
        {
            _http = http;
            _cache = cache;
        }

        public async Task<string> GetAvatarUrlAsync(int pokemonId)
        {
            try
            {
                var cacheKey = $"pokemon_sprite_{pokemonId}";
                if (_cache.TryGetValue(cacheKey, out string? cachedUrl))
                    return cachedUrl ?? string.Empty;

                var response = await _http.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonId}");
                if (!response.IsSuccessStatusCode) return string.Empty;

                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);
                var spriteUrl = doc.RootElement
                                   .GetProperty("sprites")
                                   .GetProperty("front_default")
                                   .GetString() ?? string.Empty;

                _cache.Set(cacheKey, spriteUrl, TimeSpan.FromMinutes(10));
                return spriteUrl;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
