namespace StudentOnboardingApp;

public static class Constants
{
    // Change this to your backend URL
    public const string ApiBaseUrl = "https://localhost:7292/api/";

    // Auth endpoints (relative to ApiBaseUrl — no leading slash!)
    public const string LoginEndpoint = "Auth/login";
    public const string SignupEndpoint = "Auth/signup";
    public const string VerifyOtpEndpoint = "Auth/verify-otp";
    public const string ResendOtpEndpoint = "Auth/resend-otp";
    public const string ForgotPasswordEndpoint = "Auth/forgot-password";
    public const string ResetPasswordEndpoint = "Auth/reset-password";
    public const string ChangePasswordEndpoint = "Auth/change-password";
    public const string RefreshTokenEndpoint = "Auth/refresh-token";
    public const string LogoutEndpoint = "Auth/logout";

    // Secure storage keys
    public const string AccessTokenKey = "access_token";
    public const string RefreshTokenKey = "refresh_token";
    public const string UserDataKey = "user_data";
}
