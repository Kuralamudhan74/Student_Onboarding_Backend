using StudentOnboardingApp.ViewModels.Auth;
using StudentOnboardingApp.Views.Faq;

namespace StudentOnboardingApp.Views.Auth;

public partial class LoginPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public LoginPage(LoginViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _serviceProvider = serviceProvider;
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

        // Animate bot greeting
        _ = AnimateBotAsync();
    }

    private async Task AnimateBotAsync()
    {
        BotAvatar.Opacity = 0;
        BotAvatar.Scale = 0.3;
        BotBubble.Opacity = 0;
        BotBubble.TranslationX = 30;

        await Task.Delay(1200);
        await Task.WhenAll(
            BotAvatar.FadeTo(1, 350, Easing.CubicOut),
            BotAvatar.ScaleTo(1, 500, Easing.SpringOut)
        );

        await Task.Delay(300);
        await Task.WhenAll(
            BotBubble.FadeTo(1, 300, Easing.CubicOut),
            BotBubble.TranslateTo(0, 0, 400, Easing.CubicOut)
        );

        await Task.Delay(5000);
        await BotBubble.FadeTo(0, 300, Easing.CubicIn);
    }

    private async void OnBotTapped(object sender, TappedEventArgs e)
    {
        await BotAvatar.ScaleTo(0.85, 80, Easing.CubicOut);
        await BotAvatar.ScaleTo(1.0, 150, Easing.SpringOut);
        await Navigation.PushAsync(_serviceProvider.GetRequiredService<FaqPage>());
    }
}
