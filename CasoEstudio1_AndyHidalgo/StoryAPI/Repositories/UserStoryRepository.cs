using Microsoft.EntityFrameworkCore;
using StoryAPI.Data;
using StoryAPI.Models;

namespace StoryAPI.Repositories
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly AppDbContext _db;
        public UserStoryRepository(AppDbContext db) => _db = db;
        public async Task<IEnumerable<UserStory>> GetAllAsync()
    => await _db.UserStory.AsNoTracking().Include(us => us.Usuario).ToListAsync();

        public async Task<UserStory?> GetByIdAsync(int id)
    => await _db.UserStory
        .Include(us => us.Usuario)
        .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(UserStory userStory)
        {
            _db.UserStory.Add(userStory);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserStory userStory)
        {
            _db.UserStory.Update(userStory);
            await _db.SaveChangesAsync();
        }
    }
}
