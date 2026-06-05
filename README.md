# 🛒 Online Shop — ASP.NET Core Web API & MVC

A full-featured **Online Shop** application built with **ASP.NET Core**, following a clean **N-Tier (3-Layer) Architecture**. The solution combines a **RESTful Web API** backend with an **ASP.NET Core MVC** frontend, providing both a consumer-facing web interface and a programmable API surface — all backed by **Entity Framework Core** for data access.

---

## 📌 Table of Contents

- [About the Project](#about-the-project)
- [Architecture Overview](#architecture-overview)
- [Solution Structure](#solution-structure)
- [Layer Responsibilities](#layer-responsibilities)
- [Entity Framework Core](#entity-framework-core)
- [Getting Started](#getting-started)
- [Technologies Used](#technologies-used)

---

## About the Project

This solution implements an online shopping platform that exposes its business logic through two entry points:

- **Web API** — for programmatic consumption (mobile apps, third-party integrations, etc.)
- **MVC UI** — a server-rendered web interface for end users

Both entry points share the same **Business Logic Layer (BLL)** and **Data Access Layer (DAL)**, ensuring a single source of truth, no code duplication, and consistent behavior across both interfaces.

---

## Architecture Overview

The project follows a strict **N-Tier (3-Layer) Architecture** pattern:

```
┌──────────────────────────────────────────────┐
│              Presentation Layer               │
│                                              │
│   Online_Shop_API.UI        Online_Shop_API.WebAPI  │
│   (ASP.NET Core MVC)        (ASP.NET Core API)      │
└────────────────────┬────────────────┬────────┘
                     │                │
                     ▼                ▼
┌──────────────────────────────────────────────┐
│           Business Logic Layer (BLL)          │
│            Online_Shop_API.BLL                │
│   Services, DTOs, Interfaces, Validations    │
└────────────────────────┬─────────────────────┘
                         │
                         ▼
┌──────────────────────────────────────────────┐
│          Data Access Layer (DAL)              │
│            Online_Shop_API.DAL                │
│   DbContext, Entities, Repositories, Migrations│
└──────────────────────────────────────────────┘
```

---

## Solution Structure

```
Solution1.sln
│
├── Online_Shop_API.DAL/            # Data Access Layer
│   ├── Context/                    # EF Core DbContext
│   ├── Entities/                   # Domain model classes (e.g. Product, Order, User)
│   ├── Repositories/               # Repository interfaces and implementations
│   └── Migrations/                 # EF Core database migrations
│
├── Online_Shop_API.BLL/            # Business Logic Layer
│   ├── Services/                   # Business service classes
│   ├── Interfaces/                 # Service interfaces (for DI)
│   ├── DTOs/                       # Data Transfer Objects
│   └── Mappings/                   # AutoMapper profiles (entity ↔ DTO)
│
├── Online_Shop_API.UI/             # MVC Frontend (Presentation Layer)
│   ├── Controllers/                # MVC Controllers (renders Views)
│   ├── Views/                      # Razor .cshtml pages
│   ├── wwwroot/                    # Static files (CSS, JS, images)
│   └── Program.cs / appsettings.json
│
└── Online_Shop_API.WebAPI/         # REST API (Presentation Layer)
    ├── Controllers/                # API Controllers (returns JSON)
    ├── Program.cs                  # App entry point & middleware pipeline
    └── appsettings.json            # Configuration (connection string, JWT, etc.)
```

---

## Layer Responsibilities

### `Online_Shop_API.DAL` — Data Access Layer

Handles all communication with the database. Nothing outside this layer talks directly to the database.

| Component | Purpose |
|-----------|---------|
| `DbContext` | EF Core database context; registers all `DbSet<T>` entities |
| `Entities` | Plain C# classes that map to database tables |
| `Repositories` | Abstracts CRUD operations; implements the Repository Pattern |
| `Migrations` | Auto-generated EF Core migration history |

### `Online_Shop_API.BLL` — Business Logic Layer

The core of the application. Contains all business rules, validations, and orchestration logic. The BLL only depends on the DAL; it has **no knowledge** of HTTP or UI concerns.

| Component | Purpose |
|-----------|---------|
| `Services` | Implements business operations (e.g. `ProductService`, `OrderService`) |
| `Interfaces` | Contracts for services, enabling Dependency Injection and testability |
| `DTOs` | Shapes data flowing between layers (avoids exposing raw entities) |
| `Mappings` | Configures AutoMapper to convert entities to DTOs and vice versa |

### `Online_Shop_API.UI` — MVC Frontend

An ASP.NET Core MVC application that consumes the BLL services directly. Renders server-side HTML for end users via Razor views.

| Component | Purpose |
|-----------|---------|
| `Controllers` | Handle HTTP requests, call BLL services, pass models to views |
| `Views` | Razor templates for rendering HTML pages |
| `wwwroot` | Static assets served directly to the browser |

### `Online_Shop_API.WebAPI` — REST Web API

An ASP.NET Core Web API application that also consumes the BLL. Returns JSON responses consumed by external clients, mobile apps, or front-end frameworks.

| Component | Purpose |
|-----------|---------|
| `Controllers` | API endpoints decorated with `[ApiController]` and `[Route]` |
| `Program.cs` | Configures services, middleware, Swagger, CORS, authentication |

---

## Entity Framework Core

### ORM & Approach

This project uses **Entity Framework Core** (Code-First approach). The database schema is defined in C# entity classes inside the DAL, and EF Core generates and manages the database through **migrations**.

### Key EF Core Packages (DAL Project)

| Package | Purpose |
|---------|---------|
| `Microsoft.EntityFrameworkCore` | Core EF library — DbContext, DbSet, LINQ queries |
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Server database provider |
| `Microsoft.EntityFrameworkCore.Tools` | Enables `Add-Migration`, `Update-Database` CLI commands |
| `Microsoft.EntityFrameworkCore.Design` | Required at design-time for scaffolding and migrations |

### Common EF Core Commands

```bash
# Create a new migration
Add-Migration InitialCreate

# Apply pending migrations to the database
Update-Database

# Revert the last migration
Remove-Migration

# Generate SQL script for migrations
Script-Migration
```

### DbContext Registration (DAL → WebAPI / UI)

```csharp
// In Program.cs of both UI and WebAPI projects
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or remote)
- Visual Studio 2022 (or VS Code with C# extension)

### Setup Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/seljanzeynalovacode/OnlineShopping_API_MVC.git
   cd online-shop
   ```

2. **Configure the connection string** in `appsettings.json` of both `UI` and `WebAPI` projects:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=OnlineShopDB;Trusted_Connection=True;"
   }
   ```

3. **Apply EF Core migrations** (run from Package Manager Console with DAL as default project):
   ```bash
   Update-Database
   ```

4. **Run the projects**
   - Set multiple startup projects in Visual Studio: `Online_Shop_API.UI` + `Online_Shop_API.WebAPI`
   - Or run individually via CLI:
     ```bash
     dotnet run --project Online_Shop_API.WebAPI
     dotnet run --project Online_Shop_API.UI
     ```

5. **Explore the API** via Swagger UI at `https://localhost:{port}/swagger`

---

## Technologies Used

| Technology | Role |
|-----------|------|
| ASP.NET Core 8 | Web framework (MVC + Web API) |
| Entity Framework Core | ORM / Data Access |
| SQL Server | Relational database |
| AutoMapper | Object-to-object mapping (Entity ↔ DTO) |
| Swagger / Swashbuckle | API documentation & testing UI |
| Dependency Injection | Built-in .NET DI container |
| Repository Pattern | Abstraction over data access |
| N-Tier Architecture | Separation of concerns across DAL / BLL / UI+API |

---

## Project Dependencies

```
Online_Shop_API.UI      →  Online_Shop_API.BLL
Online_Shop_API.WebAPI  →  Online_Shop_API.BLL
Online_Shop_API.BLL     →  Online_Shop_API.DAL
Online_Shop_API.DAL     →  (no internal project dependency)
```

Each layer only knows about the layer directly below it. The UI and API layers are completely independent of each other — they share only the BLL.

