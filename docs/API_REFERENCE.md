# API Reference

Base URL: `https://localhost:<port>/api`

All responses follow the format:
```json
{
  "success": true/false,
  "message": "string",
  "data": {},
  "errors": []
}
```

---

## POST /api/auth/signup
Register a new student account.

**Auth Required:** No

**Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "phoneNumber": "+1234567890",
  "password": "SecureP@ss1",
  "confirmPassword": "SecureP@ss1"
}
```

**Success Response (200):**
```json
{
  "success": true,
  "message": "Signup successful. Please verify your email with the OTP sent.",
  "data": "Signup successful. Please verify your email with the OTP sent."
}
```

**Validation Rules:**
- FirstName: required, max 100 chars
- LastName: required, max 100 chars
- Email: required, valid email, max 255 chars
- PhoneNumber: optional, max 20 chars
- Password: min 8 chars, 1 uppercase, 1 lowercase, 1 digit, 1 special char
- ConfirmPassword: must match Password

---

## POST /api/auth/login
Login with email and password.

**Auth Required:** No

**Request Body:**
```json
{
  "email": "john@example.com",
  "password": "SecureP@ss1",
  "deviceType": "Web",
  "deviceName": "Chrome Windows"
}
```

**Success Response (200):**
```json
{
  "success": true,
  "message": "Login successful.",
  "data": {
    "accessToken": "eyJhbG...",
    "refreshToken": "base64string...",
    "expiresAt": "2026-03-05T12:15:00Z",
    "user": {
      "id": "guid",
      "firstName": "John",
      "lastName": "Doe",
      "email": "john@example.com",
      "phoneNumber": "+1234567890",
      "emailVerified": true,
      "role": "Student"
    }
  }
}
```

**Rate Limiting:** 5 failed attempts per 15-minute window locks the account temporarily.

---

## POST /api/auth/verify-otp
Verify an OTP code (email verification or password reset).

**Auth Required:** No

**Request Body:**
```json
{
  "email": "john@example.com",
  "otpCode": "123456",
  "otpType": "EmailVerification"
}
```

**OTP Types:** `EmailVerification`, `PhoneVerification`, `PasswordReset`, `LoginVerification`

---

## POST /api/auth/resend-otp
Resend an OTP code.

**Auth Required:** No

**Request Body:**
```json
{
  "email": "john@example.com",
  "otpType": "EmailVerification"
}
```

**Note:** Always returns success to prevent email enumeration.

---

## POST /api/auth/forgot-password
Request a password reset OTP.

**Auth Required:** No

**Request Body:**
```json
{
  "email": "john@example.com"
}
```

**Note:** Always returns success to prevent email enumeration.

---

## POST /api/auth/reset-password
Reset password using OTP.

**Auth Required:** No

**Request Body:**
```json
{
  "email": "john@example.com",
  "otpCode": "123456",
  "newPassword": "NewSecureP@ss1",
  "confirmNewPassword": "NewSecureP@ss1"
}
```

**Side Effects:** Revokes all active sessions for the user.

---

## POST /api/auth/change-password
Change password for logged-in user.

**Auth Required:** Yes (JWT Bearer Token)

**Headers:**
```
Authorization: Bearer <access_token>
```

**Request Body:**
```json
{
  "currentPassword": "OldP@ss1",
  "newPassword": "NewP@ss1",
  "confirmNewPassword": "NewP@ss1"
}
```

**Side Effects:** Revokes all sessions. User must log in again.

---

## POST /api/auth/refresh-token
Get a new access token using a refresh token.

**Auth Required:** No

**Request Body:**
```json
{
  "refreshToken": "base64string..."
}
```

**Success Response (200):**
```json
{
  "success": true,
  "message": "Token refreshed successfully.",
  "data": {
    "accessToken": "eyJhbG...",
    "refreshToken": "base64string...",
    "expiresAt": "2026-03-05T12:15:00Z",
    "user": { ... }
  }
}
```

---

## POST /api/auth/logout
Revoke the current session.

**Auth Required:** Yes (JWT Bearer Token)

**Headers:**
```
Authorization: Bearer <access_token>
```

**Request Body:**
```json
{
  "refreshToken": "base64string..."
}
```
