using LAPUsersAPI.Interfaces;
using LAPUsersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAPUsersAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("add-user")]
        public async Task<ActionResult<UserModel>> AddUserAsync([FromBody] UserModel user)
        {
            var created = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserModel user)
        {
            var updated = await _userService.UpdateUserAsync(id, user);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("bulk-delete")]
        public async Task<IActionResult> DeleteUsers([FromBody] List<int> ids)
        {
            var success = await _userService.DeleteUsersAsync(ids);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
