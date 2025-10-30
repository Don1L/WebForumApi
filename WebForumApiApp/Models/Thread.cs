namespace WebForumApiApp.Models;

public class Thread
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Text { get; set; } = string.Empty;
    
    public string? PhotoPath { get; set; }
    
    public int AuthorId { get; set; }
    
    public int TopicId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public bool IsDeleted { get; set; }

    public bool IsHidden { get; set; }
    
    // Навигация
    public User Author { get; set; } = null!;
    public Topic Topic { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<ThreadTag> ThreadTags { get; set; } = new List<ThreadTag>();
}