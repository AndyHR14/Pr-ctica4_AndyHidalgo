using StoryAPI.Models;

namespace StoryAPI.Services
{
    public class UserStoryStateLogger : IUserStoryObserver
    {
        private readonly ObserverLog _log;
        public UserStoryStateLogger(ObserverLog log) => _log = log;

        public void OnEstadoCambiado(int userStoryId, UserStoryState nuevoEstado)
        {
            var mensaje = $"UserStory {userStoryId} cambió a {nuevoEstado} - {DateTime.Now:HH:mm:ss}";
            Console.WriteLine($"[Observer] {mensaje}");
            _log.Agregar(mensaje);
        }
    }
}