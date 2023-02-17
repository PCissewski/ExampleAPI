using ExampleAPI.Context;
using ExampleAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Services;

public class UserService : IUserService
{
    private readonly PlanetarySystemDbContext _context;

    public UserService(PlanetarySystemDbContext context)
    {
        _context = context;
    }

    public async Task<bool> VerifyUser(LoginUser loginUser)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x =>
            x.UserName == loginUser.UserName);

        if (user == null)
        {
            return false;
        }
        
        return new PasswordHasher<User>()
            .VerifyHashedPassword(null, user.Password, loginUser.Password) == PasswordVerificationResult.Success;
    }
}