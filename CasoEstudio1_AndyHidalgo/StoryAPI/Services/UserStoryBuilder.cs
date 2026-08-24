using StoryAPI.Models;

namespace StoryAPI.Services
{
    public class UserStoryBuilder
    {
        private readonly UserStory _story = new();

        public UserStoryBuilder ConTitulo(string titulo)
        { _story.Titulo = titulo; return this; }

        public UserStoryBuilder ConDescripcion(string descripcion)
        { _story.Descripcion = descripcion; return this; }

        public UserStoryBuilder ConUsuario(int usuarioId)
        { _story.UsuarioId = usuarioId; return this; }

        public UserStoryBuilder ConEstimacion(int estimacion)
        { _story.Estimacion = estimacion; return this; }

        public UserStoryBuilder ConEstado(UserStoryState estado)
        { _story.Estado = estado; return this; }

        public UserStory Build() => _story;
    }
}