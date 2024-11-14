using Microsoft.AspNetCore.Mvc;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;

namespace AuthValidator.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class SmsAuthController : ControllerBase 
    {
        private readonly ISmsAuthService _service;

        public SmsAuthController(ISmsAuthService service)
        {
            _service = service;
        }

        [HttpPost("generateTokenSMS")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateTokenSMS(User user)
        {
            await _service.GenerateTokenAsync(user);
            return Ok();
        }

        [HttpGet("validateSMSToken/{identificationNumber}/{token}")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> validateSMSToken(string identificationNumber, string token)
        {
            var isTokenValid = await _service.ValidateTokenAsync(identificationNumber, token);
            return Ok(isTokenValid);
        }
    }
}
