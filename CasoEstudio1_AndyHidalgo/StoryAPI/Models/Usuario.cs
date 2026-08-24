namespace StoryAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PokemonId { get; set; }
        public ICollection<UserStory> UserStory { get; set; } = new List<UserStory>();
    }
}