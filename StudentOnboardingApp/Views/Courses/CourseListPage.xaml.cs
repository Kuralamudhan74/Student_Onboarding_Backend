using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Courses;

public partial class CourseListPage : ContentPage
{
    private readonly CourseListViewModel _viewModel;

    public CourseListPage(CourseListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Reset header for slide-in
        HeaderSection.Opacity = 0;
        HeaderSection.TranslationX = -15;
        HeaderSection.Scale = 0.98;

        // Always reload to reflect admin edits
        await _viewModel.LoadCoursesCommand.ExecuteAsync(null);

        // Header slides in
        await Task.WhenAll(
            HeaderSection.FadeTo(1, 220, Easing.CubicOut),
            HeaderSection.TranslateTo(0, 0, 250, Easing.CubicOut),
            HeaderSection.ScaleTo(1, 250, Easing.CubicOut)
        );

        // Staggered card animation
        await Task.Delay(30);
        await AnimateCardsAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        HeaderSection.Opacity = 0;
    }

    private async Task AnimateCardsAsync()
    {
        await Task.Delay(20);

        var cards = GetVisualTreeChildren<Border>(CoursesCollection)
            .Where(b => b.BackgroundColor == Colors.White && b.MinimumHeightRequest >= 250)
            .ToList();

        foreach (var card in cards)
        {
            card.Opacity = 0;
            card.TranslationY = 14;
            card.Scale = 0.97;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var delay = i * 35;

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 200, Easing.CubicOut),
                    card.TranslateTo(0, 0, 230, Easing.CubicOut),
                    card.ScaleTo(1, 230, Easing.CubicOut)
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
        if (parent is ContentView cv && cv.Content is IView c) results.AddRange(GetVisualTreeChildren<T>(c));
        if (parent is Border b && b.Content is IView bc) results.AddRange(GetVisualTreeChildren<T>(bc));
        if (parent is ScrollView sv && sv.Content is IView sc) results.AddRange(GetVisualTreeChildren<T>(sc));
        if (parent is RefreshView rv && rv.Content is IView rc) results.AddRange(GetVisualTreeChildren<T>(rc));
        return results;
    }
}
