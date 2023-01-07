using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YTTracky.Api.Common;
using YTTracky.Api.Dtos;
using YTTracky.Api.Services.UserService;

namespace YTTracky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] UserDto userLogin)
        {
            var response = new BaseResponse<AuthDto>();
            var user = await _userService.AuthUserAsync(userLogin);
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                        new Claim(ClaimTypes.NameIdentifier, user.Username),
                        //new Claim(ClaimTypes.Email, user.EmailAddress),
                        //new Claim(ClaimTypes.GivenName, user.GivenName),
                        //new Claim(ClaimTypes.Surname, user.Surname),
                        //new Claim(ClaimTypes.Role, user.Role)
                    };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(15),
                  signingCredentials: credentials);

                
                response.Data = new AuthDto(new JwtSecurityTokenHandler().WriteToken(token)); 
                return Ok(response);
            }

            response.IsSuccess = false;
            response.Error = "User not found";
            return NotFound(response);
        }
    }
}
