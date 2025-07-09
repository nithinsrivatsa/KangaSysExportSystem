# 📡 KangaSysExportSystem – API Documentation

This document outlines the available API endpoints in the KangaSysExportSystem, with authentication, export, and report routes.

---

## 🔐 Authentication

**POST** `/api/Auth/login`

- Authenticates user and returns JWT.
- **Headers:** `Content-Type: application/json`
- **Body:**
```json
{
  "username": "demoUser",
  "password": "demoPass"
}
```
- **Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```
We need to provide actual user credentials to genarate the token.

---

## 📤 Export Report

**POST** `/api/Export`

- Exports data based on user input.
- **Headers:** `Authorization: Bearer <token>`
- **Body:**
```json
{
  "query": {
    "clientId": "CLIENT-15",
    "region": "Europe",
    "businessUnit": "IT",
    "fromDate": "2020-06-01T05:03:51.678Z",
    "toDate": "2025-07-08T05:03:51.678Z",
    "sortBy": "",
    "sortDescending": true,
    "pageNumber": 1,
    "pageSize": 1
  },
  "exportFormat": "json"
}
```
- **Response:** File download (CSV, JSON, or PDF)

Sample PDF Output:
![alt text](image-1.png)

Sample CSV Output:
![alt text](image-2.png)
---

## 📄 Get Report

**GET** `/api/Reports/query`

Example API after adding the query  - https://localhost:7142/api/Reports/query?ClientId=CLIENT-15&Region=Europe&BusinessUnit=IT&FromDate=2024-06-01%2000%3A00%3A00%2B05%3A30&ToDate=2025-06-01%2000%3A00%3A00%2B05%3A30&SortDescending=true&PageNumber=1&PageSize=100

- Retrieves previously generated report.
- **Headers:** `Authorization: Bearer <token>`
- **Response:**
```json
[
    {
        "id": "fe8fcd9d-8a20-4469-9812-3c451b7259a3",
        "clientId": "CLIENT-15",
        "region": "Europe",
        "businessUnit": "IT",
        "reportDate": "2025-04-21T18:30:00Z",
        "revenue": 61725.41,
        "expense": 38468.41,
        "segment": "Retail"
    },
    {
        "id": "bf3350f5-7e08-43cf-919e-5dd31cd011ae",
        "clientId": "CLIENT-15",
        "region": "Europe",
        "businessUnit": "IT",
        "reportDate": "2025-04-10T18:30:00Z",
        "revenue": 103521.23,
        "expense": 6952.12,
        "segment": "Retail"
    }
]
```

---
