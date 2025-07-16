# 📦 Web API RESTful with ASP.NET Core.

This is a simple REST API project using .NET 8, Entity Framework Core, and SQL Server.

The solution is divided in two parts:

- 🛠️ Backend: API built with ASP.NET Core.

- 🗃️ Database: SQL scripts to create the database.

## 🚀 Technologies Used

- C# .NET 8 Web API

- Entity Framework Core

- SQL Server

- FluentValidation (optional)

### ✨ Features

This project includes two CRUD modules:

✅ Products

- Add, Edit, Logical Delete, List

- Validation using FluentValidation

- Partial Update with PATCH

- Uses DTOs for clean data transfer

🧪 Clients

- Basic CRUD (no validation)

- Physical delete using DELETE

### 📋 How to use this project?

1. **Create the Database**
   Open SQL Server and run this script:

```
USE master
CREATE DATABASE [pruebademo]
ON (
  NAME = 'pruebademo',
  FILENAME = 'D:\YOUR-FOLDER\pruebademo.mdf'
)
LOG ON (
  NAME = 'pruebademo_log',
  FILENAME = 'D:\YOUR-FOLDER\pruebademo.ldf'
);

```

📝 Replace YOUR-FOLDER with the folder path on your computer.

2. **Setup the Web API**
   Create a new ASP.NET Core Web API project in Visual Studio.
   Add these required packages:

✅ Required:

```
☑️ Microsoft.EntityFrameworkCore (8.0.4)
☑️ Microsoft.EntityFrameworkCore.SqlServer (8.0.4)
☑️ Microsoft.EntityFrameworkCore.Tools (8.0.4)

```

🧪 Optional (for validation):

```
☑️ FluentValidation.DependencyInjectionExtensions
☑️ Microsoft.AspNetCore.Authentication.JwtBearer (8.0.5)

```

3. **Run Migrations**
   To update the database, use the following commands in the Package Manager Console:

```
Add-Migration InitialCreate
Update-Database

```
