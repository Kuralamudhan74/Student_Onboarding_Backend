using CommunityToolkit.Mvvm.Messaging;
using StudentOnboardingApp.Handlers;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp;

public partial class App : Application
{
    private readonly ITokenStorageService _tokenStorage;

    public App(ITokenStorageService tokenStorage)
    {
        InitializeComponent();
        _tokenStorage = tokenStorage;

        // Listen for forced logout from AuthenticatedHttpClientHandler
        WeakReferenceMessenger.Default.Register<LogoutMessage>(this, async (_, _) =>
        {
            await Shell.Current.GoToAsync($"///{Constants.Routes.Login}");
        });
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

        window.Created += async (_, _) =>
        {
            // Small delay to let Shell initialize
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
            }
            // If not authenticated, stays on login page (default route)
        }
        catch
        {
            // If any error, stay on login
        }
    }
}
