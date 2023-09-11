using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Shared;
using Portathon_Hackathon.Shared.Entities;
using Portathon_Hackathon.Shared.Model;

namespace Portathon_Hackathon.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IUserService _authService;
        public AuthController(IUserService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> CreateRegister(UserRegister user)
        {
            var result = await _authService.Register(new User
            {
                UserType = user.UserType.ToString(),
                Email = user.Email,
                Username = user.Username,

            }, user.Password);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin user)
        {
            var result = await _authService.Login(user.Email, user.Password);
            if (result == null)
            {
                return BadRequest("User is not found");
            }
            return Ok(result);
        }
    }
}
