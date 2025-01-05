using LibraryManagement.Dtos.Requests;
using LibraryManagement.Dtos.Responses;
using LibraryManagement.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.CreateUserAsync(dto);

            return result.StatusCode switch
            {
                0 => BadRequest(result.Message),
                1 => BadRequest(result.Message),
                2 => BadRequest(result.Message),
                3 => StatusCode(200, new { result.Message }),
                4 => StatusCode(418, result.Message),
                5 => StatusCode(418, result.Message),
                8 => BadRequest(result.Message),
                _ => StatusCode(500, "An unexpected error occurred.")
            };
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);

            if (user != null && !string.IsNullOrEmpty(user.SessionToken))
            {
                Response.Headers.Add("Set-Cookie", $"session={user.SessionToken}; HttpOnly; Path=/;");

                return Ok(new LoggedinDto
                {
                    Email = user.Email,
                    Username = user.Username,
                    Token = user.SessionToken
                });
            }

            return Unauthorized();
        }
    }
}
