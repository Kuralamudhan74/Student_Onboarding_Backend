using StudentOnboardingApp.Views;

namespace StudentOnboardingApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("signup", typeof(SignupPage));
        Routing.RegisterRoute("otp-verification", typeof(OtpVerificationPage));
        Routing.RegisterRoute("forgot-password", typeof(ForgotPasswordPage));
        Routing.RegisterRoute("reset-password", typeof(ResetPasswordPage));
    }
}
