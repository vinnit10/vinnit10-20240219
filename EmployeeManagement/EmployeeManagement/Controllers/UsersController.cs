using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepositiry;

        public UsersController(IUserRepository userRepositiry)
        {
            _userRepositiry = userRepositiry;
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var newUser =  await _userRepositiry.CreateUserAsync(user);
            return Ok(newUser);
        }

        [HttpPut("users/{UserId:long}")]
        public async Task<IActionResult> UpdateUser(
        [FromRoute] long UserId, 
        [FromBody] UpdateUserViewModel updateUser)
        {
            var user = await _userRepositiry.UpdateUserAsync(updateUser, UserId);
            if (user == null)
                NotFound();

            return Ok(user);
        }

        [HttpGet("users/{Enabled:bool}")]
        public async Task<IActionResult> GetAllUsersAsync([FromRoute] bool Enabled)
        {
            var users = await _userRepositiry.GetUsersAsync(Enabled);

            return Ok(users);
        }
    }
}
