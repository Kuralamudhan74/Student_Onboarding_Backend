using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public DashboardViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string userInitials = string.Empty;

    [ObservableProperty]
    private string greeting = string.Empty;

    [ObservableProperty]
    private bool isLoading = true;

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        IsLoading = true;
        try
        {
            var user = await _authService.GetCurrentUserAsync();
            if (user != null)
            {
                UserName = user.FirstName;
                UserInitials = user.Initials;
            }

            var hour = DateTime.Now.Hour;
            Greeting = hour switch
            {
                < 12 => "Good Morning",
                < 17 => "Good Afternoon",
                _ => "Good Evening"
            };
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        try
        {
            await _authService.LogoutAsync();
        }
        finally
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}
