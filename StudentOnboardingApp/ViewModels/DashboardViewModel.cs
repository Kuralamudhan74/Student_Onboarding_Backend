using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    }
}
