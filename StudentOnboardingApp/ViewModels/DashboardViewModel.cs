using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
<<<<<<< HEAD
using StudentOnboardingApp.Models.Dashboard;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    private readonly IDashboardService _dashboardService;

    public DashboardViewModel(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
        Title = "Dashboard";
    }

    [ObservableProperty]
    private DashboardDto? _dashboard;

    [ObservableProperty]
    private bool _isRefreshing;

    [RelayCommand]
    private async Task LoadDashboardAsync()
    {
        await ExecuteAsync(async () =>
        {
            var result = await _dashboardService.GetDashboardAsync();
            if (result.Success && result.Data != null)
            {
                Dashboard = result.Data;
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
        IsRefreshing = false;
=======
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
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
    }
}
