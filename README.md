# Restaurant Management System

A full-stack restaurant management web application built with C#, ASP.NET Core MVC, Entity Framework Core, and Microsoft SQL Server.

The application is designed to centralize restaurant operations, including menu management, ingredients, orders, reservations, sales, and employee records.

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-Core-68217A?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

## Overview

Restaurant Management System is a web application developed to demonstrate full-stack development with the .NET ecosystem.

It follows the Model-View-Controller (MVC) pattern and uses Entity Framework Core to manage relational data stored in Microsoft SQL Server. The project brings together several restaurant-related operations in one application while emphasizing data relationships, database schema management, and maintainable application structure.

## Features

- **Menu management:** Manage restaurant dishes and their associated ingredients.
- **Ingredient management:** Organize ingredients and their relationships with menu items.
- **Order management:** Support restaurant order-related operations.
- **Reservation management:** Manage reservation records.
- **Sales management:** Maintain sales-related records and amounts.
- **Employee management:** Organize employee information.
- **Relational data modeling:** Represent relationships between dishes and ingredients, including ingredient quantities.
- **Database migrations:** Manage schema changes through Entity Framework Core migrations.
- **Authentication:** Integrate ASP.NET Core Identity for account management.

The availability and completeness of individual workflows depend on the current implementation.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| .NET 8 | Application runtime and platform |
| ASP.NET Core MVC | Web application architecture |
| Entity Framework Core | Object-relational mapping and database access |
| Microsoft SQL Server | Relational database |
| ASP.NET Core Identity | Authentication and account management |
| Razor Views | Server-rendered user interface |
| Bootstrap | Responsive UI styling |
| jQuery | Client-side interactions |
| EF Core Migrations | Database schema evolution |

## Architecture

The application follows the MVC architectural pattern.

```text
Browser
   |
   v
ASP.NET Core MVC
   |
   +------ Controllers
   |           |
   |           v
   |       Models / Domain Logic
   |           |
   v           v
Razor Views  Entity Framework Core
                 |
                 v
          SQL Server Database
```

### Main components

- **Models:** Represent restaurant entities and database context.
- **Controllers:** Handle incoming requests and coordinate application operations.
- **Views:** Render the user interface using Razor.
- **Entity Framework Core:** Maps application entities to relational database structures.
- **Migrations:** Track and apply database schema changes.
- **ASP.NET Core Identity:** Provides authentication-related functionality.

## Data Modeling

The project includes a relational model for managing restaurant data.

One of its important design elements is the relationship between dishes and ingredients. A dedicated junction entity can represent the many-to-many relationship while storing additional information, such as the quantity of an ingredient used in a dish.

The database model also includes calculated values for certain order and sales totals, where configured in the database schema.

These design choices help demonstrate relational modeling, data integrity, and the use of an ORM in a business-oriented application.

## Getting Started

### Prerequisites

- .NET 8 SDK.
- Microsoft SQL Server.
- Git.
- Visual Studio or Visual Studio Code with the appropriate .NET tooling.

### 1. Clone the repository

```bash
git clone https://github.com/ELGHAD/Restaurant_Management.git
cd Restaurant_Management
```

### 2. Configure the database connection

Configure the connection string in `appsettings.json` or through the application's configuration system.

Example:

```json
{
  "ConnectionStrings": {
    "BdNaamiContextConnection": "Server=YOUR_SERVER;Database=bd_naami;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Use the connection-string key expected by the application's actual `DbContext` configuration. Additional configuration may be required depending on the existing project setup.

**Security note:** Do not commit credentials or production connection strings. Use environment variables, .NET User Secrets during local development, or an appropriate secrets manager.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Build the application

```bash
dotnet build
```

### 5. Apply database migrations

If the project has migrations and the Entity Framework tooling is configured, install the EF Core command-line tool if needed:

```bash
dotnet tool install --global dotnet-ef
```

Then apply the migrations:

```bash
dotnet ef database update
```

If the project uses a separate startup project or a non-default `DbContext`, specify the appropriate options for your repository configuration.

### 6. Run the application

```bash
dotnet run
```

Open the local URL displayed in the terminal.

## Project Structure

```text
Restaurant_Management/
├── Areas/
│   └── Identity/       # Identity-related Razor Pages
├── Controllers/        # MVC request handlers
├── Models/             # Domain models and database context
├── Migrations/         # EF Core database migrations
├── Views/              # Razor views
├── wwwroot/            # Static assets and frontend libraries
├── Program.cs          # Application entry point
├── appsettings.json    # Application configuration
└── restaurant3.csproj  # .NET project definition
```

## Security and Reliability

The project incorporates several relevant .NET development concepts:

- Authentication functionality through ASP.NET Core Identity.
- ORM-based database access with Entity Framework Core.
- Relational database constraints and schema management.
- Database-level calculated values where configured.

### Current improvement areas

The following areas should be addressed before treating the application as production-ready:

- Move connection strings out of source-controlled configuration and remove hard-coded credentials.
- Implement and verify role-based authorization for administrative and staff operations.
- Add automated tests for critical business workflows and data integrity.
- Validate input and handle application errors consistently.
- Review authentication configuration and authorization rules for every protected operation.

Authentication and authorization are distinct: signing in a user does not automatically enforce role-specific permissions.

## Future Improvements

- Complete role-based access control for restaurant staff and administrators.
- Expand automated unit and integration test coverage.
- Improve validation and centralized error handling.
- Add reporting and dashboard capabilities for restaurant operations.
- Improve deployment configuration and environment management.
- Introduce a documented, repeatable deployment process.

## Author

**ELGHAD**

- GitHub: https://github.com/ELGHAD
- Portfolio: https://elghad.github.io/hamza-elrhadiouini-portfolio

