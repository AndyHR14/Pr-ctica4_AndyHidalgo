using AgileBoard.Web.Models;
using AgileBoard.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.Web.Controllers
{
    public class UserStoryController : Controller
    {
        private readonly IUserStoryAPIClient _api;
        private readonly IUsuarioAPIClient _usuariosApi;
        private readonly IPokeAvatarService _avatarService;


        public UserStoryController(IUserStoryAPIClient api, IUsuarioAPIClient usuariosApi, IPokeAvatarService avatarService)
        {
            _api = api;
            _usuariosApi = usuariosApi;
            _avatarService = avatarService; 
        }
        public async Task<IActionResult> Index()
        {
            var historias = await _api.GetUserStoryAsync();
            var usuarios = await _usuariosApi.GetUsuariosAsync();
            var logs = await _api.GetLogsAsync();

            historias ??= new List<UserStoryViewModel>();
            usuarios ??= new List<UsuarioViewModel>();

            var avatarTasks = usuarios.Select(async u =>
            {
                u.AvatarId = await _avatarService.GetAvatarUrlAsync(u.PokemonId);
                return u;
            });
            var usuariosConAvatar = (await Task.WhenAll(avatarTasks)).ToList();

            var usuarioDict = usuariosConAvatar.ToDictionary(u => u.Id);
            foreach (var h in historias)
            {
                if (usuarioDict.TryGetValue(h.UsuarioId, out var u))
                    h.AvatarId = u.AvatarId;
            }

            var model = new BoardViewModel
            {
                Backlog = historias.Where(x => x.Estado == "Backlog").ToList(),
                ToDo = historias.Where(x => x.Estado == "ToDo").ToList(),
                InProgress = historias.Where(x => x.Estado == "InProgress").ToList(),
                Done = historias.Where(x => x.Estado == "Done").ToList(),
                Usuarios = usuariosConAvatar,
                Logs = logs
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Titulo, string Descripcion, int UsuarioId)
        {
            if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Descripcion))
                return BadRequest("Titulo y descripcion son requeridos");

            await _api.CreateOrderAsync(Titulo, Descripcion, UsuarioId);
            TempData["DecoratorMsg"] = $"[Decorator] UserStory '{Titulo}' creada exitosamente";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string newState)
        {
            await _api.UpdateStateAsync(id, newState);
            TempData["DecoratorMsg"] = $"[Decorator] UserStory {id} movida a {newState}"; 
            return RedirectToAction(nameof(Index));
        }

    }

}
