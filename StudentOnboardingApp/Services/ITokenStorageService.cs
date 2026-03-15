namespace StudentOnboardingApp.Services;

public interface ITokenStorageService
{
    Task SaveTokensAsync(string accessToken, string refreshToken);
    Task<string?> GetAccessTokenAsync();
    Task<string?> GetRefreshTokenAsync();
    Task SaveUserDataAsync(string userData);
    Task<string?> GetUserDataAsync();
    Task ClearAllAsync();
}
