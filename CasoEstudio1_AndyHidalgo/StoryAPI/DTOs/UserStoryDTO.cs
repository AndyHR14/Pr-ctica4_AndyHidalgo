namespace StoryAPI.DTOs
{
    public record UserStoryDTO(int Id, string Titulo, string Descripcion, string AsignadoA, string Estado, int Estimacion, int UsuarioId);
}
