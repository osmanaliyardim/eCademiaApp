using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Injectable service
        private readonly IAuthService _authService;

        // Injecting our services to establish a loosely coupled connection
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>This method checks is user authenticated or not.</summary>
        /// <param name="userMail">user email</param>
        /// <param name="requiredRoles">required roles to access</param>
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

        /// <summary>This method lets user sign in.</summary>
        /// <param name="userForLoginDto">userForLoginDto object</param>
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

        /// <summary>This method lets user sign up.</summary>
        /// <param name="userForRegisterDto">UserForRegisterDto object</param>
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success) return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegisterDto);
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
