using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using JadeApi.Data;
using JadeApi.Entities;
using JadeApi.Helpers;
using JadeApi.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using SignalRSwaggerGen.Attributes;

namespace JadeApi.Hubs;

[SignalRHub("/Hub/Note")]
public class NotesHub(JadeDbContext context, CosmosClient cosmosClient) : Hub
{
    private readonly JadeDbContext _context = context;
    private readonly CosmosClient _cosmosClient = cosmosClient;

    private string Md5Hash(string input) => MD5.HashData(Encoding.UTF8.GetBytes(input)).ToHex();
    private string Md5Hash(byte[] input) => MD5.HashData(input).ToHex();
    private string? GetUserIdentifier() => Context.UserIdentifier?.Split("|").Last();

    private async Task<string?> GetUserId()
    {
        var userId = GetUserIdentifier();
        if (userId == null) return null;
        await Groups.AddToGroupAsync(Context.ConnectionId, $"user.{userId}");

        return userId;
    }

    private async Task SentToUser(string method, object? arg1=null)
    {
        var userId = GetUserIdentifier();
        if (userId == null) return;

        await Clients.Group($"user.{userId}").SendAsync(method, arg1);
        // await Clients.All.SendAsync(method, arg1);
    }

    private async Task SentToUser(string method, object? arg1=null, object? arg2=null)
    {
        var userId = GetUserIdentifier();
        if (userId == null) return;

        await Clients.Group($"user.{userId}").SendAsync(method, arg1, arg2);
        // await Clients.All.SendAsync(method, arg1, arg2);
    }

    // Adding the user to its group
    [SignalRMethod("Init")]
    public async Task Init()
    {
        await GetUserId();
    }

    [SignalRMethod("Create")]
    public async Task Create(string noteName, string noteLocation, string noteContent)
    {
        var userId = await GetUserId();
        if (userId == null) return;

        var theNoteId = Md5Hash(Guid.NewGuid().ToByteArray());
        var cosmosId = Md5Hash($"{userId}{theNoteId}");

        // Persisting sql note
        var sqlNote = new Note
        {
            Id = theNoteId,
            UserId = userId,
            Name = noteName,
            Location = noteLocation,
            CosmosId = cosmosId
        };
        _context.Notes.Add(sqlNote);
        await _context.SaveChangesAsync();

        // Persisting nosql note
        var cosmosNote = new CosmosNote(cosmosId, noteContent ?? "");
        await _cosmosClient.GetContainer().CreateItemAsync(cosmosNote);

        await SentToUser("Note.Create", sqlNote);
    }

    [SignalRMethod("UpdateContent")]
    public async Task UpdateContent(string noteId, string content)
    {
        var userId = await GetUserId();
        var cosmosId = Md5Hash($"{userId}{noteId}");

        // TODO: Make it possible to sent not all the content but a partial content, reducing network overhead
        await _cosmosClient.GetContainer().UpsertItemAsync(new CosmosNote(cosmosId, content));

        await SentToUser($"Note.UpdateContent.{cosmosId}", content);
    }

    [SignalRMethod("Update")]
    public async Task Update(string noteId, string name, string location)
    {
        var userId = await GetUserId();
        var cosmosId = Md5Hash($"{userId}{noteId}");
        var existingNote = await _context.Notes.FindAsync(noteId);
        if (existingNote != null)
        {
            existingNote.Name = name;
            existingNote.Location = location;
            await _context.SaveChangesAsync();
            await SentToUser($"Note.Update.{cosmosId}", name, location);
        }
    }

    [SignalRMethod("Delete")]
    public async Task Delete(string noteId)
    {
        var userId = await GetUserId();
        var cosmosId = Md5Hash($"{userId}{noteId}");

        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Id == noteId);
        var note = await query.FirstAsync();
        _context.Remove(note);
        await _context.SaveChangesAsync();

        await _cosmosClient.DeleteItem<CosmosNote>(cosmosId);

        await SentToUser("Note.Delete", noteId);
    }

    [SignalRMethod("Archive")]
    public async Task Archive(string noteId)
    {
        var userId = await GetUserId();

        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Id == noteId);
        var note = await query.FirstAsync();
        note.Archive = true;
        await _context.SaveChangesAsync();

        await SentToUser("Note.Archive", note);
    }

    [SignalRMethod("Inbox")]
    public async Task Inbox(string noteId)
    {
        var userId = await GetUserId();

        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Id == noteId);
        var note = await query.FirstAsync();
        note.Archive = false;
        await _context.SaveChangesAsync();

        await SentToUser("Note.Inbox", note);
    }
}
