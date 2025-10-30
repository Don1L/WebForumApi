namespace WebForumApiApp.Models;

public class Topic
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    // Навигация
    public ICollection<Thread> Threads { get; set; } = new List<Thread>();
}