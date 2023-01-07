using System.ComponentModel.DataAnnotations;

namespace YTTracky.Api.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
