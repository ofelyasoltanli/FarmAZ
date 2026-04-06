# 🌱 FarmAZ API

A RESTful backend API built with ASP.NET Core (.NET 10) as a C# learning project.
FarmAZ is a farm marketplace where farmers can list products and customers can place orders.

## 🚀 Features
- JWT Authentication (Register/Login)
- Product management (CRUD)
- Order management
- BCrypt password hashing
- SQL Server with Entity Framework Core
- Docker support

## 🔧 Tech Stack
- ASP.NET Core (.NET 10)
- Entity Framework Core
- SQL Server (Docker)
- JWT Bearer Authentication
- BCrypt.Net
- Swagger UI

## ⚙️ Getting Started

### Prerequisites
- .NET 10 SDK
- Docker Desktop

### Run the project

1. Clone the repository
   git clone https://github.com/YOUR_USERNAME/FarmAZ.git
   cd FarmAZ

2. Start SQL Server with Docker
   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=FarmAZ@123" -p 1433:1433 --name farmaz-sql -d mcr.microsoft.com/mssql/server:2022-latest

3. Run database migrations
   dotnet ef database update

4. Run the project
   dotnet run

5. Open Swagger UI
   http://localhost:5286/swagger

## 📡 API Endpoints

### Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/Auth/register | Register new user |
| POST | /api/Auth/login | Login and get JWT token |

### Products
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Products | Get all products |
| POST | /api/Products | Create new product |
| GET | /api/Products/{id} | Get product by ID |

### Orders
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Orders | Get my orders |
| POST | /api/Orders | Create new order |

## 📚 About
This project was built for learning C# and ASP.NET Core backend development.