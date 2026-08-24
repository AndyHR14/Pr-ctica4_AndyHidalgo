using StoryAPI.Models;

namespace StoryAPI.Services
{
    public interface IUserStoryObserver
    {
        void OnEstadoCambiado(int userStoryId, UserStoryState nuevoEstado);
    }
}