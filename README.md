# 🌱 FarmAZ API

FarmAZ is a backend **RESTful API** that allows farmers to list their products and customers to place orders based on location. Built using **ASP.NET Core (.NET 10)**, this project focuses on clean architecture and practical API development.

## 🚀 Features

* 🔐 User registration and login (**JWT Authentication**)
* 🛒 Product management (CRUD)
* 📦 Order management
* 🔑 Password security with **BCrypt**
* 📍 Distance calculation using the Haversine formula
* ⚡ Global error handling (middleware)
* 🐳 Docker support (SQL Server)
* 📄 API documentation with Swagger UI


## 🔧 Tech Stack

* **ASP.NET Core (.NET 10)**
* **Entity Framework Core 9**
* **SQL Server (Docker)**
* **JWT Bearer Authentication**
* **BCrypt.Net**
* **Swagger UI**


## 📁 Project Structure

FarmAZ/
├── Controllers/
├── Data/
├── DTOs/
├── Entities/
├── Helpers/
├── Middlewares/
├── Repositories/
└── Services/


## ⚙️ Getting Started

### 📌 Prerequisites

* .NET SDK 10.x
* Docker Desktop

### ▶️ Running the Project

1️⃣ **Clone the repository**

```bash
git clone https://github.com/ofelyasoltanli/FarmAZ.git
cd FarmAZ
```

2️⃣ **Start SQL Server with Docker**

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=FarmAZ@123" -p 1433:1433 --name farmaz-sql -d mcr.microsoft.com/mssql/server:2022-latest
# If already created:
docker start farmaz-sql
```

3️⃣ **Update Connection String** in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=FarmAZDb;User Id=sa;Password=FarmAZ@123;TrustServerCertificate=True;"
}
```

4️⃣ **Apply database migrations**

```bash
dotnet ef database update
```

5️⃣ **Run the application**

```bash
dotnet run
```

6️⃣ **Open Swagger UI**

```
http://localhost:{PORT}/swagger
```

> ℹ️ Check your terminal for the correct port.


## 📡 API Endpoints

### 🔐 Auth

| Method | Endpoint           | Description               |
| ------ | ------------------ | ------------------------- |
| POST   | /api/Auth/register | Register a new user       |
| POST   | /api/Auth/login    | Login and get a JWT token |

### 🛒 Products

| Method | Endpoint           | Description                      |
| ------ | ------------------ | -------------------------------- |
| GET    | /api/Products      | Get all products                 |
| POST   | /api/Products      | Create a product (auth required) |
| GET    | /api/Products/{id} | Get a product by ID              |

### 📦 Orders

| Method | Endpoint    | Description                        |
| ------ | ----------- | ---------------------------------- |
| GET    | /api/Orders | Get my orders (auth required)      |
| POST   | /api/Orders | Create a new order (auth required) |


## 🔑 Authentication Guide

1. Register via `/api/Auth/register`
2. Login via `/api/Auth/login`
3. Copy the JWT token
4. Click **Authorize** in Swagger
5. Enter: `Bearer YOUR_TOKEN`

## 📌 Future Improvements

Planned features:

* Pagination & filtering
* Role-based authorization (Admin/User)
* Image upload (Cloudinary)
* Redis caching
* Cloud deployment (Azure / AWS)

## 👩‍💻 About

This is a learning project demonstrating:

* Building RESTful APIs with ASP.NET Core
* Clean architecture (Controller → Service → Repository)
* Authentication & security
* Database design with Entity Framework Core

## ⭐ Contributing

Feel free to **fork** the repository and contribute improvements.

## 📄 License

Open-source under the **MIT License**

