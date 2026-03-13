using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models.Notification;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels;

public partial class NotificationsViewModel : BaseViewModel
{
    private readonly INotificationService _notificationService;

    public NotificationsViewModel(INotificationService notificationService)
    {
        _notificationService = notificationService;
        Title = "Notifications";
    }

    [ObservableProperty]
    private bool _isRefreshing;

    public ObservableCollection<NotificationDto> Notifications { get; } = [];

    [RelayCommand]
    private async Task LoadNotificationsAsync()
    {
        await ExecuteAsync(async () =>
        {
            var result = await _notificationService.GetNotificationsAsync();
            if (result.Success && result.Data != null)
            {
                Notifications.Clear();
                foreach (var notification in result.Data.OrderByDescending(n => n.CreatedAt))
                    Notifications.Add(notification);
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
        IsRefreshing = false;
    }

    [RelayCommand]
    private async Task MarkAsReadAsync(NotificationDto notification)
    {
        if (notification.IsRead) return;

        var result = await _notificationService.MarkAsReadAsync(notification.Id);
        if (result.Success)
        {
            notification.IsRead = true;
            // Refresh to update UI
            var index = Notifications.IndexOf(notification);
            if (index >= 0)
            {
                Notifications.RemoveAt(index);
                Notifications.Insert(index, notification);
            }
        }
    }
}
