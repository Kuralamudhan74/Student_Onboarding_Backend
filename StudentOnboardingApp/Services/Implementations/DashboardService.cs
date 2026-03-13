using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Dashboard;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class DashboardService : IDashboardService
{
    private readonly HttpClient _client;

    public DashboardService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<DashboardDto>> GetDashboardAsync()
    {
        try
        {
            var response = await _client.GetAsync("dashboard");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<DashboardDto>>();
            return result ?? new ApiResponse<DashboardDto> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<DashboardDto> { Success = false, Message = ex.Message };
        }
    }
}
