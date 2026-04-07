using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Faq;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class FaqService : IFaqService
{
    private readonly HttpClient _client;

    public FaqService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<List<FaqDto>>> GetFaqsAsync()
    {
        try
        {
            var response = await _client.GetAsync("Student/faqs");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<FaqDto>>>();
            return result ?? new ApiResponse<List<FaqDto>> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<FaqDto>> { Success = false, Message = ex.Message };
        }
    }
}
