namespace AgileBoard.Web.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PokemonId { get; set; }
        public string AvatarId { get; set; } = string.Empty;
    }
}