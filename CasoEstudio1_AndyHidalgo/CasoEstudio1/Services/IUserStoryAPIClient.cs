using AgileBoard.Web.Models;

namespace AgileBoard.Web.Services
{
    public interface IUserStoryAPIClient
    {
        Task<List<UserStoryViewModel>> GetUserStoryAsync(CancellationToken cancellation = default);
        Task CreateOrderAsync(string Titulo, string Descripcion, int UsuarioId, CancellationToken cancellation = default);
        Task UpdateStateAsync(int id, string newState, CancellationToken cancellation = default);
        Task<List<string>> GetLogsAsync(CancellationToken cancellation = default);
    }
}
