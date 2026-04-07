using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Student_Onboarding_Platform.Models.Settings;
using Student_Onboarding_Platform.Services.Interfaces;

namespace Student_Onboarding_Platform.Services.Implementations;

public class SmtpEmailService : IEmailService
{
    private readonly SmtpSettings _settings;
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(IOptions<SmtpSettings> settings, ILogger<SmtpEmailService> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task SendOtpEmailAsync(string toEmail, string otpCode, string purpose)
    {
        var subject = $"Your Verification Code - {_settings.FromName}";
        var body = $@"
            <h2>Verification Code</h2>
            <p>Your OTP for <strong>{purpose}</strong> is:</p>
            <h1 style='color: #4CAF50; letter-spacing: 5px;'>{otpCode}</h1>
            <p>This code expires in 5 minutes. Do not share it with anyone.</p>
            <p>If you did not request this, please ignore this email.</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendPasswordResetEmailAsync(string toEmail, string otpCode)
    {
        var subject = $"Password Reset Request - {_settings.FromName}";
        var body = $@"
            <h2>Password Reset</h2>
            <p>You have requested to reset your password. Use the following code:</p>
            <h1 style='color: #FF5722; letter-spacing: 5px;'>{otpCode}</h1>
            <p>This code expires in 5 minutes. Do not share it with anyone.</p>
            <p>If you did not request this, please secure your account immediately.</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendWelcomeEmailAsync(string toEmail, string firstName)
    {
        var subject = $"Welcome to {_settings.FromName}!";
        var body = $@"
            <h2>Welcome, {firstName}!</h2>
            <p>Your account has been successfully verified.</p>
            <p>You can now log in and start your onboarding journey.</p>
            <p>Best regards,<br/>{_settings.FromName} Team</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendPendingApprovalEmailAsync(string toEmail, string firstName)
    {
        var subject = $"Email Verified - Awaiting Approval - {_settings.FromName}";
        var body = $@"
            <h2>Email Verified Successfully, {firstName}!</h2>
            <p>Your email has been verified. Your account is now pending admin approval.</p>
            <p>You will receive a notification once your account has been reviewed by our team.</p>
            <p>Thank you for your patience.</p>
            <p>Best regards,<br/>{_settings.FromName} Team</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendApprovalEmailAsync(string toEmail, string firstName)
    {
        var subject = $"Account Approved - Welcome to {_settings.FromName}!";
        var body = $@"
            <h2>Congratulations, {firstName}!</h2>
            <p>Your account has been approved by our admin team.</p>
            <p>You can now log in and start your onboarding journey.</p>
            <p>Best regards,<br/>{_settings.FromName} Team</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendDenialEmailAsync(string toEmail, string firstName, string? reason)
    {
        var subject = $"Account Registration Update - {_settings.FromName}";
        var reasonText = string.IsNullOrEmpty(reason)
            ? "No specific reason was provided."
            : reason;

        var body = $@"
            <h2>Registration Update, {firstName}</h2>
            <p>We regret to inform you that your account registration has been denied.</p>
            <p><strong>Reason:</strong> {reasonText}</p>
            <p>If you believe this is an error, please contact our support team.</p>
            <p>Best regards,<br/>{_settings.FromName} Team</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendCourseRegistrationEmailAsync(string toEmail, string firstName, string courseName)
    {
        var subject = $"Course Registration Confirmed - {_settings.FromName}";
        var body = $@"
            <h2>Course Registration Successful, {firstName}!</h2>
            <p>You have been registered for the following course:</p>
            <h3 style='color: #2196F3;'>{courseName}</h3>
            <p>Please check your dashboard for payment details and course information.</p>
            <p>Best regards,<br/>{_settings.FromName} Team</p>";

        await SendEmailAsync(toEmail, subject, body);
    }

    private async Task SendEmailAsync(string to, string subject, string htmlBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = htmlBody };

        using var client = new SmtpClient();
        try
        {
            var secureOption = _settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
            await client.ConnectAsync(_settings.Host, _settings.Port, secureOption);
            await client.AuthenticateAsync(_settings.Username, _settings.Password);
            await client.SendAsync(message);
            _logger.LogInformation("Email sent successfully to {Email} with subject '{Subject}'", to, subject);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Email} with subject '{Subject}'", to, subject);
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}
