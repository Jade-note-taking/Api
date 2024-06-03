using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace JadeApi.Hubs;

[SignalRHub("/Hub/Folder")]
public class FoldersHub : Hub
{
    [SignalRMethod("Create")]
    public async Task Create(string folderName)
    {
        // Create folder and sent it with Folder.Create

        await Clients.All.SendAsync("Folder.Create");
    }

    [SignalRMethod("Delete")]
    public async Task Delete(string folderId)
    {
        // Perform check weather noteId belongs to the user
        // Check if folder is empty from notes
        // Perform deletion

        await Clients.All.SendAsync("Folder.Delete", folderId);
    }
}
