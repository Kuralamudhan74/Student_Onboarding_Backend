using StudentOnboardingApp.Models;

namespace StudentOnboardingApp.Services;

public interface IAuthService
{
    Task<ApiResponse<AuthResponse>?> LoginAsync(LoginRequest request);
    Task<ApiResponse<object>?> SignupAsync(SignupRequest request);
    Task<ApiResponse<string>?> VerifyOtpAsync(VerifyOtpRequest request);
    Task<ApiResponse<object>?> ResendOtpAsync(ResendOtpRequest request);
    Task<ApiResponse<object>?> ForgotPasswordAsync(ForgotPasswordRequest request);
    Task<ApiResponse<object>?> ResetPasswordAsync(ResetPasswordRequest request);
    Task<ApiResponse<object>?> ChangePasswordAsync(ChangePasswordRequest request);
    Task<ApiResponse<AuthResponse>?> RefreshTokenAsync();
    Task LogoutAsync();
    Task<bool> IsLoggedInAsync();
    Task<UserInfo?> GetCurrentUserAsync();
}
