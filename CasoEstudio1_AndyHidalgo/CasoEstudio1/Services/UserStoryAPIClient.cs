using AgileBoard.Web.Models;

namespace AgileBoard.Web.Services
{
    public class UserStoryAPIClient : IUserStoryAPIClient
    {
        private readonly HttpClient _http;

        public UserStoryAPIClient(HttpClient http) => _http = http;

        public async Task<List<UserStoryViewModel>> GetUserStoryAsync(CancellationToken cancellation = default)
{
    var response = await _http.GetAsync("api/UserStory", cancellation);
    
    if (!response.IsSuccessStatusCode)
    {
        var errorContent = await response.Content.ReadAsStringAsync(); 
        throw new Exception($"Error en la API: {response.StatusCode}. Detalle: {errorContent}");
    }

    return await response.Content.ReadFromJsonAsync<List<UserStoryViewModel>>(cancellationToken: cancellation) 
           ?? new List<UserStoryViewModel>();
}
        public async Task CreateOrderAsync(string Titulo, string Descripcion, int UsuarioId, CancellationToken cancellation = default)
        {
            var dto = new { Titulo = Titulo, Descripcion = Descripcion, UsuarioId = UsuarioId };

            var response = await _http.PostAsJsonAsync("api/UserStory", dto, cancellation);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error 500 en API: {error}");
            }
        }

        public async Task UpdateStateAsync(int id, string newState, CancellationToken cancellation = default)
        {
            await _http.PostAsync($"api/UserStory/{id}/update?newState={newState}", null, cancellation);
        }

        public async Task<List<string>> GetLogsAsync(CancellationToken cancellation = default)
        {
            var response = await _http.GetAsync("userstory/logs", cancellation);
            return await response.Content.ReadFromJsonAsync<List<string>>() ?? new();
        }
    }
}
