using Microsoft.AspNetCore.Mvc;
using StoryAPI.DTOs;
using StoryAPI.Services;

namespace StoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _svc;
        public UsuarioController(IUsuarioService svc) => _svc = svc;

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> Get() => await _svc.ListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var u = await _svc.GetAsync(id);
            if (u is null) return NotFound();
            return Ok(u);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create(CreateUsuarioDTO dto)
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
    }
}