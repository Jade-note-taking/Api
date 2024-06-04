# Jade API
Jade API is responsible for syncing all devices logged into account together by managing two databases, azuresql and a cosmosdb (nosql).
Jade API is the layer in between MAUI application and the two databases.

## Migrations
To create new migration run:
```shell
dotnet ef migrations add <come up with a migration name like initalmigrations or adding_x_table>
# or
dotnet-ef migrations add <come up with a migration name like initalmigrations or adding_x_table>
```
To undo last migration run:
```shell 
dotnet ef migrations remove
```
To migrate run the following:
```shell
dotnet ef database update
```
.NET entity framework docs: https://learn.microsoft.com/en-gb/ef/core/


## Cosmos DB configuration
1. [Install azd](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/install-azd?tabs=winget-windows%2Cbrew-mac%2Cscript-linux&pivots=os-windows) and login to your azure account with `azd auth login` and then(maybe) `azd up`
   2. azd init
   3. azd auth login
   4. azd up
2. Add environment variables in terminal see [this](https://stackoverflow.com/questions/62817337/azure-keyvault-azure-identity-credentialunavailableexception-defaultazurecrede) stackoverflow post

## FAQ

### Why two databases?
The reason for having two complete different databases is ment to increase syncing performance while user is editing his notes. When user edit a certain note, api only makes connection with cosmos db and makes the adjustment; since cosmos is nosql, it's generally faster for editing and reading, inturn making the editing process more effective.
