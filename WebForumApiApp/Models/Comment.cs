namespace WebForumApiApp.Models;

public class Comment
{
    public int Id { get; set; }
    
    public string Text { get; set;} = string.Empty;
    
    public string? PhotoPath { get; set; }
    
    public int AuthorId { get; set; }
    
    public int ThreadId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool IsDeleted { get; set; }
    
    // Навигация
    public User Author { get; set; } = null!;
    public Thread Thread { get; set; } = null!;
}