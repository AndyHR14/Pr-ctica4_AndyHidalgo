using StoryAPI.Models;

namespace StoryAPI.Repositories
{
    public interface IUserStoryRepository
    {
        Task<IEnumerable<UserStory>> GetAllAsync();
        Task<UserStory?> GetByIdAsync(int id);
        Task AddAsync(UserStory userStory);
        Task UpdateAsync(UserStory userStory);
    }
}
