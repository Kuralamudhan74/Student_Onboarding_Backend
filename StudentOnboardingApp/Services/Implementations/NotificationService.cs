using System.Net.Http.Json;
using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Notification;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.Services.Implementations;

public class NotificationService : INotificationService
{
    private readonly HttpClient _client;

    public NotificationService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(Constants.AuthenticatedApiClient);
    }

    public async Task<ApiResponse<List<NotificationDto>>> GetNotificationsAsync()
    {
        try
        {
            var response = await _client.GetAsync("student/notifications");
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<NotificationDto>>>();
            return result ?? new ApiResponse<List<NotificationDto>> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<NotificationDto>> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> MarkAsReadAsync(Guid notificationId)
    {
        try
        {
            var response = await _client.PutAsync($"student/notifications/{notificationId}/read", null);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }

    public async Task<ApiResponse<string>> RegisterDeviceTokenAsync(string fcmToken)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("student/notifications/register-device", new { Token = fcmToken });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { Success = false, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new ApiResponse<string> { Success = false, Message = ex.Message };
        }
    }

    public async Task<int> GetUnreadCountAsync()
    {
        try
        {
            var result = await GetNotificationsAsync();
            if (result.Success && result.Data != null)
                return result.Data.Count(n => !n.IsRead);
            return 0;
        }
        catch
        {
            return 0;
        }
    }
}
