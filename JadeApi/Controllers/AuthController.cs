using Microsoft.AspNetCore.Mvc;

namespace JadeApi.Controllers;

[Route("Auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("Connect")]
    public async Task<ActionResult> Connect()
    {
        return Ok("connect");
    }
}