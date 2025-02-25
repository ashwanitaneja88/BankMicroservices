using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var loginResult = _jwtTokenService.GenerateAuthToken(loginModel);
            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}
