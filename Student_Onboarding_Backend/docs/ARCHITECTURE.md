# Architecture Guide

## Overview

Student Onboarding Platform backend - .NET 8 Web API serving both a React admin website and .NET MAUI mobile app.

## Tech Stack
- **Runtime:** .NET 8
- **ORM:** Dapper (micro-ORM with raw SQL)
- **Dev Database:** PostgreSQL via Supabase
- **Prod Database:** SQL Server
- **Auth:** JWT + Refresh Tokens
- **Password Hashing:** BCrypt
- **Email:** MailKit (SMTP)
- **Logging:** Serilog
- **Validation:** FluentValidation

## Project Structure

```
Student Onboarding Platform/
  Controllers/         - API endpoints (thin, delegates to services)
  Models/
    Entities/          - Database entity classes (1:1 table mapping)
    DTOs/Auth/         - Request/response data transfer objects
    DTOs/Common/       - Shared DTOs (ApiResponse<T>)
    Enums/             - OtpType, UserRole, FailureReason
    Settings/          - Config POCO classes (AppSettings, JwtSettings, etc.)
  Services/
    Interfaces/        - Service contracts
    Implementations/   - Service logic
  Data/
    DbConnectionFactory.cs    - Database connection toggle (Postgres/SQL Server)
    Repositories/
      Interfaces/      - Repository contracts
      Implementations/ - Dapper SQL queries
  Middleware/          - ExceptionHandlingMiddleware
  Extensions/          - DI registration, JWT setup, ClaimsPrincipal helpers
  Helpers/             - OtpGenerator
  Validators/          - FluentValidation validators (one per DTO)
```

## Architecture Layers

```
Controller -> AuthService (orchestrator) -> Domain Services -> Repositories -> DbConnectionFactory -> Database
```

- **Controller**: Thin. Extracts HTTP context (IP, UserAgent), calls AuthService, returns result.
- **AuthService**: Orchestrates auth flows. Coordinates multiple domain services.
- **Domain Services**: UserService, TokenService, OtpService, EmailService, SessionService, LoginAttemptService. Each owns a single domain.
- **Repositories**: Raw Dapper SQL. One repository per table.
- **DbConnectionFactory**: Returns `NpgsqlConnection` or `SqlConnection` based on `IsProduction` flag.

## Database Toggle

`appsettings.json` contains `AppSettings.IsProduction`:
- `false` -> PostgreSQL (Supabase) via Npgsql
- `true` -> SQL Server via Microsoft.Data.SqlClient

GUIDs are generated in C# (`Guid.NewGuid()`), timestamps use `DateTime.UtcNow` - avoiding database-specific functions in queries.

## Email Service Abstraction

`IEmailService` interface with `SmtpEmailService` implementation (MailKit).
To swap providers: create new implementation (e.g., `SendGridEmailService`), change one line in `ServiceCollectionExtensions.cs`.

## Security Features
- BCrypt password hashing (work factor 12)
- JWT access tokens (15 min expiry, configurable)
- Refresh tokens (7 day expiry, stored in UserSessions)
- OTP brute-force protection (5 attempts max)
- Login rate limiting (5 failed attempts per 15-min window)
- Session revocation on password change/reset
- Email enumeration prevention (forgot-password/resend-otp always return success)
- Soft delete (IsDeleted flag instead of hard delete)
