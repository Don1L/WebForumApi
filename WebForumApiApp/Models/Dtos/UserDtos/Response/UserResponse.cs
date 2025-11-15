using System.ComponentModel.DataAnnotations;

namespace WebForumApiApp.Models.Dtos.UserDtos.Response;

public record UserResponse(
    int Id,
    [Required] string Username,
    [EmailAddress]  string Email,
    DateTime CreatedAt,
    string? PhotoPath,
    bool IsDeleted,
    int ThreadCount,
    int CommentCount
    );