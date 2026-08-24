using AgileBoard.Web.Models;

namespace AgileBoard.Web.Services
{
    public class UsuarioAPIClient : IUsuarioAPIClient
    {
        private readonly HttpClient _http;
        public UsuarioAPIClient(HttpClient http) => _http = http;

        public async Task<List<UsuarioViewModel>> GetUsuariosAsync(CancellationToken cancellation = default)
        {
            var response = await _http.GetAsync("api/Usuario", cancellation);
            if (!response.IsSuccessStatusCode) return new List<UsuarioViewModel>();
            return await response.Content.ReadFromJsonAsync<List<UsuarioViewModel>>(cancellationToken: cancellation)
                   ?? new List<UsuarioViewModel>();
        }
        public async Task<UsuarioViewModel?> GetUsuarioAsync(int id, CancellationToken cancellation = default)
        {
            var response = await _http.GetAsync($"api/Usuario/{id}", cancellation);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<UsuarioViewModel?>(cancellationToken: cancellation);
        }

        public async Task CreateUsuarioAsync(string Nombre, string Apellidos, string Email, int PokemonId, CancellationToken cancellation = default)
        {
            var dto = new { Nombre, Apellidos, Email, PokemonId };
            var response = await _http.PostAsJsonAsync("api/Usuario", dto, cancellation);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear usuario: {error}");
            }
        }
    }
}