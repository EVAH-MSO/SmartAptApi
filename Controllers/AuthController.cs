using Microsoft.AspNetCore.Mvc;
using SmartAptApi.Models;
using SmartAptApi.Services;

namespace SmartAptApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _authService.Authenticate(model.Email, model.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _authService.GenerateJwt(user);
            return Ok(new { user.Id, user.FullName, user.Email, token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var user = new User { FullName = model.FullName, Email = model.Email };
            await _authService.Register(user, model.Password);
            return Ok(new { message = "User registered successfully" });
        }
    }

    public class LoginRequest { public string Email { get; set; } = ""; public string Password { get; set; } = ""; }
    public class RegisterRequest { public string FullName { get; set; } = ""; public string Email { get; set; } = ""; public string Password { get; set; } = ""; }
}
