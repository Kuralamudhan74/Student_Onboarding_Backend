using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(OtpType), "otpType")]
public partial class OtpVerificationViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public OtpVerificationViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string otpType = "EmailVerification";

    [ObservableProperty]
    private string digit1 = string.Empty;

    [ObservableProperty]
    private string digit2 = string.Empty;

    [ObservableProperty]
    private string digit3 = string.Empty;

    [ObservableProperty]
    private string digit4 = string.Empty;

    [ObservableProperty]
    private string digit5 = string.Empty;

    [ObservableProperty]
    private string digit6 = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private string? successMessage;

    [ObservableProperty]
    private bool canResend = true;

    [ObservableProperty]
    private int resendCountdown;

    private string FullOtp => $"{Digit1}{Digit2}{Digit3}{Digit4}{Digit5}{Digit6}";

    [RelayCommand]
    private async Task VerifyOtpAsync()
    {
        if (FullOtp.Length != 6)
        {
            ErrorMessage = "Please enter the complete 6-digit code";
            return;
        }

        ErrorMessage = null;
        SuccessMessage = null;
        IsBusy = true;

        try
        {
            var response = await _authService.VerifyOtpAsync(new VerifyOtpRequest
            {
                Email = Email,
                OtpCode = FullOtp,
                OtpType = OtpType
            });

            if (response?.Success == true)
            {
                if (OtpType == "PasswordReset")
                {
                    await Shell.Current.GoToAsync($"../reset-password?email={Uri.EscapeDataString(Email)}&otpCode={FullOtp}");
                }
                else
                {
                    // Email verified — go to login so user can sign in
                    await Shell.Current.GoToAsync("//login");
                    await Shell.Current.DisplayAlert("Verified", "Email verified successfully! Please sign in.", "OK");
                }
            }
            else
            {
                ErrorMessage = response?.Message ?? "Invalid OTP. Please try again.";
            }
        }
        catch (Exception)
        {
            ErrorMessage = "Unable to verify. Please check your connection.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ResendOtpAsync()
    {
        if (!CanResend) return;

        IsBusy = true;
        ErrorMessage = null;

        try
        {
            var response = await _authService.ResendOtpAsync(new ResendOtpRequest
            {
                Email = Email,
                OtpType = OtpType
            });

            SuccessMessage = "A new code has been sent to your email";
            StartResendCountdown();
        }
        catch (Exception)
        {
            ErrorMessage = "Failed to resend code. Please try again.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async void StartResendCountdown()
    {
        CanResend = false;
        ResendCountdown = 60;

        while (ResendCountdown > 0)
        {
            await Task.Delay(1000);
            ResendCountdown--;
        }

        CanResend = true;
    }
}
