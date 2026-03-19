using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models.Dashboard;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    private readonly IDashboardService _dashboardService;
    private readonly ITokenStorageService _tokenStorage;

    public DashboardViewModel(IDashboardService dashboardService, ITokenStorageService tokenStorage)
    {
        _dashboardService = dashboardService;
        _tokenStorage = tokenStorage;
        Title = "Dashboard";
    }

    [ObservableProperty]
    private DashboardDto? _dashboard;

    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private bool _hasCourse;

    [ObservableProperty]
    private string _greeting = "Welcome!";

    [ObservableProperty]
    private string _userName = "Student";

    [RelayCommand]
    private async Task LoadDashboardAsync()
    {
        await ExecuteAsync(async () =>
        {
            // Load user info for greeting
            var user = await _tokenStorage.GetUserAsync();
            if (user != null)
            {
                UserName = user.FirstName;
                var hour = DateTime.Now.Hour;
                var timeGreeting = hour < 12 ? "Good Morning" : hour < 17 ? "Good Afternoon" : "Good Evening";
                Greeting = $"{timeGreeting}, {user.FirstName}!";
            }

            var result = await _dashboardService.GetDashboardAsync();
            if (result.Success && result.Data != null)
            {
                Dashboard = result.Data;
                HasCourse = !string.IsNullOrEmpty(result.Data.CourseName);
            }
            else
            {
                Dashboard = null;
                HasCourse = false;
            }
        });
        IsRefreshing = false;
    }

    [RelayCommand]
    private async Task GoToCoursesAsync()
    {
        await Shell.Current.GoToAsync("//main/courses");
    }
}
