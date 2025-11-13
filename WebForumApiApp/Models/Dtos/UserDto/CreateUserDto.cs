namespace WebForumApiApp.Models.Dtos.UserDto
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
