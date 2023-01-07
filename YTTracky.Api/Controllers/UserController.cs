using Microsoft.AspNetCore.Authorization;
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
            _userService= userService;  
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetUserAsync()
        {
            var userCliam = await _userService.GetCurrentUser(HttpContext);
          if (userCliam == null)
            {
                return NotFound();
            }
          return Ok(userCliam);
        }
    }
}
