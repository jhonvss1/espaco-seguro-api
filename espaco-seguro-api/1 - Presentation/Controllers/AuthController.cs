using espaco_seguro_api._2___Application.Interfaces.Auth;
using espaco_seguro_api._2___Application.Request.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ILoginServiceApp loginServiceApp) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestVm loginRequest)
    {
        return Ok(await loginServiceApp.LoginAsync(loginRequest));
    }
    
}