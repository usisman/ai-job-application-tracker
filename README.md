# AI Job Application Tracker

AI Job Application Tracker is a work-in-progress backend project built with ASP.NET Core.
The main goal of this project is to create a job application tracking system and gradually evolve it into an AI-powered automation platform with n8n, LangGraph, and MCP integrations.

This project is also designed as a learning and portfolio project to strengthen .NET backend fundamentals such as REST API development, EF Core, SQL, authentication, logging, and clean backend architecture.

## Project Status

This project is currently under active development.

Current progress:

* ASP.NET Core Web API project initialized
* Controller-based API structure configured
* Swagger/OpenAPI enabled
* Basic REST endpoints implemented
* In-memory CRUD completed
* DTO and Model structure added
* EF Core packages installed
* SQLite database connection configured
* AppDbContext created
* Initial EF Core migration created
* SQLite database generated
* JobApplications table created

Next step:

* Replace the temporary in-memory list with real database operations using EF Core and AppDbContext

## Current API Features

The project currently includes basic CRUD endpoints for job applications.

### Job Application Endpoints

```http
GET    /api/applications
GET    /api/applications/{id}
POST   /api/applications
PUT    /api/applications/{id}
DELETE /api/applications/{id}
```

These endpoints were first implemented using an in-memory static list.
The next development step is to move these operations to the SQLite database through EF Core.

## Tech Stack

Current stack:

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger / OpenAPI
* REST API

Planned integrations:

* JWT Authentication
* Logging
* Error handling middleware
* n8n workflow automation
* LangGraph AI agents
* MCP tool integration
* Docker
* PostgreSQL or SQL Server

## Project Goal

The final goal is to build an AI-powered job application tracking platform.

Planned features include:

* Track job applications
* Store company, position, status, and notes
* Manage application progress
* Analyze job postings against a CV
* Generate tailored cover letters
* Automate reminders and follow-ups with n8n
* Expose backend actions as MCP tools
* Connect AI agents to the application workflow

## Planned Architecture

```text
Frontend / Swagger / API Client
        ↓
ASP.NET Core Web API
        ↓
Controllers
        ↓
Services
        ↓
EF Core / AppDbContext
        ↓
SQLite / PostgreSQL Database
        ↓
n8n / LangGraph / MCP Integrations
```

## Current Folder Structure

```text
JobApplicationTracker.Api
├── Controllers
│   └── ApplicationsController.cs
├── Data
│   └── AppDbContext.cs
├── DTOs
│   ├── CreateJobApplicationDto.cs
│   └── UpdateJobApplicationDto.cs
├── Models
│   └── JobApplication.cs
├── Migrations
├── appsettings.json
├── Program.cs
└── JobApplicationTracker.Api.csproj
```

## Current Learning Focus

This project is being developed step by step with a focus on understanding the backend fundamentals behind each implementation.

Current learning topics:

* REST API basics
* Controller-based API structure
* HTTP methods and status codes
* Route parameters
* DTO vs Model usage
* Dependency Injection
* EF Core DbContext
* DbSet and database table mapping
* EF Core migrations
* SQLite database creation

Upcoming learning topics:

* Async EF Core queries
* Database-based CRUD
* Validation
* Service layer
* Repository pattern
* Authentication with JWT
* Logging
* Global exception handling
* Clean architecture basics
* AI and automation integrations

## Setup

Clone the repository:

```bash
git clone https://github.com/your-username/ai-job-application-tracker.git
cd ai-job-application-tracker
```

Navigate to the API project:

```bash
cd JobApplicationTracker.Api
```

Restore dependencies:

```bash
dotnet restore
```

Run the project:

```bash
dotnet run
```

Open Swagger in the browser:

```text
https://localhost:{PORT}/swagger
```

## Database

The project currently uses SQLite.

Connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=jobtracker.db"
}
```

EF Core migration commands used:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Roadmap

### Phase 1: REST API Basics

* [x] Create ASP.NET Core Web API project
* [x] Enable Swagger
* [x] Create ApplicationsController
* [x] Implement GET endpoint
* [x] Implement GET by id endpoint
* [x] Implement POST endpoint
* [x] Implement PUT endpoint
* [x] Implement DELETE endpoint

### Phase 2: Models, DTOs and EF Core

* [x] Create JobApplication model
* [x] Create CreateJobApplicationDto
* [x] Create UpdateJobApplicationDto
* [x] Install EF Core packages
* [x] Configure SQLite connection
* [x] Create AppDbContext
* [x] Create initial migration
* [x] Create SQLite database
* [ ] Replace in-memory list with EF Core database operations

### Phase 3: Backend Improvements

* [ ] Add validation
* [ ] Add service layer
* [ ] Add repository layer
* [ ] Add global exception handling
* [ ] Add structured logging
* [ ] Improve API response format

### Phase 4: Authentication

* [ ] Add user model
* [ ] Add register endpoint
* [ ] Add login endpoint
* [ ] Generate JWT token
* [ ] Protect job application endpoints

### Phase 5: AI and Automation

* [ ] Add CV and job posting analysis
* [ ] Add AI-powered cover letter generation
* [ ] Add n8n workflow automation
* [ ] Add LangGraph agent workflow
* [ ] Add MCP server integration

## Notes

This project is intentionally developed step by step.
The purpose is not only to build a working API, but also to understand the backend concepts behind each part of the system.

The project will continue to evolve from a basic REST API into a full AI-powered job application tracking platform.
