using Microsoft.AspNetCore.Mvc;
using AuthValidator.Services.Interfaces;
using AuthValidator.Models;

namespace AuthValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleAuthController : ControllerBase
    {
        private readonly IGoogleAuthService _service;

        public GoogleAuthController(IGoogleAuthService service)
        {
            _service = service;
        }

        [HttpPost("generateQRCode")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateQRCode(User user)
        {
            var result = await _service.GenerateQRCode(user);
            return Ok(result);
        }

        [HttpGet("validatePIN/{identificationNumber}/{token}")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidatePIN(string identificationNumber, string token)
        {
            var isPinValid = await _service.ValidatePIN(identificationNumber, token);
            return Ok(isPinValid);
        }
    }
}