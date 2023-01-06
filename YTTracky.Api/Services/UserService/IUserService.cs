namespace YTTracky.Api.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
    }
}
