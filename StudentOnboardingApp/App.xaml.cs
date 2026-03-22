using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using StudentOnboardingApp.Handlers;
using StudentOnboardingApp.Services.Implementations;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp;

public partial class App : Application
{
    private readonly ITokenStorageService _tokenStorage;
    private readonly NotificationPollingService _pollingService;
    private bool _isLoggingOut;

    public App(ITokenStorageService tokenStorage, NotificationPollingService pollingService)
    {
        InitializeComponent();
        _tokenStorage = tokenStorage;
        _pollingService = pollingService;

        // Listen for forced logout from AuthenticatedHttpClientHandler
        WeakReferenceMessenger.Default.Register<LogoutMessage>(this, async (_, _) =>
        {
            if (_isLoggingOut) return; // prevent cascade
            _isLoggingOut = true;

            _pollingService.Stop();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Shell.Current.GoToAsync($"///{Constants.Routes.Login}");
                }
                catch { /* navigation may fail during startup */ }
                finally
                {
                    _isLoggingOut = false;
                }
            });
        });

        // Listen for new notifications and show in-app toast
        WeakReferenceMessenger.Default.Register<NewNotificationsMessage>(this, async (_, msg) =>
        {
            if (_isLoggingOut) return;
            foreach (var notification in msg.NewNotifications.Take(3))
            {
                try
                {
                    var snackbar = Snackbar.Make(
                        $"\ud83d\udd14 {notification.Title}: {notification.Body}",
                        duration: TimeSpan.FromSeconds(4),
                        visualOptions: new SnackbarOptions
                        {
                            BackgroundColor = Color.FromArgb("#5B5BD6"),
                            TextColor = Colors.White,
                            CornerRadius = 12,
                            Font = Microsoft.Maui.Font.SystemFontOfSize(13, FontWeight.Semibold),
                        });
                    await snackbar.Show();
                    await Task.Delay(500);
                }
                catch { }
            }
        });

        // Listen for badge count updates
        WeakReferenceMessenger.Default.Register<BadgeCountMessage>(this, (_, msg) =>
        {
            if (_isLoggingOut) return;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Shell.Current is AppShell appShell)
                    appShell.UpdateNotificationBadge(msg.Count);
            });
        });
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

        window.Created += async (_, _) =>
        {
            await Task.Delay(200);
            await NavigateBasedOnAuthStateAsync();
        };

        return window;
    }

    private async Task NavigateBasedOnAuthStateAsync()
    {
        try
        {
            var isAuthenticated = await _tokenStorage.IsAuthenticatedAsync();
            if (isAuthenticated)
            {
                await Shell.Current.GoToAsync("//main/dashboard");
                _pollingService.Start(TimeSpan.FromSeconds(15));
            }
        }
        catch { }
    }

    public void StartNotificationPolling()
    {
        _isLoggingOut = false;
        _pollingService.Start(TimeSpan.FromSeconds(15));
    }

    public void StopNotificationPolling()
    {
        _pollingService.Stop();
    }
}
