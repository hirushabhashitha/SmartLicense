# SmartLicense

SmartLicense is a full-stack driving-license management system. It provides a public React application for applicants, an ASP.NET Core API for application and account data, and a Windows desktop administration client for reviewing applications and managing driving schools.

> **Project status:** This repository is a development project. The instructions below describe the current source tree and local-development configuration. Review the security notes before deploying it anywhere other than a private development environment.

## Contents

- [Overview](#overview)
- [Repository structure](#repository-structure)
- [Technology stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Quick start](#quick-start)
- [Database setup](#database-setup)
- [Run the backend API](#run-the-backend-api)
- [Run the React application](#run-the-react-application)
- [Run the admin application](#run-the-admin-application)
- [Optional AuthApi project](#optional-authapi-project)
- [Application workflows](#application-workflows)
- [API reference](#api-reference)
- [Configuration](#configuration)
- [Uploads](#uploads)
- [Build and validation commands](#build-and-validation-commands)
- [Troubleshooting](#troubleshooting)
- [Security and production readiness](#security-and-production-readiness)
- [Development guidelines](#development-guidelines)

## Overview

SmartLicense is split into three working parts:

1. **Applicant web application** - A Vite/React single-page application for registration, login, license applications, document uploads, application status, dashboard information, and driving-school information.
2. **SmartLicense API** - An ASP.NET Core Web API that exposes account, license-application, driving-school, and dashboard endpoints. It persists data with Entity Framework Core and MySQL and exposes Swagger in Development.
3. **SmartLicense Admin** - A Windows Forms desktop application for staff. It reads applications, displays application details and uploaded certificates, updates application status, and manages driving-school records.

The web application and admin application currently call the HTTPS API at `https://localhost:7077`.

## Repository structure

```text
.
├── smartLicense/                         React/Vite applicant application
│   ├── src/
│   ├── package.json
│   └── package-lock.json
├── SmartLicenseAPI/                      Main ASP.NET Core API
│   ├── SmartLicenseAPI.sln
│   └── SmartLicenseAPI/
│       ├── Controllers/
│       ├── Data/
│       ├── Entities/ and Entity/
│       ├── Migrations/
│       ├── Properties/launchSettings.json
│       └── SmartLicenseAPI.csproj
├── SmartLicenseAdmin/                    Windows Forms administration client
│   ├── SmartLicenseAdmin.sln
│   └── SmartLicenseAdmin/
└── smartLicense/AuthApi/                 Separate .NET 9 sample/template API
```

The `smartLicense/SmartLicenseAPI/` directory contains another API project with a different target framework and launch profile. It is not the API used by the current React client. Use the root-level `SmartLicenseAPI/` project for the normal local setup described in this document.

## Technology stack

| Area | Technology |
| --- | --- |
| Applicant UI | React 19, Vite 6, React Router, Material UI, Axios |
| Main API | ASP.NET Core 8 Web API |
| Data access | Entity Framework Core 8, Pomelo MySQL provider |
| Database | MySQL 8 or a compatible MySQL server |
| Admin UI | .NET 8 Windows Forms |
| API documentation | Swashbuckle / Swagger UI |
| Source control | Git and GitHub |

## Prerequisites

Install the following before starting:

- Git
- Node.js 18 or newer and npm
- .NET 8 SDK
- .NET 8 Windows Desktop Runtime/SDK for the admin client
- MySQL Server 8 or a compatible MySQL installation
- Visual Studio 2022 with the ASP.NET and web development and .NET desktop development workloads, or an equivalent command-line setup

Check the installed versions:

```powershell
git --version
node --version
npm --version
dotnet --version
mysql --version
```

The admin application targets `net8.0-windows` and therefore requires Windows.

## Quick start

The API must be running before the React application or admin client can load data.

### 1. Clone the repository

```powershell
git clone https://github.com/hirushabhashitha/SmartLicense.git
cd SmartLicense
```

### 2. Prepare MySQL

Create the database and configure the connection string as described in [Database setup](#database-setup).

### 3. Start the API

Open a terminal in the repository root:

```powershell
cd SmartLicenseAPI/SmartLicenseAPI
dotnet restore
dotnet ef database update
dotnet run --launch-profile https
```

The API is then available at:

- Swagger UI: `https://localhost:7077/swagger`
- HTTPS API: `https://localhost:7077`
- HTTP API: `http://localhost:5099`

The development HTTPS certificate may cause a browser warning the first time. Trust the certificate with `dotnet dev-certs https --trust` or use the HTTP profile for local testing where appropriate.

### 4. Start the React application

Open a second terminal:

```powershell
cd smartLicense
npm install
npm run dev
```

Open the Vite URL shown in the terminal, normally `http://localhost:5173`.

### 5. Start the admin client, when needed

Open a third terminal on Windows:

```powershell
cd SmartLicenseAdmin/SmartLicenseAdmin
dotnet restore
dotnet run
```

The admin client expects the API HTTPS endpoint and MySQL database to be available.

## Database setup

The main API uses the `SmartLicenseDB` MySQL database and Entity Framework Core migrations.

### Create the database

Using the MySQL client, create an empty database:

```sql
CREATE DATABASE SmartLicenseDB
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;
```

The migrations create the application tables. Do not manually create the tables before running the migrations.

### Configure the connection string

The main API reads `ConnectionStrings:DefaultConnection`. The checked-in development configuration is in `SmartLicenseAPI/SmartLicenseAPI/appsettings.json`.

For a local machine, use a connection string matching your MySQL account. A safer option is an environment variable so credentials do not need to be committed:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=localhost;Port=3306;Database=SmartLicenseDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
```

Then apply the migrations from the main API project:

```powershell
cd SmartLicenseAPI/SmartLicenseAPI
dotnet ef database update
```

If the `dotnet ef` command is not installed:

```powershell
dotnet tool install --global dotnet-ef
```

For an already-created database, use `dotnet ef migrations list` to inspect the available migrations and `dotnet ef database update` to bring it up to date.

### Current data model

The current migrations include tables and fields for:

- Users and user roles
- License applications and applicant details
- Driving schools
- Uploaded birth and medical certificate file names
- Application status and submission timestamps

The API does not automatically run migrations on startup, so the migration command is required for a new database.

## Run the backend API

The main API project is:

```text
SmartLicenseAPI/SmartLicenseAPI/SmartLicenseAPI.csproj
```

Run with the HTTPS profile:

```powershell
cd SmartLicenseAPI/SmartLicenseAPI
dotnet run --launch-profile https
```

Run with HTTP only:

```powershell
dotnet run --launch-profile http
```

The launch profiles are defined in `SmartLicenseAPI/SmartLicenseAPI/Properties/launchSettings.json`:

| Profile | URL | Swagger |
| --- | --- | --- |
| `https` | `https://localhost:7077` and `http://localhost:5099` | `/swagger` |
| `http` | `http://localhost:5099` | `/swagger` |

Swagger and Swagger UI are enabled when `ASPNETCORE_ENVIRONMENT=Development`.

## Run the React application

The frontend project is in `smartLicense/`.

Install dependencies and start the development server:

```powershell
cd smartLicense
npm install
npm run dev
```

Available npm scripts:

| Command | Purpose |
| --- | --- |
| `npm run dev` | Start Vite with hot module replacement |
| `npm run build` | Create a production build in `dist/` |
| `npm run preview` | Serve the built `dist/` output locally |
| `npm run lint` | Run ESLint |

The current frontend API modules use `https://localhost:7077` directly. If the API runs on another port, update the API URL references in `smartLicense/src/api/` and the page components that call the API directly, or refactor them to a shared environment-based configuration.

## Run the admin application

The admin solution is:

```text
SmartLicenseAdmin/SmartLicenseAdmin.sln
```

From Visual Studio:

1. Open `SmartLicenseAdmin/SmartLicenseAdmin.sln`.
2. Select the `SmartLicenseAdmin` project as the startup project.
3. Confirm the main API is running at `https://localhost:7077`.
4. Build and run the project.

From PowerShell:

```powershell
cd SmartLicenseAdmin/SmartLicenseAdmin
dotnet restore
dotnet build
dotnet run
```

The admin application contains a login flow, application list, application details view, approve/reject actions, certificate viewing/downloading, and driving-school management.

The admin code currently contains a MySQL connection string and the API URL in source files. Update those values for your environment before using a database account that differs from the existing local development setup.

## Optional AuthApi project

`smartLicense/AuthApi/` is a separate .NET 9 project containing the default ASP.NET OpenAPI/weather-forecast template. It is not wired into the React application, and the current frontend calls the `AuthController` in the main `SmartLicenseAPI` project instead.

Run it only when specifically working on that project:

```powershell
cd smartLicense/AuthApi
dotnet restore
dotnet run
```

Its launch settings use `http://localhost:5296` and `https://localhost:7191`. It should not be started as a replacement for the main API during normal application development.

## Application workflows

### Applicant workflow

1. Register an account from the React application.
2. Log in with the registered email and password.
3. Complete and submit a license application.
4. Upload the required birth and medical certificates.
5. Review submitted application information and its current status.
6. Browse driving-school information returned by the API.

### Staff workflow

1. Start the main API and ensure MySQL is available.
2. Launch the Windows admin application.
3. Sign in using an account stored in the `Users` table.
4. Review pending applications.
5. Open application details and view or download uploaded certificates.
6. Approve or reject an application.
7. Add or review driving-school records.

## API reference

All routes below are relative to `https://localhost:7077` and are available under the `api` prefix.

| Method | Route | Purpose |
| --- | --- | --- |
| `POST` | `/api/Auth/register` | Register a user |
| `POST` | `/api/Auth/login` | Log in a user |
| `GET` | `/api/DataCardClick?id={userId}` | Get dashboard/application summary data for a user |
| `GET` | `/api/DrivingSchools` | List driving schools |
| `POST` | `/api/LicenseApplication/submit` | Submit a multipart license application with files |
| `GET` | `/api/LicenseApplication/user/{id}` | Get application details for a user/application identifier |
| `GET` | `/api/LicenseApplication/all` | List all applications for administration |
| `GET` | `/api/LicenseApplication/details/{id}` | Get one application in detail |
| `PUT` | `/api/LicenseApplication/updateStatus/{id}` | Update an application status |
| `GET` | `/api/LicenseApplication/view/{fileName}` | View an uploaded certificate |
| `GET` | `/api/LicenseApplication/download/{fileName}` | Download an uploaded certificate |

Interactive API documentation is available at `https://localhost:7077/swagger` while the API is running in Development.

## Configuration

### API CORS

The main API allows the Vite development origins:

- `http://localhost:5173`
- `https://localhost:5173`

If Vite chooses another port, add that origin to the CORS policy in `SmartLicenseAPI/SmartLicenseAPI/Program.cs`.

### Frontend API URL

The frontend currently uses hard-coded API URLs in several files, including:

- `smartLicense/src/api/auth.js`
- `smartLicense/src/api/common.js`
- `smartLicense/src/api/exam.js`
- API calls in selected page components

Keep these URLs consistent with the API launch profile. A future production configuration should move the base URL to a Vite environment variable such as `VITE_API_URL`.

### Admin API and database URLs

The admin client currently uses the API HTTPS URL and MySQL connection settings in its C# source. Search for `API_URL` and `connStr` before changing environments.

## Uploads

License certificate files are saved by the API under:

```text
SmartLicenseAPI/SmartLicenseAPI/Uploads/
```

The directory is created when a license application is submitted if it does not already exist. Keep this directory backed up if uploaded documents are important. Do not commit personal documents or production uploads to Git.

## Build and validation commands

Run the following checks before opening a pull request:

```powershell
# React checks
cd smartLicense
npm install
npm run lint
npm run build

# Main API checks
cd ../SmartLicenseAPI/SmartLicenseAPI
dotnet restore
dotnet build

# Admin checks on Windows
cd ../../SmartLicenseAdmin/SmartLicenseAdmin
dotnet restore
dotnet build
```

There are currently no repository-level automated test projects. Swagger requests and the application workflows described above are the primary local verification path.

## Troubleshooting

### The frontend reports a network or CORS error

- Confirm the main API is running.
- Confirm it is using the HTTPS profile and listening on `https://localhost:7077`.
- Confirm the browser trusts the local .NET HTTPS certificate.
- Confirm the frontend is running on `http://localhost:5173` or add its origin to the API CORS policy.

### The API cannot connect to MySQL

- Confirm the MySQL service is running on port `3306`.
- Confirm `SmartLicenseDB` exists.
- Confirm the username and password in `ConnectionStrings__DefaultConnection` are valid.
- Confirm the database user has permission to create and alter tables.
- Run `dotnet ef database update` from `SmartLicenseAPI/SmartLicenseAPI`.

### Swagger is unavailable

Run the API with `ASPNETCORE_ENVIRONMENT=Development` and use `/swagger` on the correct API port.

### Certificate view/download fails

- Confirm the application was submitted with both required files.
- Confirm the file exists under the API `Uploads` directory.
- Confirm the API is running and the admin client is using the same API URL.

### The admin application will not build

- Use Windows with the .NET 8 SDK and Windows Desktop workload installed.
- Open the `.sln` file in Visual Studio if command-line build does not restore Windows Forms dependencies.
- Confirm the target framework is supported by the installed SDK.

## Security and production readiness

The current source is intended for development and requires security hardening before deployment:

- Replace all checked-in or hard-coded database credentials.
- Do not store plain-text passwords. Use a password-hashing algorithm and secure credential handling.
- Move API URLs and connection strings to environment-specific configuration.
- Restrict CORS to trusted production origins instead of allowing development origins.
- Add authentication and authorization middleware for protected endpoints.
- Validate file size, file type, file names, and file contents before storing uploads.
- Store uploaded documents outside the public application directory or behind authorization checks.
- Add rate limiting, structured error handling, audit logging, and input validation.
- Use HTTPS with a trusted certificate in every non-local environment.
- Remove development certificate bypasses from the admin client.
- Protect database backups and uploaded identity documents as sensitive personal data.

Do not use the existing local development credentials in a shared, staging, or production environment.

## Development guidelines

- Keep API contract changes synchronized with the React API modules and admin client.
- Add or update an Entity Framework migration when the data model changes.
- Run frontend lint/build and backend builds before pushing changes.
- Keep generated build output, local databases, secrets, and uploaded documents out of commits.
- Prefer configuration values over hard-coded environment-specific URLs and credentials.
- Document new endpoints and user-visible workflows in this README.

## License

No license file is currently included in the repository. Contact the repository owner before redistributing or using the project outside its intended context.
