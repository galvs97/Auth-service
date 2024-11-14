using Microsoft.AspNetCore.Mvc;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;

namespace AuthValidator.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _service.Create(user);
            return Ok(user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _service.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
