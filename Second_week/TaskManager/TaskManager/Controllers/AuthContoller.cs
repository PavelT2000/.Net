using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Пример проверки пользователя (замените на вашу проверку)
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = TokenService.GenerateToken("1", "admin");
                return Ok(new { token });
            }

            return Unauthorized();
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }




    }
}
