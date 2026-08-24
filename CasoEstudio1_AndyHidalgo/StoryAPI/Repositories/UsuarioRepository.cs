using Microsoft.EntityFrameworkCore;
using StoryAPI.Data;
using StoryAPI.Models;

namespace StoryAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _db;
        public UsuarioRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Usuario>> GetAllAsync()
            => await _db.Usuario.AsNoTracking().ToListAsync();

        public async Task<Usuario?> GetByIdAsync(int id)
            => await _db.Usuario.FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(Usuario usuario)
        {
            _db.Usuario.Add(usuario);
            await _db.SaveChangesAsync();
        }
    }
}
