1. If you don't have EF Tools installed, run the following command from the powershell
dotnet tool install --global dotnet-ef --version 9.0.11

2. I used MS SQL with built-in user credentials. To create the database:
dotnet ef database update --project Management.System.Infrastructure --startup-project Management.System.WebApi

Once you run the solution, it will automatically open the documentation page at /docs (Swagger).
The project is configured to run on both Windows and Linux. It includes three appsettings.json files to provide flexibility for development, staging, and production environments.
