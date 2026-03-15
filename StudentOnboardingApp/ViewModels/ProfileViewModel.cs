using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public ProfileViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string fullName = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string initials = string.Empty;

    [ObservableProperty]
    private string role = string.Empty;

    [ObservableProperty]
    private bool emailVerified;

    [ObservableProperty]
    private bool phoneVerified;

    [ObservableProperty]
    private bool isLoading = true;

    // Change password fields
    [ObservableProperty]
    private string currentPassword = string.Empty;

    [ObservableProperty]
    private string newPassword = string.Empty;

    [ObservableProperty]
    private string confirmNewPassword = string.Empty;

    [ObservableProperty]
    private bool isChangingPassword;

    [ObservableProperty]
    private bool showChangePassword;

    [ObservableProperty]
    private string? passwordMessage;

    [ObservableProperty]
    private bool isPasswordMessageError;

    [RelayCommand]
    private async Task LoadProfileAsync()
    {
        IsLoading = true;
        try
        {
            var user = await _authService.GetCurrentUserAsync();
            if (user != null)
            {
                FullName = user.FullName;
                Email = user.Email;
                PhoneNumber = user.PhoneNumber;
                Initials = user.Initials;
                Role = user.Role;
                EmailVerified = user.EmailVerified;
                PhoneVerified = user.PhoneVerified;
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void ToggleChangePassword()
    {
        ShowChangePassword = !ShowChangePassword;
        if (!ShowChangePassword)
        {
            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmNewPassword = string.Empty;
            PasswordMessage = null;
        }
    }

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(CurrentPassword) || string.IsNullOrWhiteSpace(NewPassword))
        {
            PasswordMessage = "Please fill in all fields";
            IsPasswordMessageError = true;
            return;
        }
        if (NewPassword != ConfirmNewPassword)
        {
            PasswordMessage = "New passwords do not match";
            IsPasswordMessageError = true;
            return;
        }
        if (NewPassword.Length < 8)
        {
            PasswordMessage = "Password must be at least 8 characters";
            IsPasswordMessageError = true;
            return;
        }

        IsChangingPassword = true;
        PasswordMessage = null;

        try
        {
            var response = await _authService.ChangePasswordAsync(new ChangePasswordRequest
            {
                CurrentPassword = CurrentPassword,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmNewPassword
            });

            if (response?.Success == true)
            {
                PasswordMessage = "Password changed successfully. Please log in again.";
                IsPasswordMessageError = false;
                await Task.Delay(2000);
                await _authService.LogoutAsync();
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                PasswordMessage = response?.Message ?? "Failed to change password";
                IsPasswordMessageError = true;
            }
        }
        catch (Exception)
        {
            PasswordMessage = "Unable to change password. Please try again.";
            IsPasswordMessageError = true;
        }
        finally
        {
            IsChangingPassword = false;
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
