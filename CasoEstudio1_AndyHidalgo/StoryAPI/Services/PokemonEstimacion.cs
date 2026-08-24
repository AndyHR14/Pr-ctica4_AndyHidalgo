using StoryAPI.Services;
using System.Text.Json;

public class PokemonEstimacion : EstimacionBase
{
    protected override async Task<int> ObtenerValorAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5047/pokemon/number");
        if (!response.IsSuccessStatusCode) return 0;
        var data = await response.Content.ReadFromJsonAsync<JsonElement>();
        return data.GetProperty("pokemonNumber").GetInt32() % 13 + 1;
    }
}
