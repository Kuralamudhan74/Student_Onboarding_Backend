using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(OtpCode), "otpCode")]
public partial class ResetPasswordViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public ResetPasswordViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string otpCode = string.Empty;

    [ObservableProperty]
    private string newPassword = string.Empty;

    [ObservableProperty]
    private string confirmPassword = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private bool isPasswordVisible;

    [ObservableProperty]
    private bool resetSuccess;

    public bool HasMinLength => NewPassword.Length >= 8;
    public bool HasUppercase => NewPassword.Any(char.IsUpper);
    public bool HasLowercase => NewPassword.Any(char.IsLower);
    public bool HasDigit => NewPassword.Any(char.IsDigit);
    public bool HasSpecialChar => NewPassword.Any(c => !char.IsLetterOrDigit(c));

    partial void OnNewPasswordChanged(string value)
    {
        OnPropertyChanged(nameof(HasMinLength));
        OnPropertyChanged(nameof(HasUppercase));
        OnPropertyChanged(nameof(HasLowercase));
        OnPropertyChanged(nameof(HasDigit));
        OnPropertyChanged(nameof(HasSpecialChar));
    }

    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    private async Task ResetPasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 8)
        {
            ErrorMessage = "Password must be at least 8 characters";
            return;
        }
        if (NewPassword != ConfirmPassword)
        {
            ErrorMessage = "Passwords do not match";
            return;
        }

        ErrorMessage = null;
        IsBusy = true;

        try
        {
            var response = await _authService.ResetPasswordAsync(new ResetPasswordRequest
            {
                Email = Email,
                OtpCode = OtpCode,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmPassword
            });

            if (response?.Success == true)
            {
                ResetSuccess = true;
                await Task.Delay(2000);
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                ErrorMessage = response?.Message ?? "Failed to reset password.";
            }
        }
        catch (Exception)
        {
            ErrorMessage = "Unable to reset password. Please try again.";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
