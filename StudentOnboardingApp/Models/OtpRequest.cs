namespace StudentOnboardingApp.Models;

public class VerifyOtpRequest
{
    public string Email { get; set; } = string.Empty;
    public string OtpCode { get; set; } = string.Empty;
    public string OtpType { get; set; } = "EmailVerification";
}

public class ResendOtpRequest
{
    public string Email { get; set; } = string.Empty;
    public string OtpType { get; set; } = "EmailVerification";
}
