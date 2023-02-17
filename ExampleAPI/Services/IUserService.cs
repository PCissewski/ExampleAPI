namespace ExampleAPI.Services;

public interface IUserService
{
    Task<bool> VerifyUser(LoginUser loginUser);
}