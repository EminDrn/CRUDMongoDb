using CRUDMongoDb.Models;
using CRUDMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace CRUDMongoDb.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{userId:length(24)}")]
        public async Task<ActionResult<User>> Get(string userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(Get), new { userId = user.Id }, user);
        }

        [HttpPut("{userId:length(24)}")]
        public async Task<IActionResult> Update(string userId, User user)
        {
            var existingUser = await _userService.GetByIdAsync(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.Id = existingUser.Id;
            await _userService.UpdateAsync(userId, user);
            return Ok();
        }

        [HttpDelete("{userId:length(24)}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var userDetails = await _userService.GetByIdAsync(userId);
            if (userDetails == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}
