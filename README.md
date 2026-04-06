# 🌱 FarmAZ API

A modern **RESTful backend API** built with **ASP.NET Core (.NET 10)**.
FarmAZ is a farm marketplace where farmers list products and customers place orders based on location.


## 🚀 Features

* 🔐 JWT Authentication (Register / Login)
* 🛒 Product management (CRUD)
* 📦 Order management
* 🔑 Secure password hashing with **BCrypt**
* 📍 Distance calculation (Haversine formula)
* ⚡ Global exception handling middleware
* 🐳 Docker support (SQL Server)
* 📄 Swagger API documentation


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

### ▶️ Run the Project

1️⃣ **Clone the repository**

```bash
git clone https://github.com/ofelyasoltanli/FarmAZ.git
cd FarmAZ
```

2️⃣ **Start SQL Server (Docker)**

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=FarmAZ@123" -p 1433:1433 --name farmaz-sql -d mcr.microsoft.com/mssql/server:2022-latest
# If already created:
docker start farmaz-sql
```

3️⃣ **Configure Connection String** in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=FarmAZDb;User Id=sa;Password=FarmAZ@123;TrustServerCertificate=True;"
}
```

4️⃣ **Apply Migrations**

```bash
dotnet ef database update
```

5️⃣ **Run the Application**

```bash
dotnet run
```

6️⃣ **Open Swagger UI**

```
http://localhost:{PORT}/swagger
```

> ℹ️ Check terminal output for the correct port.


## 📡 API Endpoints

### 🔐 Auth

| Method | Endpoint           | Description             |
| ------ | ------------------ | ----------------------- |
| POST   | /api/Auth/register | Register new user       |
| POST   | /api/Auth/login    | Login and get JWT token |

### 🛒 Products

| Method | Endpoint           | Description                    |
| ------ | ------------------ | ------------------------------ |
| GET    | /api/Products      | Get all products               |
| POST   | /api/Products      | Create product (auth required) |
| GET    | /api/Products/{id} | Get product by ID              |

### 📦 Orders

| Method | Endpoint    | Description                      |
| ------ | ----------- | -------------------------------- |
| GET    | /api/Orders | Get my orders (auth required)    |
| POST   | /api/Orders | Create new order (auth required) |


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

A learning project demonstrating skills in:

* ASP.NET Core Web API development
* Clean architecture (Controller → Service → Repository)
* Authentication & security
* Database design with Entity Framework Core


## ⭐ Contributing

Feel free to **fork** the repository and improve the project.


## 📄 License

Open-source under the **MIT License**.
