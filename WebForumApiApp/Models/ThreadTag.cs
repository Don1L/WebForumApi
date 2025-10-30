namespace WebForumApiApp.Models;

public class ThreadTag
{
    public int ThreadId { get; set; }
    
    public int TagId { get; set; }
    
    // Навигация
    public Thread Thread { get; set; } = null!;
    public Tag Tag { get; set; } = null!;

}