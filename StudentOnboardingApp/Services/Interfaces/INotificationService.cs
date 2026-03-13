using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Notification;

namespace StudentOnboardingApp.Services.Interfaces;

public interface INotificationService
{
    Task<ApiResponse<List<NotificationDto>>> GetNotificationsAsync();
    Task<ApiResponse<string>> MarkAsReadAsync(Guid notificationId);
    Task<ApiResponse<string>> RegisterDeviceTokenAsync(string fcmToken);
}
