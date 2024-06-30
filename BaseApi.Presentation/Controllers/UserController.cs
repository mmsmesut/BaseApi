using BaseApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public UserController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateToken(string userId, string userName)
        {
            var token = _tokenService.GenerateToken(userId, userName);
            return Ok(new { Token = token });
        }
    }
}
