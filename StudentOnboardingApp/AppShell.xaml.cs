<<<<<<< HEAD
using StudentOnboardingApp.Views.Auth;
using StudentOnboardingApp.Views.Courses;
using StudentOnboardingApp.Views.Onboarding;
using StudentOnboardingApp.Views.Profile;
=======
using StudentOnboardingApp.Views;
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8

namespace StudentOnboardingApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

<<<<<<< HEAD
        // Auth routes
        Routing.RegisterRoute(Constants.Routes.Signup, typeof(SignupPage));
        Routing.RegisterRoute(Constants.Routes.OtpVerification, typeof(OtpVerificationPage));
        Routing.RegisterRoute(Constants.Routes.ForgotPassword, typeof(ForgotPasswordPage));
        Routing.RegisterRoute(Constants.Routes.ResetPassword, typeof(ResetPasswordPage));

        // Onboarding routes
        Routing.RegisterRoute(Constants.Routes.ApprovalWaiting, typeof(ApprovalWaitingPage));
        Routing.RegisterRoute(Constants.Routes.OnboardingInstructions, typeof(OnboardingInstructionsPage));

        // Detail routes
        Routing.RegisterRoute(Constants.Routes.CourseDetail, typeof(CourseDetailPage));
        Routing.RegisterRoute(Constants.Routes.EditProfile, typeof(EditProfilePage));
        Routing.RegisterRoute(Constants.Routes.ChangePassword, typeof(ChangePasswordPage));
=======
        // Register routes for navigation
        Routing.RegisterRoute("signup", typeof(SignupPage));
        Routing.RegisterRoute("otp-verification", typeof(OtpVerificationPage));
        Routing.RegisterRoute("forgot-password", typeof(ForgotPasswordPage));
        Routing.RegisterRoute("reset-password", typeof(ResetPasswordPage));
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
    }
}
