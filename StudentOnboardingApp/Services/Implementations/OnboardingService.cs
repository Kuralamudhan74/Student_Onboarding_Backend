using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Onboarding;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class OnboardingService : IOnboardingService
{
    private readonly HttpClient _client;

    public OnboardingService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<string>> GetApprovalStatusAsync()
    {
        try
        {
            var response = await _client.GetAsync("onboarding/approval-status");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<List<OnboardingInstructionDto>>> GetInstructionsAsync()
    {
        try
        {
            var response = await _client.GetAsync("onboarding/instructions");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<OnboardingInstructionDto>>>();
            return result ?? new ApiResponse<List<OnboardingInstructionDto>> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<OnboardingInstructionDto>> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> AcceptOnboardingAsync()
    {
        try
        {
            var response = await _client.PostAsync("onboarding/accept", null);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }
}
