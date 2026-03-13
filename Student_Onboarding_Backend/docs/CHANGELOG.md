# Changelog

All notable changes to the Student Onboarding Platform will be documented here.

## [0.1.0] - 2026-03-05

### Added
- Project scaffolding with .NET 8 Web API
- Authentication system with full signup/login flow
  - POST /api/auth/signup - User registration
  - POST /api/auth/login - Email/password login
  - POST /api/auth/verify-otp - OTP verification
  - POST /api/auth/resend-otp - Resend OTP
  - POST /api/auth/forgot-password - Password reset request
  - POST /api/auth/reset-password - Reset password with OTP
  - POST /api/auth/change-password - Change password (authenticated)
  - POST /api/auth/refresh-token - JWT token refresh
  - POST /api/auth/logout - Session revocation
- JWT + Refresh Token authentication
- BCrypt password hashing
- OTP verification system with brute-force protection
- Login attempt tracking and rate limiting (5 attempts per 15 min)
- Dual database support via DbConnectionFactory
  - PostgreSQL (Supabase) for development
  - SQL Server for production
  - Toggled by AppSettings.IsProduction boolean
- Dapper micro-ORM for data access
- Serilog structured logging (Console + File sinks)
- SMTP email service via MailKit with IEmailService abstraction
- FluentValidation for request validation
- Global exception handling middleware
- CORS policy for frontend/mobile access
- SQL scripts for both PostgreSQL and SQL Server
- Project documentation (SETUP, API_REFERENCE, ARCHITECTURE, DATABASE)

### Database Tables
- Users
- UserSessions
- OtpVerifications
- LoginAttempts
- UserSocialLogins (future use)
