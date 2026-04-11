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
            // Build the full URL
            var url = photoPath.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? photoPath
                : $"{Constants.ApiBaseUrl.TrimEnd('/')}/{photoPath.TrimStart('/')}";

            System.Diagnostics.Debug.WriteLine($"[ProfilePhoto] Loading from: {url}");

            // Always download bytes first to verify the image actually exists
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
#endif
            using var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(20) };
            var response = await client.GetAsync(url);

            System.Diagnostics.Debug.WriteLine($"[ProfilePhoto] Status: {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                ProfileImage = null;
                return;
            }

            var bytes = await response.Content.ReadAsByteArrayAsync();
            System.Diagnostics.Debug.WriteLine($"[ProfilePhoto] Downloaded {bytes.Length} bytes");

            if (bytes.Length > 0)
            {
                // Create a persistent copy — the lambda must return a fresh stream each call
                var imageBytes = bytes.ToArray();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ProfileImage = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                });
            }
            else
            {
                ProfileImage = null;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[ProfilePhoto] Error: {ex.Message}");
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
            else if (result.Message?.Contains("Session expired", StringComparison.OrdinalIgnoreCase) == true
                     || result.Message?.Contains("401", StringComparison.OrdinalIgnoreCase) == true)
            {
                // Token invalid — force re-login
                await _tokenStorage.ClearAllAsync();
                if (Application.Current is App app) app.StopNotificationPolling();
                await Shell.Current.GoToAsync("///auth/login");
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
        await Shell.Current.GoToAsync("///auth/login");
    }
}
