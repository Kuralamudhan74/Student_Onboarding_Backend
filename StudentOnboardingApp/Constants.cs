namespace StudentOnboardingApp;

public static class Constants
{
<<<<<<< HEAD
    // API Configuration
    // For Windows: use localhost directly
    // For Android Emulator: use https://10.0.2.2:7292/api/
    public const string ApiBaseUrl = "https://localhost:7292/api/";

    // Secure Storage Keys
    public const string AccessTokenKey = "access_token";
    public const string RefreshTokenKey = "refresh_token";
    public const string TokenExpiryKey = "token_expiry";
    public const string UserJsonKey = "user_json";
    public const string FcmTokenKey = "fcm_token";

    // Named HttpClients
    public const string PublicApiClient = "PublicApi";
    public const string AuthenticatedApiClient = "AuthenticatedApi";

    // Route Names
    public static class Routes
    {
        public const string Login = "login";
        public const string Signup = "signup";
        public const string OtpVerification = "otp-verification";
        public const string ForgotPassword = "forgot-password";
        public const string ResetPassword = "reset-password";
        public const string ApprovalWaiting = "approval-waiting";
        public const string OnboardingInstructions = "onboarding-instructions";
        public const string CourseDetail = "course-detail";
        public const string EditProfile = "edit-profile";
        public const string ChangePassword = "change-password";
    }
=======
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
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
}
