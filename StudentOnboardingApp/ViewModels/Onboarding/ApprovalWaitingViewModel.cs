using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels.Onboarding;

public partial class ApprovalWaitingViewModel : BaseViewModel
{
    private readonly IOnboardingService _onboardingService;
    private PeriodicTimer? _pollTimer;
    private CancellationTokenSource? _pollCts;

    public ApprovalWaitingViewModel(IOnboardingService onboardingService)
    {
        _onboardingService = onboardingService;
        Title = "Application Status";
    }

    [ObservableProperty]
    private string _statusMessage = "Your application is under review. Please wait for admin approval.";

    [ObservableProperty]
    private bool _isBlocked;

    [RelayCommand]
    private async Task StartPollingAsync()
    {
        _pollCts = new CancellationTokenSource();
        _pollTimer = new PeriodicTimer(TimeSpan.FromSeconds(30));

        // Check immediately
        await CheckStatusAsync();

        try
        {
            while (await _pollTimer.WaitForNextTickAsync(_pollCts.Token))
            {
                await CheckStatusAsync();
            }
        }
        catch (OperationCanceledException)
        {
            // Polling cancelled
        }
    }

    private async Task CheckStatusAsync()
    {
        var result = await _onboardingService.GetApprovalStatusAsync();
        if (result.Success && result.Data != null)
        {
            switch (result.Data)
            {
                case "Approved":
                    StopPolling();
                    await Shell.Current.GoToAsync(Constants.Routes.OnboardingInstructions);
                    break;
                case "Blocked":
                    IsBlocked = true;
                    StatusMessage = "Your application has been blocked. Please contact the administrator.";
                    StopPolling();
                    break;
                case "Pending":
                default:
                    StatusMessage = "Your application is under review. Please wait for admin approval.";
                    break;
            }
        }
    }

    public void StopPolling()
    {
        _pollCts?.Cancel();
        _pollTimer?.Dispose();
    }
}
