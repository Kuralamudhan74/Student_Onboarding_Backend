<<<<<<< HEAD
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using StudentOnboardingApp.Handlers;
using StudentOnboardingApp.Services.Implementations;
using StudentOnboardingApp.Services.Interfaces;
using StudentOnboardingApp.ViewModels;
using StudentOnboardingApp.ViewModels.Auth;
using StudentOnboardingApp.ViewModels.Onboarding;
using StudentOnboardingApp.Views.Auth;
using StudentOnboardingApp.Views.Courses;
using StudentOnboardingApp.Views.Dashboard;
using StudentOnboardingApp.Views.Notifications;
using StudentOnboardingApp.Views.Onboarding;
using StudentOnboardingApp.Views.Profile;
=======
using Microsoft.Extensions.Logging;
using StudentOnboardingApp.Services;
using StudentOnboardingApp.ViewModels;
using StudentOnboardingApp.Views;
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

namespace StudentOnboardingApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
<<<<<<< HEAD
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Token storage (singleton - shared across app)
        builder.Services.AddSingleton<ITokenStorageService, TokenStorageService>();

        // HTTP handler
        builder.Services.AddTransient<AuthenticatedHttpClientHandler>();

        // Public API client (no auth header)
        builder.Services.AddHttpClient(Constants.PublicApiClient, client =>
        {
            client.BaseAddress = new Uri(Constants.ApiBaseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        })
        .ConfigurePrimaryHttpMessageHandler(() => GetPlatformHttpHandler());

        // Authenticated API client (with JWT injection + 401 refresh)
        builder.Services.AddHttpClient(Constants.AuthenticatedApiClient, client =>
        {
            client.BaseAddress = new Uri(Constants.ApiBaseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        })
        .AddHttpMessageHandler<AuthenticatedHttpClientHandler>()
        .ConfigurePrimaryHttpMessageHandler(() => GetPlatformHttpHandler());

        // Services
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<ICourseService, CourseService>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();
        builder.Services.AddSingleton<IDashboardService, DashboardService>();
        builder.Services.AddSingleton<INotificationService, NotificationService>();
        builder.Services.AddSingleton<IOnboardingService, OnboardingService>();
=======
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
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<OtpVerificationViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<ResetPasswordViewModel>();
<<<<<<< HEAD
        builder.Services.AddTransient<ApprovalWaitingViewModel>();
        builder.Services.AddTransient<OnboardingInstructionsViewModel>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<CourseListViewModel>();
        builder.Services.AddTransient<CourseDetailViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<EditProfileViewModel>();
        builder.Services.AddTransient<ChangePasswordViewModel>();
        builder.Services.AddTransient<NotificationsViewModel>();
=======
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

        // Pages
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignupPage>();
        builder.Services.AddTransient<OtpVerificationPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<ResetPasswordPage>();
<<<<<<< HEAD
        builder.Services.AddTransient<ApprovalWaitingPage>();
        builder.Services.AddTransient<OnboardingInstructionsPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<CourseListPage>();
        builder.Services.AddTransient<CourseDetailPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<EditProfilePage>();
        builder.Services.AddTransient<ChangePasswordPage>();
        builder.Services.AddTransient<NotificationsPage>();
=======
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<ProfilePage>();
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
<<<<<<< HEAD

    /// <summary>
    /// Returns an HttpMessageHandler that bypasses SSL validation in DEBUG mode.
    /// Required for connecting to local dev servers with self-signed certificates.
    /// </summary>
    private static HttpMessageHandler GetPlatformHttpHandler()
    {
#if DEBUG
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };
        return handler;
#else
        return new HttpClientHandler();
#endif
    }
=======
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
}
