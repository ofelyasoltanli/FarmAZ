# FarmAZ API

FarmAZ is a simple RESTful API built for managing agricultural products and orders. Farmers can list their products, and customers can place orders based on available listings. The project is built with ASP.NET Core and follows a clean and practical backend structure.

## Features

* User registration and login with JWT authentication
* Product management (create, update, delete, read)
* Order management system
* Secure password hashing using BCrypt
* Distance calculation using the Haversine formula
* Global error handling using middleware
* SQL Server database running in Docker
* Swagger UI for API testing and documentation

## Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt.Net
* Swagger / OpenAPI

## 📁 Project Structure

```
FarmAZ/
├── Controllers/
├── Data/
├── DTOs/
├── Entities/
├── Helpers/
├── Middlewares/
├── Repositories/
└── Services/
```

## Getting Started

### Prerequisites

* .NET SDK 8
* Docker Desktop

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/ofelyasoltanli/FarmAZ.git
cd FarmAZ
```

### 2. Start SQL Server using Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=FarmAZ@123" -p 1434:1433 --name farmaz-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

If the container already exists:

```bash
docker start farmaz-sql
```

### 3. Configure connection string

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1434;Database=FarmAZDb;User Id=sa;Password=FarmAZ@123;TrustServerCertificate=True;"
}
```

### 4. Run the application

```bash
dotnet run
```

### 5. Open Swagger UI

```
http://localhost:5286/swagger
```

## 📡 API Endpoints

### Authentication

| Method | Endpoint           | Description                 |
| ------ | ------------------ | --------------------------- |
| POST   | /api/Auth/register | Register a new user         |
| POST   | /api/Auth/login    | Login and receive JWT token |

### Products

| Method | Endpoint           | Description          |
| ------ | ------------------ | -------------------- |
| GET    | /api/Products      | Get all products     |
| POST   | /api/Products      | Create a new product |
| GET    | /api/Products/{id} | Get product by ID    |

### Orders

| Method | Endpoint    | Description        |
| ------ | ----------- | ------------------ |
| GET    | /api/Orders | Get user orders    |
| POST   | /api/Orders | Create a new order |

## Authentication Flow

1. Register via `/api/Auth/register`
2. Login via `/api/Auth/login`
3. Copy the JWT token
4. Click **Authorize** in Swagger
5. Enter:

```
Bearer YOUR_TOKEN
```

## Future Improvements

* Pagination and filtering
* Role-based authorization (Admin / User)
* Image upload with Cloudinary
* Redis caching
* Cloud deployment (Azure or AWS)

## About This Project

This project was built to practice real-world backend development with ASP.NET Core. It focuses on clean architecture, authentication, and database management.

## License

This project is open source and available under the MIT License.

