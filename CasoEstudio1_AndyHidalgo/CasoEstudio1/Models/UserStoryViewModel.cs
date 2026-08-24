namespace AgileBoard.Web.Models
{
    public class UserStoryViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string AsignadoA { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int Estimacion { get; set; }
        public string AvatarId { get; set; } = string.Empty;
    }
}
