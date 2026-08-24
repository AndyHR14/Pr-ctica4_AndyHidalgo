using StoryAPI.DTOs;
using StoryAPI.Services;

namespace StoryAPI.Commands
{
    public class CreateUserStoryCommand : ICommand
    {
        private readonly IUserStoryService _service;
        private readonly CreateUserStoryDTO _dto;

        public CreateUserStoryCommand(IUserStoryService service, CreateUserStoryDTO dto)
        {
            _service = service;
            _dto = dto;
        }

        public async Task ExecuteAsync() => await _service.CreateAsync(_dto);
    }
}