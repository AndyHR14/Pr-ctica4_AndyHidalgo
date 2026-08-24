namespace StoryAPI.Services
{
    public abstract class EstimacionBase
    {
        public async Task<int> EstimarAsync()
        {
            var valor = await ObtenerValorAsync();
            return AjustarValor(valor);
        }

        protected abstract Task<int> ObtenerValorAsync();

        protected virtual int AjustarValor(int valor) => valor;
    }
}