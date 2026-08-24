using StoryAPI.DTOs;
using StoryAPI.Models;

namespace StoryAPI.Services
{
    public interface IUserStoryService
    {
        Task<IEnumerable<UserStoryDTO>> ListAsync();
        Task<UserStoryDTO?> GetAsync(int id);
        Task<bool> UpdateStateAsync(int id, UserStoryState newState);
        Task<UserStoryDTO> CreateAsync(CreateUserStoryDTO dto);
    }
}
