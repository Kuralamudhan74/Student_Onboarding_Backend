using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Course;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly HttpClient _client;

    public CourseService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<List<CourseDto>>> GetCoursesAsync()
    {
        try
        {
            var response = await _client.GetAsync("course");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<CourseDto>>>();
            return result ?? new ApiResponse<List<CourseDto>> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<CourseDto>> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<CourseDetailDto>> GetCourseDetailAsync(Guid courseId)
    {
        try
        {
            var response = await _client.GetAsync($"course/{courseId}");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<CourseDetailDto>>();
            return result ?? new ApiResponse<CourseDetailDto> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<CourseDetailDto> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> ApplyForCourseAsync(CourseApplicationRequest request)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("student/courses/register", request);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }
}
