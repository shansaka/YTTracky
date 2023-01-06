using Microsoft.EntityFrameworkCore;

namespace YTTracky.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
