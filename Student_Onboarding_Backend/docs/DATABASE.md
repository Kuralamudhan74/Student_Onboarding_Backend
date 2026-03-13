# Database Documentation

## Tables Overview

| Table | Purpose | FK |
|-------|---------|-----|
| Users | Primary user accounts | - |
| UserSessions | Refresh tokens and device sessions | Users.Id |
| OtpVerifications | OTP records for verification flows | Users.Id |
| LoginAttempts | Login attempt tracking for security | - |
| UserSocialLogins | Social login provider links (future) | Users.Id |

## Schema Details

### Users
| Column | Postgres | SQL Server | Notes |
|--------|----------|------------|-------|
| Id | UUID PK | UNIQUEIDENTIFIER PK | Generated in C# |
| FirstName | VARCHAR(100) | NVARCHAR(100) | |
| LastName | VARCHAR(100) | NVARCHAR(100) | |
| Email | VARCHAR(255) UNIQUE | NVARCHAR(255) UNIQUE | Stored lowercase |
| PhoneNumber | VARCHAR(20) UNIQUE | NVARCHAR(20) UNIQUE | Optional |
| PasswordHash | TEXT | NVARCHAR(MAX) | BCrypt hash |
| EmailVerified | BOOLEAN | BIT | Set true after OTP |
| PhoneVerified | BOOLEAN | BIT | Future use |
| IsActive | BOOLEAN | BIT | Admin can deactivate |
| IsDeleted | BOOLEAN | BIT | Soft delete |
| Role | VARCHAR(20) | NVARCHAR(20) | Default: 'Student' |
| PasswordUpdatedAt | TIMESTAMP | DATETIME2 | For session invalidation |
| CreatedAt | TIMESTAMP | DATETIME2 | Auto-set |
| UpdatedAt | TIMESTAMP | DATETIME2 | Set on updates |
| LastLoginAt | TIMESTAMP | DATETIME2 | Updated on login |

### UserSessions
| Column | Type | Notes |
|--------|------|-------|
| Id | UUID/UNIQUEIDENTIFIER | PK |
| UserId | UUID/UNIQUEIDENTIFIER | FK -> Users.Id |
| RefreshToken | TEXT/NVARCHAR(MAX) | Base64 encoded |
| DeviceType | VARCHAR(20) | Web, Android, iOS |
| DeviceName | VARCHAR(200) | Browser/device info |
| IpAddress | VARCHAR(50) | Client IP |
| UserAgent | TEXT | Browser user agent |
| ExpiresAt | TIMESTAMP/DATETIME2 | Token expiration |
| IsRevoked | BOOLEAN/BIT | Revoked on logout/password change |
| CreatedAt | TIMESTAMP/DATETIME2 | Auto-set |
| LastUsedAt | TIMESTAMP/DATETIME2 | Updated on token refresh |

### OtpVerifications
| Column | Type | Notes |
|--------|------|-------|
| Id | UUID/UNIQUEIDENTIFIER | PK |
| UserId | UUID/UNIQUEIDENTIFIER | FK -> Users.Id (nullable) |
| Email | VARCHAR(255) | Target email |
| PhoneNumber | VARCHAR(20) | Target phone (future) |
| OtpCode | VARCHAR(10) | 6-digit code |
| OtpType | VARCHAR(50) | EmailVerification, PasswordReset, etc. |
| AttemptCount | INT | Incremented on each attempt |
| MaxAttempts | INT | Default 5 |
| ExpiresAt | TIMESTAMP/DATETIME2 | 5 min from creation |
| IsUsed | BOOLEAN/BIT | Marked after successful verification |
| CreatedAt | TIMESTAMP/DATETIME2 | Auto-set |

### LoginAttempts
| Column | Type | Notes |
|--------|------|-------|
| Id | UUID/UNIQUEIDENTIFIER | PK |
| Email | VARCHAR(255) | Attempted email |
| IpAddress | VARCHAR(50) | Client IP |
| UserAgent | TEXT | Browser info |
| IsSuccessful | BOOLEAN/BIT | Success/failure flag |
| FailureReason | VARCHAR(100) | InvalidPassword, UserNotFound, etc. |
| AttemptedAt | TIMESTAMP/DATETIME2 | Auto-set |

## Indexes
- `idx_users_email` - Users(Email)
- `idx_users_phone` - Users(PhoneNumber)
- `idx_sessions_userid` - UserSessions(UserId)
- `idx_sessions_refreshtoken` - UserSessions(RefreshToken)
- `idx_otp_email` - OtpVerifications(Email)
- `idx_otp_phone` - OtpVerifications(PhoneNumber)
- `idx_login_email` - LoginAttempts(Email)
- `idx_login_attemptedAt` - LoginAttempts(AttemptedAt)

## SQL Scripts Location
- PostgreSQL: `sql/postgres/` (numbered 001-006)
- SQL Server: `sql/sqlserver/` (numbered 001-006)

Run scripts in numerical order. Each script is idempotent (uses IF NOT EXISTS / CREATE IF NOT EXISTS).
