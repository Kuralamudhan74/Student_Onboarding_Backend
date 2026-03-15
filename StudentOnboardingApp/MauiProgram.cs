using Microsoft.Extensions.Logging;
using StudentOnboardingApp.Services;
using StudentOnboardingApp.ViewModels;
using StudentOnboardingApp.Views;

namespace StudentOnboardingApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("PlusJakartaSans-Regular.ttf", "JakartaRegular");
                fonts.AddFont("PlusJakartaSans-Medium.ttf", "JakartaMedium");
                fonts.AddFont("PlusJakartaSans-SemiBold.ttf", "JakartaSemiBold");
                fonts.AddFont("PlusJakartaSans-Bold.ttf", "JakartaBold");
                fonts.AddFont("PlusJakartaSans-ExtraBold.ttf", "JakartaExtraBold");
                fonts.AddFont("DMSans-Regular.ttf", "DMSansRegular");
                fonts.AddFont("DMSans-Medium.ttf", "DMSansMedium");
            });

        // Services
        builder.Services.AddSingleton<ITokenStorageService, TokenStorageService>();
        builder.Services.AddSingleton<IApiService, ApiService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<OtpVerificationViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<ResetPasswordViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();

        // Pages
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignupPage>();
        builder.Services.AddTransient<OtpVerificationPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<ResetPasswordPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<ProfilePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
