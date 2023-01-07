using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YTTracky.Api.Dtos;

namespace YTTracky.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<User?> AuthUserAsync(UserDto inputDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == inputDto.Username && x.Password == inputDto.Password);
            return user;
        }

        public async Task<UserDto?> GetCurrentUser(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserDto
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value
                };
            }
            return null;
        }
    }
}
