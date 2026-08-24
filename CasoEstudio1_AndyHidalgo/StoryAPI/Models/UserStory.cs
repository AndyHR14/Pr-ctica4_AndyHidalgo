namespace StoryAPI.Models
{
    public enum UserStoryState { Backlog, ToDo, InProgress, Done }
    public class UserStory
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public UserStoryState Estado { get; set; }
        public int Estimacion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}

