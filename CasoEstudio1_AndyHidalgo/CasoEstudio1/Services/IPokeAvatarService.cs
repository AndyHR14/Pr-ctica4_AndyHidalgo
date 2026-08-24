namespace AgileBoard.Web.Services
{
    public interface IPokeAvatarService
    {
        Task<string> GetAvatarUrlAsync(int pokemonId);
    }
}
