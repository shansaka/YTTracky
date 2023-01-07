namespace YTTracky.Api.Dtos
{
    public class AuthDto
    {
        public AuthDto(string? token)
        {
            Token = token;
        }

        public string? Token { get; set; }
    }
}
