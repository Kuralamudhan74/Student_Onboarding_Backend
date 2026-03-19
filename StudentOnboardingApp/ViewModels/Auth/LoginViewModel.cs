using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models.Auth;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels.Auth;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        Title = "Login";
    }

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private bool _isPasswordVisible;

    [RelayCommand]
    private async Task LoginAsync()
    {
        await ExecuteAsync(async () =>
        {
            var request = new LoginRequest
            {
                Email = Email,
                Password = Password
            };

            var result = await _authService.LoginAsync(request);

            if (result.Success && result.Data != null)
            {
                if (!result.Data.User.EmailVerified)
                {
                    await Shell.Current.GoToAsync(
                        $"{Constants.Routes.OtpVerification}?email={Email}&otpType=EmailVerification");
                    return;
                }

                // Go directly to dashboard after login
                await Shell.Current.GoToAsync("//main/dashboard");
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
    }

    [RelayCommand]
    private async Task GoToSignupAsync()
    {
        await Shell.Current.GoToAsync(Constants.Routes.Signup);
    }

    [RelayCommand]
    private async Task GoToForgotPasswordAsync()
    {
        await Shell.Current.GoToAsync(Constants.Routes.ForgotPassword);
    }

    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }
}
