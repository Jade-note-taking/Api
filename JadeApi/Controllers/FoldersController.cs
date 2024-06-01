using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JadeApi.Controllers;

[Route("Folders")]
[ApiController]
public class FoldersController : Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult All()
    {
        return Ok("All Folders");
    }
}
