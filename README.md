# 🌿 NZWalks(New Zealand Walks) API– Production Ready ASP.NET Core Backend 

## 🚀 Overview

**NZWalks API** is a production-grade RESTful backend built using **ASP.NET Core**, following clean architecture principles and enterprise-level best practices.

This project simulates a real-world backend system with secure authentication, role-based authorization, structured logging, pagination, filtering, and cloud deployment.

It demonstrates how modern backend systems are built in professional environments.

---

## 🏗 Architecture (Layered Clean Architecture)

```text
Controllers  →  Services  →  Repositories  →  Database
        ↓
     DTOs + AutoMapper
        ↓
Middleware (Exception Handling + Logging)
```

### 🔹 Layers Included

* API Layer (Controllers)
* Service Layer (Business Logic)
* Repository Layer (Data Access)
* DTO Layer (Data Transfer Objects)
* Middleware (Centralized Error Handling)
* Authentication & Authorization Pipeline

---

## 🔥 Key Features

### 🔐 Security & Authentication

* JWT Access Token
* Role-Based Authorization (Admin / User)
* Secure Endpoints with Policies

### 📊 Advanced API Capabilities

* Pagination
* Sorting
* Filtering
* Global Exception Handling Middleware
* Structured Logging with Serilog

### 🧠 Design Patterns Used

* Repository Pattern
* DTO Pattern
* Dependency Injection
* AutoMapper
* Clean Code Principles

---

## 🛠 Tech Stack

* ASP.NET Core
* Entity Framework Core
* SQL Server
* JWT Authentication
* Serilog
* Swagger / OpenAPI
* Azure App Service

---

## 🔐 Authentication Flow

1️⃣ User Registers / Logs In
2️⃣ Server Generates:

* Access Token

This simulates real-world secure backend systems.

---

## 📌 API Endpoints

### 🔑 Authentication

* `POST /api/auth/register`
* `POST /api/auth/login`

### 🗺 Regions

* `GET /api/regions`
* `GET /api/regions/{id}`
* `POST /api/regions`
* `PUT /api/regions/{id}`
* `DELETE /api/regions/{id}`

### 🚶 Walks

* `GET /api/walks`
* `GET /api/walks/{id}`
* `POST /api/walks`
* `PUT /api/walks/{id}`
* `DELETE /api/walks/{id}`

### 🖼 Image Upload

* `POST /api/images/upload`

---

## 🌍 Live Demo

🔗 API Base URL
[https://app-nzwalks-southindia-dev-001-d3gqh6epgbhza6ag.southindia-01.azurewebsites.net/](https://app-nzwalks-southindia-dev-001-d3gqh6epgbhza6ag.southindia-01.azurewebsites.net/)

📘 Swagger UI
[https://app-nzwalks-southindia-dev-001-d3gqh6epgbhza6ag.southindia-01.azurewebsites.net/index.html](https://app-nzwalks-southindia-dev-001-d3gqh6epgbhza6ag.southindia-01.azurewebsites.net/index.html)

---

## 💻 How To Run Locally

```bash
git clone <repository-url>
cd NZWalks.API
```

### 1️⃣ Configure `appsettings.json`

* Add SQL Server connection string
* Add JWT Secret

### 2️⃣ Run Migrations

```bash
dotnet ef database update
```

### 3️⃣ Run Application

```bash
dotnet run
```

---

## 📈 Production-Level Concepts Demonstrated

* Secure JWT Token Flow
* Role-Based Access Control
* Centralized Logging (Serilog)
* Clean Layered Architecture
* Cloud Deployment on Azure
* API Documentation with Swagger
* Proper HTTP Status Codes
* Structured Exception Handling

---

## ☁ Azure Deployment

The application is deployed on **Azure App Service**, simulating real enterprise deployment workflow.

Includes:

* Environment configuration
* Production build optimization
* Secure deployment setup

---

## 🔮 Future Improvements

* Redis Caching
* Docker Containerization
* CI/CD Pipeline (GitHub Actions)
* API Versioning
* Unit Testing with xUnit
* Integration Testing
* Health Checks Monitoring

---

## 👨‍💻 Author

Aman Kant Savita
ASP.NET Core Backend Developer
2+ Years Experience | JWT | EF Core | Azure
