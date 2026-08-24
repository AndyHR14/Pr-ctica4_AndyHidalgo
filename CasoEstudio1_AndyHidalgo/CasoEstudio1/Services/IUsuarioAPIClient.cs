using AgileBoard.Web.Models;

namespace AgileBoard.Web.Services
{
    public interface IUsuarioAPIClient
    {
        Task<List<UsuarioViewModel>> GetUsuariosAsync(CancellationToken cancellation = default);
        Task<UsuarioViewModel?> GetUsuarioAsync(int id, CancellationToken cancellation = default);
        Task CreateUsuarioAsync(string Nombre, string Apellidos, string Email, int pokemonApi, CancellationToken cancellation = default);
    }
}