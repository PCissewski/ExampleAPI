using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExampleAPI.AppSettings;
using ExampleAPI.AuthService;
using Microsoft.IdentityModel.Tokens;

namespace ExampleAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IAppSettings _appSettings;

    public AuthService(IUserService userService, IAppSettings appSettings)
    {
        _userService = userService;
        _appSettings = appSettings;
    }

    public async Task<string> Login(LoginUser user)
    {
        if (await _userService.VerifyUser(user))
        {
            return GenerateJwtToken();
        }

        return null;
    }

    private string GenerateJwtToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtSigningKey));
        var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:7087",
            audience: "https://localhost:7087",
            claims: new List<Claim>(),
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signInCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}