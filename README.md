NZWalks API – Production Ready ASP.NET Core Backend
📌 Overview

NZWalks API is a production-ready RESTful backend built using ASP.NET Core. The application demonstrates secure authentication, role-based authorization, structured logging, pagination, filtering, and clean architecture principles.

This project is designed to simulate real-world backend application development standards.

🚀 Features

JWT Authentication with Refresh Token

Role-Based Authorization (Admin/User)

Pagination, Sorting & Filtering

Global Exception Handling Middleware

Structured Logging (Serilog)

DTO Pattern with AutoMapper

Repository Pattern Implementation

Entity Framework Core Integration

Swagger API Documentation

Azure Deployment

🏗 Architecture

The project follows a layered architecture:

Controllers (API Layer)

Services Layer (Business Logic)

Repository Layer (Data Access)

DTOs for Data Transfer

Middleware Pipeline for centralized exception handling

🛠 Tech Stack

ASP.NET Core

Entity Framework Core

SQL Server

JWT Authentication

Serilog

Azure App Service

Swagger / OpenAPI

🔐 Authentication Flow

User registers or logs in

Server generates Access Token and Refresh Token

Access Token used for authorized API calls

Refresh Token used to generate new access token when expired

📊 API Endpoints

POST /api/auth/register

POST /api/auth/login

POST /api/images/upload

GET /api/regions

GET /api/regions/{id}

POST /api/regions

PUT /api/regions/{id}

DELETE /api/regions/{id}

GET /api/walks

GET /api/walks/{id}

POST /api/walks

PUT /api/walks/{id}

DELETE /api/walks/{id}

🌍 Live Demo

API Base URL:

Swagger UI:

📦 How to Run Locally

Clone the repository

Configure appsettings.json

Update connection string

Run database migrations

Execute the project

📈 Future Improvements

Redis Caching

Docker Containerization

CI/CD Pipeline

API Versioning
