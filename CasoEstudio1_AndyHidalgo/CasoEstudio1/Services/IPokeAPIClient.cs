namespace AgileBoard.Web.Services
{
    public interface IPokeAPIClient
    {
        Task<int> GetPokemonNumberAsync(CancellationToken cancellation = default);
    }
}
