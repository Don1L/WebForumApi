namespace WebForumApiApp.DTO;

public class LoginResponseDto
{
    public string Token { get; set; }
    
    public string Username { get; set; }
    
    public int UsedId {get; set;}
}