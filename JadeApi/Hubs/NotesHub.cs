using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using JadeApi.Data;
using JadeApi.Entities;
using JadeApi.Helpers;
using JadeApi.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Cosmos;
using SignalRSwaggerGen.Attributes;

namespace JadeApi.Hubs;

[SignalRHub("/Hub/Note")]
public class NotesHub(JadeDbContext context, CosmosClient cosmosClient) : Hub
{
    private readonly JadeDbContext _context = context;
    private readonly CosmosClient _cosmosClient = cosmosClient;

    // public override async Task OnConnectedAsync()
    // {
    //     var user = Context.User;
    //     // Access user information (e.g., user.Claims) to get Auth0 user details
    //     // Perform actions based on user identity
    //     await base.OnConnectedAsync();
    // }

    [SignalRMethod("Create")]
    public async Task Create()
    {
        // Create note and sent it with Note.Create
        // Check weather startLocation is correct

        // var userId = Context.User.Claims.GetUserId();
        var userId = "107707286267679057274";
        var theNoteId = MD5.HashData(Guid.NewGuid().ToByteArray()).ToHex();
        var cosmosId = MD5.HashData(Encoding.UTF8.GetBytes($"{userId}{theNoteId}")).ToHex();

        var SqlNote = new Note
        {
            Id = theNoteId,
            UserId = userId,
            Name = "TEST NAME OF NOTE",
            Location = null,
            CosmosId = cosmosId
        };

        _context.Notes.Add(SqlNote);
        await _context.SaveChangesAsync();

        var cosmosNote = new CosmosNote(cosmosId, "THE CONTENT OF THE NOTE HERE HELLO YEARH BOYYY");

        await _cosmosClient.GetContainer().CreateItemAsync(cosmosNote);

        // TODO: Make groups of client, you don't want to send e verywone a message
        await Clients.Client(userId).SendAsync("Note.Create");
    }

    [SignalRMethod("UpdateContent")]
    public async Task UpdateContent(string cosmosId, string content)
    {
        // perform check weather cosmosId belongs to the user

        // TODO: In the future make it possible to sent not all the content but a partial content, reducing network overhead
        await _cosmosClient.GetContainer().UpsertItemAsync(new CosmosNote(cosmosId, content));

        await Clients.All.SendAsync($"Note.UpdateContent.{cosmosId}", content);
    }

    [SignalRMethod("Update")]
    public async Task Update(string noteId, string name, string location)
    {
        // perform check weather cosmosId belongs to the user

        var existingNote = await _context.Notes.FindAsync(noteId);
        if (existingNote != null)
        {
            existingNote.Name = name;
            existingNote.Location = location;
            await _context.SaveChangesAsync();
        }

        // await Clients.All.SendAsync("Note.Update", existingNote.CosmosId, existingNote);
    }

    [SignalRMethod("Move")]
    public async Task Move(string cosmosId, string newFolderId, string oldFolderId)
    {
        // Perform check weather cosmosId belongs to the user
        // Perform check on newFolderId and oldFolderId presence
        // Move in database

        await Clients.All.SendAsync("Note.Move", cosmosId, newFolderId, oldFolderId);
    }

    [SignalRMethod("Delete")]
    public async Task Delete(string cosmosId)
    {
        // Perform check weather cosmosId belongs to the user
        // Remove note from database

        await Clients.All.SendAsync("Note.Delete", cosmosId);
    }

    [SignalRMethod("Archive")]
    public async Task Archive(string cosmosId)
    {
        // Perform check weather cosmosId belongs to the user
        // Archive note

        await Clients.All.SendAsync("Note.Archive", cosmosId);
    }
}
