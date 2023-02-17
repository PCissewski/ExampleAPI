using ExampleAPI.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<string>> Login([FromBody]LoginUser? user)
    {
        if (user == null)
        {
            return BadRequest("Incorrect user credentials");    
        }

        var token = await _authService.Login(user);

        if (token == null)
        {
            return Unauthorized("Unauthorized user");
        }
        
        return Ok(token);
    }
}