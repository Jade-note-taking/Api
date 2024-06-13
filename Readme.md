# Jade API
Jade API is responsible for syncing all devices logged into account together by managing two databases, azuresql and a cosmosdb (nosql).
Jade API is the layer in between MAUI application and the two databases.

## 1. Local development

### 1.1 Configuration
Make a copy of `appsettings.Sample.json` with the name `appsettings.json` and fill out all the fields correctly.

### 1.2 Migrations
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

### 1.3 Run Api
You can run the api with rider play button top right. If you have `dotnet` installed, you can run `dotnet watch` (in solution folder) to start dotnet watcher.


## Deploying to azure
Make sure you have [azd installed](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/install-azd?tabs=winget-windows%2Cbrew-mac%2Cscript-linux&pivots=os-windows). 
Make sure you are logged in with azd command line tool, if you aren't logged in you can achieve that by executing `azd auth login`. 

Make sure you are in the JadeApi solution, after that you can run `azd up`. With that command your project docker container will be deployed to azure and then hosted.

## FAQ

### Why two databases?
The reason for having two complete different databases is ment to increase syncing performance while user is editing his notes. When user edit a certain note, api only makes connection with cosmos db and makes the adjustment; since cosmos is nosql, it's generally faster for editing and reading, inturn making the editing process more effective.
