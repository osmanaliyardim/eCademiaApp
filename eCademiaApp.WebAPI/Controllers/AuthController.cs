using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("isAuthenticated")]
        public ActionResult IsAuthenticated(string userMail, string requiredRoles)
        {
            var requiredRolesList = !string.IsNullOrEmpty(requiredRoles)
                ? requiredRoles.Split(',').ToList()
                : null;

            var result = _authService.IsAuthenticated(userMail, requiredRolesList);
            if (result.Success) return Ok(result);

            return Unauthorized(result.Message);
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success) return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                result.Message = userToLogin.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success) return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                result.Message = registerResult.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
