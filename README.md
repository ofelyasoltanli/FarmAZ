# FarmAZ API

FarmAZ is a backend system for a farm marketplace platform that connects farmers directly with customers. The platform enables product listing, order processing, and user management in a scalable and secure environment.

The system is designed with real-world backend architecture principles, focusing on maintainability, security, and extensibility.

## Key Features

* Secure authentication and authorization using JWT
* Role-based access control (Farmer, Customer, Admin)
* Product lifecycle management with ownership validation
* Order processing system with user-specific tracking
* Secure credential storage using BCrypt hashing
* Geolocation-based filtering using distance calculation
* Centralized exception handling via middleware
* Docker-based database deployment (SQL Server)
* API documentation with Swagger (OpenAPI)

## Architecture Overview

FarmAZ is built using a clean layered architecture to ensure separation of concerns and scalability:

* **API Layer (Controllers)** → Handles HTTP requests and responses
* **Application Layer (Services)** → Contains business logic
* **Data Access Layer (Repositories)** → Manages database operations
* **Domain Layer (Entities)** → Represents core data models
* **Infrastructure Layer** → External services and configurations

## Technology Stack

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server (Dockerized)
* JWT Authentication
* BCrypt.Net
* Swagger / OpenAPI

## Project Structure

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

* .NET 8 SDK
* Docker Desktop

## Installation & Setup

### 1. Clone repository

```bash
git clone https://github.com/ofelyasoltanli/FarmAZ.git
cd FarmAZ
```

### 2. Start database (SQL Server via Docker)

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=FarmAZ@123" -p 1434:1433 --name farmaz-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

If already created:

```bash
docker start farmaz-sql
```

### 3. Configure environment

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1434;Database=FarmAZDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
}
```

> In production environments, sensitive values should be managed through environment variables.

### 4. Run application

```bash
dotnet run
```

### 5. API Documentation

Once running, Swagger UI is available at:

```
https://localhost:<port>/swagger
```

## Authentication Flow

1. Register a user → `/api/Auth/register`
2. Login → `/api/Auth/login`
3. Receive JWT token
4. Authorize in Swagger using:

```
Bearer YOUR_TOKEN
```

## API Endpoints Overview

### Authentication

* POST `/api/Auth/register`
* POST `/api/Auth/login`

### Products

* GET `/api/Products`
* POST `/api/Products`
* GET `/api/Products/{id}`

### Orders

* POST `/api/Orders`
* GET `/api/Orders`

## System Design Principles

* Separation of concerns across layers
* Scalable service-oriented structure
* Secure authentication flow with token-based access
* Extensible architecture for future microservices migration

## Planned Enhancements

* Cloud-based image storage integration
* Payment gateway integration
* Advanced order lifecycle management
* Pagination & filtering optimization
* Deployment on cloud infrastructure (Azure / AWS)

##  License

This project is licensed under the MIT License.
