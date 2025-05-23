# BSC Api

This project is a backend API built with .NET 8. It provides endpoints for your business logic and interacts with a SQL Server database.

## Getting Started

### Prerequisites

- .NET SDK 8.x installed
- SQL Server (or compatible database) running
- Your favorite IDE (Visual Studio, VS Code, Rider, etc.)

### Running the Project Locally

1. Clone the repository:

   ```bash
   git clone https://your-repo-url.git
   cd your-project-folder

Restore dependencies:

```sh
dotnet restore
```
## ⚠️ IMPORTANT

## Database Setup

### 1. Create Database

Run this command in your SQL Server or database client to create the database:

```sql
CREATE DATABASE YourDatabaseName;
GO
```

The application requires the following tables in the database:

- `cat_estatus_usuarios`
- `perfiles`
- `cat_estatus_pedidos`
- `categoria_productos`
- `productos`
- `persona`
- `clientes`
- `usuarios`
- `pedidos`
- `producto_pedido`

and the following views in the database:

- `VwGetUsers`
- `VwGetProducts`
- `VwGetClients`
- `VwGetOrders`

### Seed Data and Insertion Order

It's important to populate tables in the following order to maintain referential integrity:

1. cat_estatus_usuarios  
2. perfiles  
3. cat_estatus_pedidos  
4. categoria_productos  
5. productos  
6. persona
7. clientes  
8. usuarios


You can find SQL scripts for creating and seeding these tables in the `/database/scripts` folder.

Run them in the order above before starting the application.

## Database Connection

Set up your database connection string and other secrets in your environment-specific config files.

## Environment Variables

> Copy the `appsettings.Example.json` file as `appsettings.json` or `appsettings.Development.json` and complete the values:

| Variable                  | Description                                                   |
| ------------------------- | ------------------------------------------------------------- |
| `ConnectionStrings.DefaultConnection` | Database connection string (SQL Server or other DB).        |
| `JwtSettings.SecretKey`    | Secret key used for JWT token generation and validation.       |


Run the API:
```sh
    dotnet run
```