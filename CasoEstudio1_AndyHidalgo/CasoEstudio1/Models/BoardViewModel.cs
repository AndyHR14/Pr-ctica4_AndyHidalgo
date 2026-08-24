namespace AgileBoard.Web.Models
{
    public class BoardViewModel
    {
        public List<UserStoryViewModel> Backlog { get; set; } = new();
        public List<UserStoryViewModel> ToDo { get; set; } = new();
        public List<UserStoryViewModel> InProgress { get; set; } = new();
        public List<UserStoryViewModel> Done { get; set; } = new();
        public List<UsuarioViewModel> Usuarios { get; set; } = new();
        public List<string> Logs { get; set; } = new();
    }
}
