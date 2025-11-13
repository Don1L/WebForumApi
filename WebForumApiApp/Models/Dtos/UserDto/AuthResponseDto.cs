namespace WebForumApiApp.Models.Dtos.UserDto
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public UserDto User { get; set; } = new UserDto();
    }
}
