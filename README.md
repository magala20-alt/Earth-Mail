# 📮 Earth Mail (Postal Management System)

A simple Postal Management System built with C#, using WinForms and Console UI, MVP design pattern, and EF Core Code-First for data access.

## 🛠️ Prerequisites
.NET 6 SDK or later
Visual Studio 2022 or later
SQL Server (Express, LocalDB, or full version)

## 📁 Project Structure
PostalManagementSystem/
│
├── Core/               #  Interfaces and Models (Domain Layer) +  EF Core setup (DbContext, Migrations, Repositories)

├── icons/              # WinForms icons used

├── Migrations/         # EF Core Migrations

├── Presentation/       # MVP Presenters, Views, and Interfaces

└── README.md                # Setup instructions

## 🚀 Getting Started

1.	Clone the Repository
   
git clone https://github.com/yourusername/PostalManagementSystem.git
cd PostalManagementSystem

2.	Update Connection String
Instead of using appsettings.json, the connection string is configured manually in code.

Go to:
Core/ApplicationDbContext.cs

Update the OnConfiguring method like so:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{

if (!optionsBuilder.IsConfigured)

{

// Example: local SQL Server - Replace with your own SQL Server credentials if needed.

optionsBuilder.UseSqlServer("Server=localhost;Database=PostalDb;Trusted_Connection=True;");

}

}

4.	Apply Migrations & Create Database

Run the following commands in the Package Manager Console:
powershell manager console

Navigate to the core project directory if needed

Add-Migration InitialCreate -Project Infrastructure

Update-Database -Project Infrastructure

This creates the Postage database using your defined models.

6.	Run the App
   
Choose one of the UIs depending on your use case:

✅ Console UI

cd ConsoleUI
dotnet run

✅ WinForms UI
Open the solution in Visual Studio and set WinFormsUI as the startup project. Press F5 to run.

## 💡 Features

Package tracking and invoicing

User-friendly interfaces: Console and WinForms

Search and filtering capabilities

MVP pattern for clean separation of concerns

EF Core Code-First with custom repositories

🧰 Technologies Used
C# .NET 6
WinForms
EF Core
MVP (Model-View-Presenter)
SQL Server
