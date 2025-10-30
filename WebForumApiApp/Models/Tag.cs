namespace WebForumApiApp.Models;

public class Tag
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    // Навигация
    public ICollection<ThreadTag> ThreadTags { get; set; } = new List<ThreadTag>();
}