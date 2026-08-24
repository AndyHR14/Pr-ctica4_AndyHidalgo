using StoryAPI.DTOs;
using StoryAPI.Models;
using StoryAPI.Repositories;

namespace StoryAPI.Services
{
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryRepository _repo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEnumerable<IUserStoryObserver> _observers;

        public UserStoryService(IUserStoryRepository repo, IUsuarioRepository usuarioRepo,
                IEnumerable<IUserStoryObserver> observers)
        {
            _repo = repo;
            _usuarioRepo = usuarioRepo;
            _observers = observers;
        }

        public async Task<IEnumerable<UserStoryDTO>> ListAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(o => new UserStoryDTO(o.Id, o.Titulo, o.Descripcion, o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellidos}" : "Sin asignar", o.Estado.ToString(), o.Estimacion, o.UsuarioId));
        }

        public async Task<UserStoryDTO?> GetAsync(int id)
        {
            var o = await _repo.GetByIdAsync(id);
            return o is null ? null : new UserStoryDTO(o.Id, o.Titulo, o.Descripcion, o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellidos}" : "Sin asignar", o.Estado.ToString(), o.Estimacion, o.UsuarioId);
        }

        public async Task<UserStoryDTO> CreateAsync(CreateUserStoryDTO dto)
        {
            EstimacionBase estimador = new FibonacciEstimacion();
            int estimacion = await estimador.EstimarAsync();

            var usuario = await _usuarioRepo.GetByIdAsync(dto.UsuarioId);

            var userStory = new UserStoryBuilder()
            .ConTitulo(dto.Titulo)
            .ConDescripcion(dto.Descripcion)
            .ConUsuario(dto.UsuarioId)
            .ConEstimacion(estimacion)
            .ConEstado(UserStoryState.Backlog)
            .Build();

            await _repo.AddAsync(userStory);

            return new UserStoryDTO(
                userStory.Id,
                userStory.Titulo,
                userStory.Descripcion,
                usuario != null ? $"{usuario.Nombre} {usuario.Apellidos}" : "Sin asignar",
                userStory.Estado.ToString(),
                userStory.Estimacion,
                userStory.UsuarioId
            );
        }

        public async Task<bool> UpdateStateAsync(int id, UserStoryState newState)
        {
            var userStory = await _repo.GetByIdAsync(id);
            if (userStory == null) return false;
            userStory.Estado = newState;
            await _repo.UpdateAsync(userStory);

            foreach (var observer in _observers)
                observer.OnEstadoCambiado(id, newState);

            return true;
        }
    }
}
