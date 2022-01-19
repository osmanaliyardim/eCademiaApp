using Core.Entities.Concrete;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCademiaApp.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Injectable service
        private readonly IUserService _userService;

        // Injecting our services to establish a loosely coupled connection
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>This method returns a specific user by id.</summary>
        /// <param name="id">user id</param>
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method returns all users.</summary>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method returns a specific user by email.</summary>
        /// <param name="userMail">user email</param>
        [HttpGet("getUserDetailByMail")]
        public IActionResult GetUserDetailByMail(string userMail)
        {
            var result = _userService.GetUserDetailByMail(userMail);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method updates a specific user from DB.</summary>
        /// <param name="user">user object</param>
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method updates a specific userDetailForUpdate.</summary>
        /// <param name="UserDetailForUpdateDto">userDetailForUpdate object</param>
        [HttpPost("updateUserDetails")]
        public IActionResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var result = _userService.UpdateUserDetails(userDetailForUpdate);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        /// <summary>This method removes a specific user from DB.</summary>
        /// <param name="user">user object</param>
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
