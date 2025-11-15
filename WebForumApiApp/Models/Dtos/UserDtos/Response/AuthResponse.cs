using System.ComponentModel.DataAnnotations;

namespace WebForumApiApp.Models.Dtos.UserDtos.Response;

public record AuthResponse(
    [Required] string Token,
    UserResponse User,
    DateTime ExpiresAt
    );