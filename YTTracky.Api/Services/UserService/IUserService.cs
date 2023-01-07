using YTTracky.Api.Dtos;

namespace YTTracky.Api.Services.UserService
{
    public interface IUserService
    {
        Task<User?> AuthUserAsync(UserDto inputDto);
        Task<UserDto?> GetCurrentUser(HttpContext context);
    }
}
