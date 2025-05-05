# ASP.NET Core Minimal API - .NET 9

## What is This Project About?

This project demonstrates how to build a simple and clean RESTful API using ASP.NET Core Minimal APIs, 
following modern best practices with a real-world example.

We’ve created a basic ToDo List API to showcase features like routing, model binding, and dependency injection with minimal boilerplate.

---

## Prerequisites

Make sure the following tools/services are available before running the PoC:

- [.NET 9 SDK (Preview)]
- Visual Studio 2022+ or VS Code
- NuGet Package Manager (or CLI)
- Postman (optional) for testing APIs / Browser

---

## When and Why Use Minimal APIs?

### Use When:
- Building lightweight microservices or internal APIs.
- Prototyping or PoCs with quick iterations.
- You don’t need MVC overhead or complex features.

### Why Use:
- Fast startup and low memory usage.
- Clean, minimal boilerplate.
- Easier for small teams or APIs that don’t need full MVC structure.

---

## How It Works?

This API allows users to perform CRUD operations on ToDo items using RESTful endpoints. It uses:

- In-Memory Database with EntityFrameworkCore
- Minimal API Routing
- Swagger UI for testing and documentation


---

# Available Endpoints

## Method		Endpoint		Description

GET			/todos			Get all todos

GET			/todos/{id}		Get todo by ID

POST		/todos			Create a new todo

PUT			/todos/{id}		Update existing todo

DELETE		/todos/{id}		Delete todo by ID

---

### Notes

This project uses an in-memory  database, so data will reset on each restart.

You can replace it with SQL Server or any persistent database for production use.

