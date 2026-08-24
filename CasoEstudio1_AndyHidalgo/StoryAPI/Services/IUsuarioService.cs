using StoryAPI.DTOs;

namespace StoryAPI.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> ListAsync();
        Task<UsuarioDTO?> GetAsync(int id);
        Task<UsuarioDTO> CreateAsync(CreateUsuarioDTO dto);
    }
}
