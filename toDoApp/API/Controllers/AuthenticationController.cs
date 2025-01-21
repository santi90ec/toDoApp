using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly AuthenticationService _authService;
        public AuthenticationController(AuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("login")]

        public string Test()
        {
            return "Hola";
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] registerDTO registerUser)
        {
            var newUser = await _authService.RegisterNewUser(registerUser.email, registerUser.pass, registerUser.username);
            if (newUser == null)
            {
                return BadRequest("User Already exists");
            }

            return Ok(newUser);
        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("This route is protected!");
        }


    }
    public class registerDTO
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string username { get; set; }
    }
}
