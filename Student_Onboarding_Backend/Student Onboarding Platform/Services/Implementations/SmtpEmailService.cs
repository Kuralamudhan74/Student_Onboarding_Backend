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
