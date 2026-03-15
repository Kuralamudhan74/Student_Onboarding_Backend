using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models;
using StudentOnboardingApp.Services;

namespace StudentOnboardingApp.ViewModels;

public partial class SignupViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public SignupViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string firstName = string.Empty;

    [ObservableProperty]
    private string lastName = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private string confirmPassword = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private bool isPasswordVisible;

    // Password strength indicators
    public bool HasMinLength => Password.Length >= 8;
    public bool HasUppercase => Password.Any(char.IsUpper);
    public bool HasLowercase => Password.Any(char.IsLower);
    public bool HasDigit => Password.Any(char.IsDigit);
    public bool HasSpecialChar => Password.Any(c => !char.IsLetterOrDigit(c));

    partial void OnPasswordChanged(string value)
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
    private async Task SignupAsync()
    {
        if (!ValidateInputs()) return;

        ErrorMessage = null;
        IsBusy = true;

        try
        {
            var response = await _authService.SignupAsync(new SignupRequest
            {
                FirstName = FirstName.Trim(),
                LastName = LastName.Trim(),
                Email = Email.Trim().ToLower(),
                PhoneNumber = PhoneNumber.Trim(),
                Password = Password,
                ConfirmPassword = ConfirmPassword
            });

            if (response?.Success == true)
            {
                await Shell.Current.GoToAsync($"otp-verification?email={Uri.EscapeDataString(Email.Trim().ToLower())}&otpType=EmailVerification");
            }
            else
            {
                ErrorMessage = response?.Message ?? "Signup failed. Please try again.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Unable to connect to server. Please check your connection.";
            System.Diagnostics.Debug.WriteLine($"Signup error: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            ErrorMessage = "Please enter your full name";
            return false;
        }
        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            ErrorMessage = "Please enter a valid email address";
            return false;
        }
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            ErrorMessage = "Please enter your phone number";
            return false;
        }
        if (!HasMinLength || !HasUppercase || !HasLowercase || !HasDigit || !HasSpecialChar)
        {
            ErrorMessage = "Password doesn't meet the requirements";
            return false;
        }
        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Passwords do not match";
            return false;
        }
        return true;
    }
}
