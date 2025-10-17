# Restaurant Management (restaurant3)

A simple ASP.NET Core MVC restaurant management system scaffolded with Entity Framework Core and Identity. The app manages dishes (plats), ingredients, orders (commandes), sales (ventes), reservations, employees, and users.

## Features

- CRUD for Plats (dishes), Ingredients, Employees, Reservations, Commandes (orders), Ventes (sales).
- Many-to-many relationship between Plats and Ingredients (PlatsIngredients) with quantity required.
- Computed columns at the database level for line totals and final sale amounts.
- ASP.NET Core Identity for authentication (Razor Identity pages present in Areas/Identity).
- Entity Framework Core with SQL Server database (`bd_naami`).

## Tech stack

- .NET 8 (net8.0)
- ASP.NET Core MVC + Razor Pages
- Entity Framework Core (EF Core) 9
- Microsoft SQL Server
- ASP.NET Core Identity
- Bootstrap, jQuery for front-end scaffolding

## Repository structure (important parts)

- `Controllers/` - MVC controllers for domain entities (Commandes, Plats, Ingredients, Reservations, Ventes, Employes, etc.)
- `Models/` - EF Core DbContext (`BdNaamiContext`) and entity classes
- `Areas/Identity/` - Identity Razor Pages for authentication
- `Views/` - Razor views for the MVC controllers
- `wwwroot/` - static files (CSS, JS, libs)

## Prerequisites

- .NET SDK 8.0+ installed: https://dotnet.microsoft.com/en-us/download
- Microsoft SQL Server accessible (local or remote). The project uses a database named `bd_naami` by default.
- (Optional) Visual Studio 2022/2023 or Visual Studio Code for development.

## Configuration

Connection strings live in `appsettings.json`. Two keys are present:

- `ConnectionStrings:BdNaamiContextConnection`
- `ConnectionStrings:Restaurant3ContextConnection`

Example (already present):

```json
"ConnectionStrings": {
  "BdNaamiContextConnection": "Server=znaami;Database=bd_naami;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;",
  "Restaurant3ContextConnection": "Server=znaami;Database=bd_naami;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
}
```

Important: `Models/BdNaamiContext.cs` currently contains a scaffolded, hard-coded connection string in `OnConfiguring`. For security and portability, update the context to use configuration only (see Recommended changes below).

## Run locally (PowerShell)

Open PowerShell in the project root (`restaurant3`) and run:

```powershell
# restore and build
dotnet restore
dotnet build

# run app
dotnet run
```

If you get an error that `dotnet` is not recognized, install the .NET SDK first.

## Database migrations

If you need to create or update the database, use EF Core tools. From the project root:

```powershell
# install dotnet-ef tool if needed
dotnet tool install --global dotnet-ef

# apply migrations
dotnet ef database update
```

Note: The project already contains a `Migrations/` folder with at least one migration.

## Recommended changes / TODOs

- Remove the hard-coded connection string in `Models/BdNaamiContext.cs` and read from `IConfiguration` instead. This improves security and makes the app configurable per environment.
- Add a `README` section describing database seed data and how to create an admin account.
- Add role-based authorization for admin vs staff vs customer pages where appropriate.
- Add automated tests for core business logic (e.g., order totals, computed columns, reservation flows).

## Troubleshooting

- "dotnet not recognized": install the .NET SDK and reopen the terminal.
- DB connection errors: verify the server name, credentials, and that SQL Server allows connections from your machine. Adjust `appsettings.json` to match your environment.



