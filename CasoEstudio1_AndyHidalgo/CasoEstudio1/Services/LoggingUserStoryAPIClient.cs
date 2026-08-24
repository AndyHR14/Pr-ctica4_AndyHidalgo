using AgileBoard.Web.Models;

namespace AgileBoard.Web.Services
{
    public class LoggingUserStoryAPIClient : IUserStoryAPIClient
    {
        private readonly IUserStoryAPIClient _inner;
        private readonly ILogger<LoggingUserStoryAPIClient> _logger;

        public LoggingUserStoryAPIClient(IUserStoryAPIClient inner,
            ILogger<LoggingUserStoryAPIClient> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<List<UserStoryViewModel>> GetUserStoryAsync(CancellationToken cancellation = default)
        {
            _logger.LogInformation("[Decorator] Obteniendo todas las UserStories");
            var result = await _inner.GetUserStoryAsync(cancellation);
            _logger.LogInformation("[Decorator] Se obtuvieron {Count} UserStories", result.Count);
            return result;
        }

        public async Task CreateOrderAsync(string Titulo, string Descripcion, int UsuarioId, CancellationToken cancellation = default)
        {
            _logger.LogInformation("[Decorator] Creando UserStory: {Titulo}", Titulo);
            await _inner.CreateOrderAsync(Titulo, Descripcion, UsuarioId, cancellation);
            _logger.LogInformation("[Decorator] UserStory creada exitosamente");
        }

        public async Task UpdateStateAsync(int id, string newState, CancellationToken cancellation = default)
        {
            _logger.LogInformation("[Decorator] Cambiando estado de UserStory {Id} a {State}", id, newState);
            await _inner.UpdateStateAsync(id, newState, cancellation);
            _logger.LogInformation("[Decorator] Estado actualizado exitosamente");
        }
        public async Task<List<string>> GetLogsAsync(CancellationToken cancellation = default)
        {
            _logger.LogInformation("[Decorator] Obteniendo logs del Observer");
            var result = await _inner.GetLogsAsync(cancellation);
            _logger.LogInformation("[Decorator] Se obtuvieron {Count} logs", result.Count);
            return result;
        }
    }
}