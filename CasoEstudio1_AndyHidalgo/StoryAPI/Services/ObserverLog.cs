namespace StoryAPI.Services
{
    public class ObserverLog
    {
        private readonly List<string> _mensajes = new();
        public IReadOnlyList<string> Mensajes => _mensajes;
        public void Agregar(string mensaje) => _mensajes.Add(mensaje);
    }
}