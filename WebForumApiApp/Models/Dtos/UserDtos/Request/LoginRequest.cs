using System.ComponentModel.DataAnnotations;

namespace WebForumApiApp.Models.Dtos.UserDtos.Request;

public record LoginRequest(
    [Required]string Username,
    [Required]string Password
    );