# KangaSysExportSystem – Architecture Overview

## 📌 Overview
`KangaSysExportSystem` is a modular .NET application built with Clean Architecture principles. It supports report exports in multiple formats (CSV, JSON, PDF) and exposes secured REST APIs using JWT and OAuth 2.0 authentication.

---

## 🧱 System Layers

- **Client**: Web or desktop frontend using HTTP (REST/JSON) and secured with JWT.
- **API Layer**: Contains controllers for authentication, exporting reports, and handling requests.
- **Application Layer**: Business logic and service orchestration.
- **Database**: Central store for user/report data.
- **Export Engine**: Generates file outputs in requested formats.
- **Output Files**: Exports are saved as `.csv`, `.json`, `.pdf`.
  
![image (1) (1)](https://github.com/user-attachments/assets/e79a377a-1c25-4aae-bcd7-b6842b57c154)

---

## 🔁 Data Flow

```text
Client --> API (Auth / Export / Reports) --> Application Services --> Database --> Export Engine --> Output Files
```

![image (2) (1)](https://github.com/user-attachments/assets/c2fbe6fe-b4dc-49bf-8b8f-73f29f26b542)

---

## 🚀 Example: Export Flow

1. Client calls `/api/export/report` with JWT.
2. API validates request and forwards to ExportService.
3. Service queries DB, applies filters, prepares data.
4. ExportEngine formats data to .CSV or .PDF.
5. File is returned or stored for download.

---

## ✅ Security

- Auth via **JWT** (compatible with OAuth 2.0 / OpenID Connect)
- Secure endpoints (`/api/auth`, `/api/export`, `/api/report`)

