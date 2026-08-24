using StoryAPI.DTOs;
using StoryAPI.Models;
using StoryAPI.Repositories;

namespace StoryAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo) => _repo = repo;

        public async Task<IEnumerable<UsuarioDTO>> ListAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(u => new UsuarioDTO(u.Id, u.Nombre, u.Apellidos, u.Email, u.PokemonId));
        }

        public async Task<UsuarioDTO?> GetAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            return u is null ? null : new UsuarioDTO(u.Id, u.Nombre, u.Apellidos, u.Email, u.PokemonId);
        }

        public async Task<UsuarioDTO> CreateAsync(CreateUsuarioDTO dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                PokemonId = dto.PokemonId
            };

            await _repo.AddAsync(usuario);
            return new UsuarioDTO(usuario.Id, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.PokemonId);
        }

    }
}
