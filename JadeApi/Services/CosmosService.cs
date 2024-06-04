using System.Drawing;
using Microsoft.Azure.Cosmos;

namespace JadeApi.Services;

public static class CosmosService
{
    public static Container GetContainer(this CosmosClient client)
    {
        return client.GetDatabase("Development").GetContainer("Notes");
    }

    public static async Task<T> ReadItem<T>(this CosmosClient client, string itemId)
    {
        return await client.GetContainer().ReadItemAsync<T>(itemId, new PartitionKey(itemId));
    }

    public static async Task<T> ReadItem<T>(this Container container, string itemId)
    {
        return await container.ReadItemAsync<T>(itemId, new PartitionKey(itemId));
    }
}
