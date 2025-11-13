namespace WebForumApiApp.Models.Dtos.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

    }
}
