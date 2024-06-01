using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JadeApi.Controllers;

[Route("Notes")]
[ApiController]
public class NotesController : Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult All()
    {
        return Ok("All Notes");
    }
}
