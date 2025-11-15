using System.ComponentModel.DataAnnotations;

namespace WebForumApiApp.Models.Dtos.UserDtos.Request;

public record LoginRequest(
    [Required][StringLength(50, MinimumLength = 3)]string Username,
    [Required][StringLength(100, MinimumLength = 8)]string Password
    );