using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Model;

[PrimaryKey("UserId")]
public class User
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public int UserId { get; private set; }
    
    public string UserName { get; private set; }
    public string Password { get; private set; }
}