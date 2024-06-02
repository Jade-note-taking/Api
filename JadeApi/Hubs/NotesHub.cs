using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace JadeApi.Hubs;

[SignalRHub("/Hub/Notes")]
public class NotesHub : Hub
{
    [Authorize]
    [SignalRMethod("Create")]
    public async Task Create(string noteName, string startLocation)
    {
        // Create note and sent it with Notes.Create
        // Check weather startLocation is correct

        Console.WriteLine(noteName);
        Console.WriteLine(startLocation);
        // TODO: Make groups of client, you don't want to send e verywone a message
        await Clients.All.SendAsync("Notes.Create");
    }

    [Authorize]
    [SignalRMethod("Update")]
    public async Task Update(string noteId, string data)
    {
        // perform check weather noteId belongs to the user

        await Clients.All.SendAsync("Notes.Update", noteId, data);
        // TODO: In the future make it possible to sent not all the data but a partial data, reducing network overhead
    }

    [Authorize]
    [SignalRMethod("Move")]
    public async Task Move(string noteId, string newFolderId, string oldFolderId)
    {
        // Perform check weather noteId belongs to the user
        // Perform check on newFolderId and oldFolderId presence
        // Move in database

        await Clients.All.SendAsync("Notes.Move", noteId, newFolderId, oldFolderId);
    }

    [Authorize]
    [SignalRMethod("Delete")]
    public async Task Delete(string noteId)
    {
        // Perform check weather noteId belongs to the user
        // Remove note from database

        await Clients.All.SendAsync("Notes.Delete", noteId);
    }

    [Authorize]
    [SignalRMethod("Archive")]
    public async Task Archive(string noteId)
    {
        // Perform check weather noteId belongs to the user
        // Archive note

        await Clients.All.SendAsync("Notes.Archive", noteId);
    }
}
