using AdnacedAuthTips.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdnacedAuthTips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var login = await _authService.Login(dto);
            if (login == false)
            {
                return BadRequest("Wrogn Password or email");
            }
            return Ok("Welcome back boss");
        }


        [HttpPost("Register")]
        public async Task<IActionResult> SignUp(RegisterDTO dto)
        {
            var RegisterSucces = await _authService.SignUp(dto);
            if (RegisterSucces == false)
            {
                return BadRequest("There is a problem please try again");
            }
            return Ok("Your account has been registered succefully congrsts for entering out community");
        }
    }
}
