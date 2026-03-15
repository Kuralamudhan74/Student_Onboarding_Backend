using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

public partial class ForgotPasswordViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public ForgotPasswordViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private bool emailSent;

    [RelayCommand]
    private async Task SendResetEmailAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            ErrorMessage = "Please enter a valid email address";
            return;
        }

        ErrorMessage = null;
        IsBusy = true;

        try
        {
            var response = await _authService.ForgotPasswordAsync(new ForgotPasswordRequest
            {
                Email = Email.Trim().ToLower()
            });

            // Always navigate to OTP regardless of response (prevents email enumeration)
            EmailSent = true;
            await Task.Delay(1500);
            await Shell.Current.GoToAsync($"../otp-verification?email={Uri.EscapeDataString(Email.Trim().ToLower())}&otpType=PasswordReset");
        }
        catch (Exception)
        {
            ErrorMessage = "Unable to send reset email. Please try again.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
