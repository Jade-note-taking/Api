using JadeApi.Entities;
using JadeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace JadeApi.Controllers;

[Route("Notes")]
[ApiController]
public class NotesController(CosmosClient cosmosClient) : Controller
{
    private readonly CosmosClient _cosmosClient = cosmosClient;

    [Authorize]
    [HttpGet("{noteId}")]
    public async Task<ActionResult> All(string noteId)
    {
        // var cosmosNote = new CosmosNote(DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), "userid here", "some content here as well");
        // await container.CreateItemAsync(cosmosNote);

        try
        {
            var note = await _cosmosClient.GetContainer().ReadItem<CosmosNote>(noteId);
            return Ok(note);
        }
        catch
        {
            return NotFound();
        }
    }
}
