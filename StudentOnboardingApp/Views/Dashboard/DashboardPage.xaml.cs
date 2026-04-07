using StudentOnboardingApp.ViewModels;
using StudentOnboardingApp.Views.Faq;

namespace StudentOnboardingApp.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
    private readonly DashboardViewModel _viewModel;

    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Reset elements
        WelcomeCard.Opacity = 0;
        WelcomeCard.TranslationY = -30;
        WelcomeCard.Scale = 0.95;
        ProgressBarControl.Progress = 0;
        PageContent.Opacity = 1;

        // Load data
        await _viewModel.LoadDashboardCommand.ExecuteAsync(null);

        // Welcome card drops in
        await Task.WhenAll(
            WelcomeCard.FadeTo(1, 450, Easing.CubicOut),
            WelcomeCard.TranslateTo(0, 0, 500, Easing.SpringOut),
            WelcomeCard.ScaleTo(1, 500, Easing.SpringOut)
        );

        // Animate cards
        await AnimateSectionsAsync();

        // Animate progress bar fill with smooth animation
        if (_viewModel.HasCourse && _viewModel.CourseProgress > 0)
        {
            await Task.Delay(300);

            // Change color to green if completed
            if (_viewModel.IsCompleted)
                ProgressBarControl.ProgressColor = Color.FromArgb("#22C55E");

            await ProgressBarControl.ProgressTo(_viewModel.CourseProgress, 1200, Easing.CubicOut);
        }

        // Animate the bot avatar
        _ = AnimateBotAsync();
    }

    private async Task AnimateSectionsAsync()
    {
        var cards = GetVisualTreeChildren<Border>(PageContent)
            .Where(b => b != WelcomeCard
                && b.StrokeShape != null
                && b.Padding.Top >= 10
                && b.BackgroundColor != Colors.Transparent)
            .Take(6)
            .ToList();

        foreach (var card in cards)
        {
            card.Opacity = 0;
            card.TranslationY = 25;
            card.Scale = 0.96;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var delay = i * 80;

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 400, Easing.CubicOut),
                    card.TranslateTo(0, 0, 450, Easing.CubicOut),
                    card.ScaleTo(1, 400, Easing.SpringOut)
                );
            }));
#pragma warning restore CS4014
        }
    }

    private async void OnFaqButtonTapped(object sender, TappedEventArgs e)
    {
        // Bounce the avatar on tap
        await BotAvatar.ScaleTo(0.85, 80, Easing.CubicOut);
        await BotAvatar.ScaleTo(1.0, 150, Easing.SpringOut);
        await Navigation.PushAsync(new FaqPage());
    }

    private async Task AnimateBotAsync()
    {
        // Personalize the greeting with student's name
        var name = _viewModel.UserName;
        var hour = DateTime.Now.Hour;
        var timeGreet = hour < 12 ? "Good morning" : hour < 17 ? "Good afternoon" : "Good evening";
        BotMessage.Text = string.IsNullOrWhiteSpace(name) || name == "Student"
            ? $"{timeGreet}! Need help? Tap me!"
            : $"{timeGreet}, {name}! Need help? Tap me!";

        // Start bot avatar hidden
        BotAvatar.Opacity = 0;
        BotAvatar.Scale = 0.3;
        BotBubble.Opacity = 0;
        BotBubble.TranslationX = 30;

        // Bot bounces in
        await Task.Delay(800);
        await Task.WhenAll(
            BotAvatar.FadeTo(1, 350, Easing.CubicOut),
            BotAvatar.ScaleTo(1, 500, Easing.SpringOut)
        );

        // Speech bubble slides in
        await Task.Delay(300);
        await Task.WhenAll(
            BotBubble.FadeTo(1, 300, Easing.CubicOut),
            BotBubble.TranslateTo(0, 0, 400, Easing.CubicOut)
        );

        // Auto-hide the bubble after 4 seconds
        await Task.Delay(4000);
        await BotBubble.FadeTo(0, 300, Easing.CubicIn);
    }

    private static List<T> GetVisualTreeChildren<T>(IView parent) where T : class
    {
        var results = new List<T>();
        if (parent is T match) results.Add(match);
        if (parent is Layout layout)
            foreach (var child in layout.Children)
                if (child is IView view) results.AddRange(GetVisualTreeChildren<T>(view));
        if (parent is ContentView cv && cv.Content is IView c) results.AddRange(GetVisualTreeChildren<T>(c));
        if (parent is Border b && b.Content is IView bc) results.AddRange(GetVisualTreeChildren<T>(bc));
        if (parent is ScrollView sv && sv.Content is IView sc) results.AddRange(GetVisualTreeChildren<T>(sc));
        if (parent is RefreshView rv && rv.Content is IView rc) results.AddRange(GetVisualTreeChildren<T>(rc));
        return results;
    }
}
