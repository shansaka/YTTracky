using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YTTracky.Api.Services.UserService;

namespace YTTracky.Api.Controllers
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
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetUsersAsync();
            return users;
        }

    }
}
