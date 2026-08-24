using StoryAPI.Models;
using StoryAPI.Services;

namespace StoryAPI.Commands
{
    public class UpdateStateCommand : ICommand
    {
        private readonly IUserStoryService _service;
        private readonly int _id;
        private readonly UserStoryState _state;

        public UpdateStateCommand(IUserStoryService service, int id, UserStoryState state)
        {
            _service = service;
            _id = id;
            _state = state;
        }

        public async Task ExecuteAsync() => await _service.UpdateStateAsync(_id, _state);
    }
}