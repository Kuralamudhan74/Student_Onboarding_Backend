using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    private async Task LoadProfileAsync()
    {
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
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        var confirm = await Shell.Current.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (!confirm) return;

        await _authService.LogoutAsync();
        await Shell.Current.GoToAsync($"///{Constants.Routes.Login}");
    }
}
