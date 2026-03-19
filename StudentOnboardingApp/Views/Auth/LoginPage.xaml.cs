using StudentOnboardingApp.ViewModels.Auth;

namespace StudentOnboardingApp.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Animate logo icon
        LogoIcon.Opacity = 0;
        LogoIcon.Scale = 0.6;
        HeaderLabel.Opacity = 0;
        HeaderLabel.TranslationY = -16;
        FormCard.Opacity = 0;
        FormCard.TranslationY = 24;

        // Logo bounce in
        await Task.WhenAll(
            LogoIcon.FadeTo(1, 350, Easing.CubicOut),
            LogoIcon.ScaleTo(1, 400, Easing.SpringOut)
        );

        // Header slide in
        await Task.WhenAll(
            HeaderLabel.FadeTo(1, 300, Easing.CubicOut),
            HeaderLabel.TranslateTo(0, 0, 350, Easing.CubicOut)
        );

        // Form card fade up
        await Task.WhenAll(
            FormCard.FadeTo(1, 400, Easing.CubicOut),
            FormCard.TranslateTo(0, 0, 450, Easing.CubicOut)
        );
    }
}
