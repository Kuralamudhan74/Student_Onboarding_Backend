using Student_Onboarding_Platform.Models.DTOs.Admin;
using Student_Onboarding_Platform.Models.DTOs.Common;
using Student_Onboarding_Platform.Models.Entities;

namespace Student_Onboarding_Platform.Services.Interfaces;

public interface INotificationService
{
    Task NotifyAdminsOfNewRegistrationAsync(User student);
    Task<ApiResponse<List<NotificationResponse>>> GetNotificationsAsync(Guid adminId);
    Task<ApiResponse<UnreadCountResponse>> GetUnreadCountAsync(Guid adminId);
    Task<ApiResponse<string>> MarkAsReadAsync(Guid notificationId, Guid adminId);
}
