using AgileBoard.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAPIClient _api;
        private readonly IPokeAPIClient _pokemonApi;
        private readonly IPokeAvatarService _avatarService;

        public UsuarioController(IUsuarioAPIClient api, IPokeAPIClient pokemonApi, IPokeAvatarService avatarService)
        {
            _api = api;
            _pokemonApi = pokemonApi;
            _avatarService = avatarService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _api.GetUsuariosAsync();

            // Llena el AvatarUrl de cada usuario en paralelo
            var tasks = usuarios.Select(async u =>
            {
                u.AvatarId = await _avatarService.GetAvatarUrlAsync(u.PokemonId);
                return u;
            });

            var usuariosConAvatar = (await Task.WhenAll(tasks)).ToList();
            return View(usuariosConAvatar);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Nombre, string Apellidos, string Email)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellidos) || string.IsNullOrWhiteSpace(Email))
                return BadRequest("Todos los campos son requeridos");

            // Obtiene el número de tu PokemonNumberApi con fallback
            var pokemonId = await _pokemonApi.GetPokemonNumberAsync();

            await _api.CreateUsuarioAsync(Nombre, Apellidos, Email, pokemonId);
            return RedirectToAction(nameof(Index));
        }
    }
}
