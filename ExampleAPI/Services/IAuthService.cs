namespace ExampleAPI.AuthService;

public interface IAuthService
{
    Task<string> Login(LoginUser user);
}