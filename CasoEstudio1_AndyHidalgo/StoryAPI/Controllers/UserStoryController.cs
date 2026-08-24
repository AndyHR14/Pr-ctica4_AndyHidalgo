using Microsoft.AspNetCore.Mvc;
using StoryAPI.Commands;
using StoryAPI.DTOs;
using StoryAPI.Models;
using StoryAPI.Services;

namespace StoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStoryController : ControllerBase
    {
        private readonly IUserStoryService _svc;
        public UserStoryController(IUserStoryService svc) => _svc = svc;

        [HttpGet]
        public async Task<IEnumerable<UserStoryDTO>> Get() => await _svc.ListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStoryDTO>> Get(int id)
        {
            var o = await _svc.GetAsync(id);
            if (o is null) return NotFound();
            return Ok(o);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserStoryDTO dto)
        {
            var command = new CreateUserStoryCommand(_svc, dto);
            await command.ExecuteAsync();
            return Ok();
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> UpdateState(int id, [FromQuery] string newState)
        {
            var state = Enum.Parse<UserStoryState>(newState);
            var command = new UpdateStateCommand(_svc, id, state);
            await command.ExecuteAsync();
            return Ok();
        }
    }
}
