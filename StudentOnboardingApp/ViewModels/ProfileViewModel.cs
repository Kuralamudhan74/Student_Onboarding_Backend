using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models.Profile;
using StudentOnboardingApp.Services.Interfaces;
using System.Net.Http;

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

    // Editable fields
    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private string? _phoneNumber;

    [ObservableProperty]
    private DateTime _dateOfBirth = DateTime.Today.AddYears(-18);

    [ObservableProperty]
    private string? _address;

    [ObservableProperty]
    private string? _education;

    [ObservableProperty]
    private bool _isEditing;

    [ObservableProperty]
    private string? _successMessage;

    [ObservableProperty]
    private ImageSource? _profileImage;

    public bool HasPhoto => ProfileImage != null;

    partial void OnProfileChanged(StudentProfileDto? value)
    {
        OnPropertyChanged(nameof(HasPhoto));
        if (value != null && !string.IsNullOrEmpty(value.ProfilePhotoUrl))
        {
            _ = LoadProfileImageAsync(value.ProfilePhotoUrl);
        }
        else
        {
            ProfileImage = null;
        }
    }

    partial void OnProfileImageChanged(ImageSource? value)
    {
        OnPropertyChanged(nameof(HasPhoto));
    }

    private async Task LoadProfileImageAsync(string photoPath)
    {
        try
        {
            var url = $"{Constants.ApiBaseUrl.Replace("/api/", "")}{photoPath}";
            // Use HttpClientHandler that bypasses SSL for localhost
            using var handler = new HttpClientHandler();
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
#endif
            using var client = new HttpClient(handler);
            var bytes = await client.GetByteArrayAsync(url);
            ProfileImage = ImageSource.FromStream(() => new MemoryStream(bytes));
        }
        catch
        {
            ProfileImage = null;
        }
    }

    private void PopulateFieldsFromProfile()
    {
        if (Profile == null) return;
        FirstName = Profile.FirstName;
        LastName = Profile.LastName;
        PhoneNumber = Profile.PhoneNumber;
        DateOfBirth = Profile.DateOfBirth ?? DateTime.Today.AddYears(-18);
        Address = Profile.Address;
        Education = Profile.Education;
    }

    [RelayCommand]
    private async Task LoadProfileAsync()
    {
        await ExecuteAsync(async () =>
        {
            var result = await _profileService.GetProfileAsync();
            if (result.Success && result.Data != null)
            {
                Profile = result.Data;
                PopulateFieldsFromProfile();
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
    }

    [RelayCommand]
    private void ToggleEdit()
    {
        if (!IsEditing)
        {
            // Entering edit mode — auto-fill fields from current profile
            PopulateFieldsFromProfile();
        }
        IsEditing = !IsEditing;
        SuccessMessage = null;
        ErrorMessage = null;
    }

    [RelayCommand]
    private async Task SaveProfileAsync()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            ErrorMessage = "First name and last name are required.";
            return;
        }

        await ExecuteAsync(async () =>
        {
            var request = new UpdateProfileRequest
            {
                FirstName = FirstName.Trim(),
                LastName = LastName.Trim(),
                PhoneNumber = PhoneNumber?.Trim(),
                DateOfBirth = DateOfBirth,
                Address = Address?.Trim(),
                Education = Education?.Trim()
            };

            var result = await _profileService.UpdateProfileAsync(request);
            if (result.Success)
            {
                IsEditing = false;
                SuccessMessage = "Profile updated successfully!";
                ErrorMessage = null;
                // Reload profile to get fresh data from server
                await LoadProfileInternalAsync();
            }
            else
            {
                ErrorMessage = result.Message ?? "Failed to update profile.";
            }
        });
    }

    private async Task LoadProfileInternalAsync()
    {
        var result = await _profileService.GetProfileAsync();
        if (result.Success && result.Data != null)
        {
            Profile = result.Data;
            PopulateFieldsFromProfile();
        }
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
                ErrorMessage = null;
                using var stream = await result.OpenReadAsync();
                var uploadResult = await _profileService.UploadPhotoAsync(stream, result.FileName);

                if (uploadResult.Success)
                {
                    SuccessMessage = "Photo uploaded!";
                    await LoadProfileInternalAsync();
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
            IsBusy = false;
        }
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
