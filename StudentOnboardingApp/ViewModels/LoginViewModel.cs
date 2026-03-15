using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private bool isPasswordVisible;

    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Please enter your email and password";
            return;
        }

        ErrorMessage = null;
        IsBusy = true;

        try
        {
            var response = await _authService.LoginAsync(new LoginRequest
            {
                Email = Email.Trim().ToLower(),
                Password = Password
            });

            if (response?.Success == true)
            {
                await Shell.Current.GoToAsync("//dashboard");
            }
            else
            {
                ErrorMessage = response?.Message ?? "Login failed. Please try again.";
            }
        }
        catch (HttpRequestException httpEx)
        {
            ErrorMessage = "Unable to connect to server. Please check your connection.";
            System.Diagnostics.Debug.WriteLine($"HTTP error: {httpEx.Message}");
        }
        catch (TaskCanceledException)
        {
            ErrorMessage = "Request timed out. Please try again.";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error: {ex.Message}";
            System.Diagnostics.Debug.WriteLine($"Login error: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToSignupAsync()
    {
        await Shell.Current.GoToAsync("signup");
    }

    [RelayCommand]
    private async Task GoToForgotPasswordAsync()
    {
        await Shell.Current.GoToAsync("forgot-password");
    }
}
