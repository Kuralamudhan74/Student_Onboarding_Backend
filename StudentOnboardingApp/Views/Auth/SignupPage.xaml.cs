using StudentOnboardingApp.ViewModels.Auth;
using StudentOnboardingApp.Views.Faq;

namespace StudentOnboardingApp.Views.Auth;

public partial class SignupPage : ContentPage
{
    private readonly SignupViewModel _viewModel;

    public SignupPage(SignupViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadCoursesCommand.ExecuteAsync(null);

        // Animate bot welcome
        _ = AnimateBotAsync();
    }

    private async Task AnimateBotAsync()
    {
        BotAvatar.Opacity = 0;
        BotAvatar.Scale = 0.3;
        BotBubble.Opacity = 0;
        BotBubble.TranslationX = 30;

        await Task.Delay(1000);
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
        await Navigation.PushAsync(new FaqPage());
    }
}
