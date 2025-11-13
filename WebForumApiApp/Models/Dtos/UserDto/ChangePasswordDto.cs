namespace WebForumApiApp.Models.Dtos.UserDto
{
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;
    }
}
