namespace StudentOnboardingApp.Services;

public interface IApiService
{
    Task<T?> PostAsync<T>(string endpoint, object data);
    Task<T?> GetAsync<T>(string endpoint);
    Task<T?> PostAuthenticatedAsync<T>(string endpoint, object data);
    Task<T?> GetAuthenticatedAsync<T>(string endpoint);
}
