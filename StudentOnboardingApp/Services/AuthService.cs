using System.Text.Json;
using StudentOnboardingApp.Models;

namespace StudentOnboardingApp.Services;

public class AuthService : IAuthService
{
    private readonly IApiService _api;
    private readonly ITokenStorageService _tokenStorage;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public AuthService(IApiService api, ITokenStorageService tokenStorage)
    {
        _api = api;
        _tokenStorage = tokenStorage;
    }

    public async Task<ApiResponse<AuthResponse>?> LoginAsync(LoginRequest request)
    {
        request.DeviceName = DeviceInfo.Current.Name;
        request.DeviceType = DeviceInfo.Current.Platform == DevicePlatform.Android ? "Android" :
                             DeviceInfo.Current.Platform == DevicePlatform.iOS ? "iOS" : "Web";

        var response = await _api.PostAsync<ApiResponse<AuthResponse>>(Constants.LoginEndpoint, request);
        if (response?.Success == true && response.Data != null)
        {
            await _tokenStorage.SaveTokensAsync(response.Data.AccessToken, response.Data.RefreshToken);
            await _tokenStorage.SaveUserDataAsync(JsonSerializer.Serialize(response.Data.User, _jsonOptions));
        }
        return response;
    }

    public async Task<ApiResponse<object>?> SignupAsync(SignupRequest request)
    {
        return await _api.PostAsync<ApiResponse<object>>(Constants.SignupEndpoint, request);
    }

    public async Task<ApiResponse<string>?> VerifyOtpAsync(VerifyOtpRequest request)
    {
        return await _api.PostAsync<ApiResponse<string>>(Constants.VerifyOtpEndpoint, request);
    }

    public async Task<ApiResponse<object>?> ResendOtpAsync(ResendOtpRequest request)
    {
        return await _api.PostAsync<ApiResponse<object>>(Constants.ResendOtpEndpoint, request);
    }

    public async Task<ApiResponse<object>?> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        return await _api.PostAsync<ApiResponse<object>>(Constants.ForgotPasswordEndpoint, request);
    }

    public async Task<ApiResponse<object>?> ResetPasswordAsync(ResetPasswordRequest request)
    {
        return await _api.PostAsync<ApiResponse<object>>(Constants.ResetPasswordEndpoint, request);
    }

    public async Task<ApiResponse<object>?> ChangePasswordAsync(ChangePasswordRequest request)
    {
        return await _api.PostAuthenticatedAsync<ApiResponse<object>>(Constants.ChangePasswordEndpoint, request);
    }

    public async Task<ApiResponse<AuthResponse>?> RefreshTokenAsync()
    {
        var refreshToken = await _tokenStorage.GetRefreshTokenAsync();
        if (string.IsNullOrEmpty(refreshToken)) return null;

        var response = await _api.PostAsync<ApiResponse<AuthResponse>>(
            Constants.RefreshTokenEndpoint,
            new RefreshTokenRequest { RefreshToken = refreshToken });

        if (response?.Success == true && response.Data != null)
        {
            await _tokenStorage.SaveTokensAsync(response.Data.AccessToken, response.Data.RefreshToken);
        }
        return response;
    }

    public async Task LogoutAsync()
    {
        try
        {
            var refreshToken = await _tokenStorage.GetRefreshTokenAsync();
            if (!string.IsNullOrEmpty(refreshToken))
            {
                await _api.PostAuthenticatedAsync<ApiResponse<object>>(
                    Constants.LogoutEndpoint,
                    new RefreshTokenRequest { RefreshToken = refreshToken });
            }
        }
        finally
        {
            await _tokenStorage.ClearAllAsync();
        }
    }

    public async Task<bool> IsLoggedInAsync()
    {
        var token = await _tokenStorage.GetAccessTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task<UserInfo?> GetCurrentUserAsync()
    {
        var userData = await _tokenStorage.GetUserDataAsync();
        if (string.IsNullOrEmpty(userData)) return null;
        return JsonSerializer.Deserialize<UserInfo>(userData, _jsonOptions);
    }
}
