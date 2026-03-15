using StudentOnboardingApp;

namespace StudentOnboardingApp.Services;

public class TokenStorageService : ITokenStorageService
{
    public async Task SaveTokensAsync(string accessToken, string refreshToken)
    {
        await SecureStorage.Default.SetAsync(Constants.AccessTokenKey, accessToken);
        await SecureStorage.Default.SetAsync(Constants.RefreshTokenKey, refreshToken);
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        return await SecureStorage.Default.GetAsync(Constants.AccessTokenKey);
    }

    public async Task<string?> GetRefreshTokenAsync()
    {
        return await SecureStorage.Default.GetAsync(Constants.RefreshTokenKey);
    }

    public async Task SaveUserDataAsync(string userData)
    {
        await SecureStorage.Default.SetAsync(Constants.UserDataKey, userData);
    }

    public async Task<string?> GetUserDataAsync()
    {
        return await SecureStorage.Default.GetAsync(Constants.UserDataKey);
    }

    public Task ClearAllAsync()
    {
        SecureStorage.Default.RemoveAll();
        return Task.CompletedTask;
    }
}
