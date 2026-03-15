using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using StudentOnboardingApp.Models;

namespace StudentOnboardingApp.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiService(ITokenStorageService tokenStorage)
    {
        _tokenStorage = tokenStorage;

#if DEBUG
        // Bypass SSL certificate validation for localhost development
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler)
#else
        _httpClient = new HttpClient()
#endif
        {
            BaseAddress = new Uri(Constants.ApiBaseUrl),
            Timeout = TimeSpan.FromSeconds(120)
        };
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<T?> PostAsync<T>(string endpoint, object data)
    {
        var json = JsonSerializer.Serialize(data, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseContent, _jsonOptions);
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseContent, _jsonOptions);
    }

    public async Task<T?> PostAuthenticatedAsync<T>(string endpoint, object data)
    {
        await SetAuthHeaderAsync();
        return await PostAsync<T>(endpoint, data);
    }

    public async Task<T?> GetAuthenticatedAsync<T>(string endpoint)
    {
        await SetAuthHeaderAsync();
        return await GetAsync<T>(endpoint);
    }

    private async Task SetAuthHeaderAsync()
    {
        var token = await _tokenStorage.GetAccessTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
