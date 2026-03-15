namespace StudentOnboardingApp.Models;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DeviceType { get; set; } = "Android";
    public string DeviceName { get; set; } = string.Empty;
}
