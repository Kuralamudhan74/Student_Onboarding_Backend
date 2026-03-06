namespace Student_Onboarding_Platform.Services.Interfaces;

public interface IEmailService
{
    Task SendOtpEmailAsync(string toEmail, string otpCode, string purpose);
    Task SendPasswordResetEmailAsync(string toEmail, string otpCode);
    Task SendWelcomeEmailAsync(string toEmail, string firstName);
}
