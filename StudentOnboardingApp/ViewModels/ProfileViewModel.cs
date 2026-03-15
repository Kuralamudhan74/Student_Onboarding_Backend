using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
<<<<<<< HEAD
using StudentOnboardingApp.Models.Profile;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    private readonly IProfileService _profileService;
    private readonly IAuthService _authService;
    private readonly ITokenStorageService _tokenStorage;

    public ProfileViewModel(
        IProfileService profileService,
        IAuthService authService,
        ITokenStorageService tokenStorage)
    {
        _profileService = profileService;
        _authService = authService;
        _tokenStorage = tokenStorage;
        Title = "Profile";
    }

    [ObservableProperty]
    private StudentProfileDto? _profile;
=======
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
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

    [RelayCommand]
    private async Task LoadProfileAsync()
    {
<<<<<<< HEAD
        await ExecuteAsync(async () =>
        {
            var result = await _profileService.GetProfileAsync();
            if (result.Success && result.Data != null)
            {
                Profile = result.Data;
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
    }

    [RelayCommand]
    private async Task UploadPhotoAsync()
    {
        try
        {
            var result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Select Profile Photo"
            });

            if (result != null)
            {
                IsBusy = true;
                using var stream = await result.OpenReadAsync();
                var uploadResult = await _profileService.UploadPhotoAsync(stream, result.FileName);

                if (uploadResult.Success)
                {
                    await LoadProfileAsync();
                }
                else
                {
                    ErrorMessage = uploadResult.Message;
                }
                IsBusy = false;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    [RelayCommand]
    private async Task GoToEditProfileAsync()
    {
        await Shell.Current.GoToAsync(Constants.Routes.EditProfile);
    }

    [RelayCommand]
    private async Task GoToChangePasswordAsync()
    {
        await Shell.Current.GoToAsync(Constants.Routes.ChangePassword);
=======
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
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
<<<<<<< HEAD
        var confirm = await Shell.Current.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (!confirm) return;

        await _authService.LogoutAsync();
        await Shell.Current.GoToAsync($"///{Constants.Routes.Login}");
=======
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
