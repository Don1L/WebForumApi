using System.ComponentModel.DataAnnotations;

namespace WebForumApiApp.Models.Dtos.UserDtos.Response;

public record UserSummaryResponse(
    int Id,
    [Required]string Username,
    string? PhotoPath
    );