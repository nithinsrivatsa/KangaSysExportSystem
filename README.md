````markdown
# 🧠 KangaSys Enterprise Data Query and Export System

A robust, scalable, and modular backend system built in **.NET 8** for querying large datasets, exporting in multiple formats (CSV, JSON, PDF), and supporting enterprise analytics workflows.

---

## 📌 Table of Contents

- [🔧 Features](#-features)
- [📐 Architecture](#-architecture)
- [🚀 Tech Stack](#-tech-stack)
- [⚙️ Setup Instructions](#️-setup-instructions)
- [🧪 Testing](#-testing)
- [📤 API Endpoints](#-api-endpoints)
- [🔐 Authentication](#-authentication)
- [🐳 Docker & Deployment](#-docker--deployment)
- [📄 License](#-license)

---

## 🔧 Features

- ✅ Clean Architecture with modular layers
- ✅ Query filtering, sorting, and pagination on billions of records
- ✅ Export to CSV, JSON, and PDF
- ✅ JWT-based authentication and role-based access
- ✅ Global error handling and Serilog structured logging
- ✅ PostgreSQL with EF Core support
- ✅ CI/CD with GitHub Actions
- ✅ Dockerized for deployment

---

## 📐 Architecture

```text
Client ──> API (Controllers)
└──> Application Layer (MediatR + DTOs)
└──> Domain Layer (Entities)
└──> Infrastructure Layer (EF Core, Export Services)
````

---

## 🚀 Tech Stack

| Area | Tools |
| ------------ | ---------------------------- |
| Framework | .NET 8 Web API |
| Architecture | Clean Architecture + CQRS |
| DB | PostgreSQL 15+ |
| ORM | Entity Framework Core 8 |
| Export | CsvHelper, DinkToPdf |
| Auth | JWT Authentication |
| Testing | xUnit, Moq, FluentAssertions |
| CI/CD | GitHub Actions |
| Container | Docker + Docker Compose |

---

## ⚙️ Setup Instructions

1. **Clone the Repo**

```bash
git clone https://github.com/your-username/KangaSysExportSystem.git
cd KangaSysExportSystem
```

2. **Set Connection String in `appsettings.Development.json`**

```json
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Port=5432;Database=kangasys;Username={userName};Password={password}"
}
```

3. **Run the Project**

```bash
dotnet run --project KangaSys.API
```

4. **View Swagger**

```
https://localhost:5001/swagger
```

---

## 🧪 Testing

* **Unit Tests**

```bash
dotnet test KangaSys.ServicesTests
dotnet test KangaSys.ControllerTests
```

* **Integration Tests**

```bash
dotnet test KangaSys.IntegrationTests
```

---

## 📤 API Endpoints

| Endpoint | Description |
| ---------------------- | ---------------------------- |
| `POST /api/auth/login` | Get JWT Token |
| `GET /api/reports` | Filter, paginate report data |
| `POST /api/export` | Export filtered data to file |

📌 Swagger UI:

```
https://localhost:5001/swagger
```

---

## 🔐 Authentication

The application supports **JWT-based Bearer Authentication**.

### 🔁 Flow
1. Call `POST /api/auth/login` with valid credentials.
2. Receive a JWT access token.
3. Use the token in API requests.

---

## 🐳 Docker & Deployment

### 🧱 Build Docker Image

```bash
docker build -t kangasys-api -f KangaSys.API/Dockerfile .
docker run -p 8080:80 kangasys-api
```

### 🐳 Using Docker Compose

```bash
docker-compose up --build
```

---

## ✅ GitHub Actions CI

* Runs `dotnet build`, `dotnet test` on every push/PR to `main`
* Workflow file: `.github/workflows/dotnet-ci.yml`

## 🙋‍♂️ Author

Developed by Nithin Srivatsa. Feel free to contact: nithinsrivatsa05@gmail.com

---
