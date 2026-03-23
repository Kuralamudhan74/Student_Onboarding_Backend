using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Notifications;

public partial class NotificationsPage : ContentPage
{
    private readonly NotificationsViewModel _viewModel;

    public NotificationsPage(NotificationsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Slide-in on every tab switch
        PageHeader.Opacity = 0;
        PageHeader.TranslationX = -20;

        await _viewModel.LoadNotificationsCommand.ExecuteAsync(null);

        // Header slides in from left
        await Task.WhenAll(
            PageHeader.FadeTo(1, 350, Easing.CubicOut),
            PageHeader.TranslateTo(0, 0, 400, Easing.CubicOut)
        );

        // Staggered notification cards
        await Task.Delay(60);
        await AnimateNotificationCardsAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        PageHeader.Opacity = 0;
    }

    private async Task AnimateNotificationCardsAsync()
    {
        await Task.Delay(50);

        var cards = GetVisualTreeChildren<Border>(NotificationsList)
            .Where(b => b.Margin.Left >= 18)
            .ToList();

        foreach (var card in cards)
        {
            card.Opacity = 0;
            card.TranslationX = 40;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var delay = i * 60;

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 400, Easing.CubicOut),
                    card.TranslateTo(0, 0, 450, Easing.CubicOut)
                );
            }));
#pragma warning restore CS4014
        }
    }

    private static List<T> GetVisualTreeChildren<T>(IView parent) where T : class
    {
        var results = new List<T>();
        if (parent is T match) results.Add(match);

        if (parent is Layout layout)
            foreach (var child in layout.Children)
                if (child is IView view) results.AddRange(GetVisualTreeChildren<T>(view));
        else if (parent is ContentView cv && cv.Content is IView c) results.AddRange(GetVisualTreeChildren<T>(c));
        else if (parent is Border b && b.Content is IView bc) results.AddRange(GetVisualTreeChildren<T>(bc));
        else if (parent is ScrollView sv && sv.Content is IView sc) results.AddRange(GetVisualTreeChildren<T>(sc));
        else if (parent is RefreshView rv && rv.Content is IView rc) results.AddRange(GetVisualTreeChildren<T>(rc));

        return results;
    }
}
