namespace WebForumApiApp.Models;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    
    public string? PhotoPath { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
    
    //Навигация
    public ICollection<Thread> Threads { get; set; } = new List<Thread>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}