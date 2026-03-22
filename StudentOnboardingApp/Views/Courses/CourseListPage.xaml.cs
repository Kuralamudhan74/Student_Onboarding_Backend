using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Courses;

public partial class CourseListPage : ContentPage
{
    private readonly CourseListViewModel _viewModel;
    private bool _hasAnimated;

    public CourseListPage(CourseListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.Courses.Count == 0)
            await _viewModel.LoadCoursesCommand.ExecuteAsync(null);

        if (!_hasAnimated)
        {
            _hasAnimated = true;
            await Task.Delay(50);
            await RunEntranceAnimationsAsync();
        }
    }

    private async Task RunEntranceAnimationsAsync()
    {
        // Header slide in from left
        HeaderSection.Opacity = 0;
        HeaderSection.TranslationX = -30;

        await Task.WhenAll(
            HeaderSection.FadeTo(1, 500, Easing.CubicOut),
            HeaderSection.TranslateTo(0, 0, 550, Easing.CubicOut)
        );

        await Task.Delay(100);

        // Staggered card animation
        await AnimateCardsAsync();
    }

    private async Task AnimateCardsAsync()
    {
        await Task.Delay(100);

        var cards = GetVisualTreeChildren<Border>(CoursesCollection)
            .Where(b => b.BackgroundColor == Colors.White && b.StrokeShape != null
                        && b.MinimumHeightRequest >= 200)
            .ToList();

        foreach (var card in cards)
        {
            card.Opacity = 0;
            card.TranslationY = 40;
            card.Scale = 0.9;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var delay = i * 100;

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 500, Easing.CubicOut),
                    card.TranslateTo(0, 0, 550, Easing.CubicOut),
                    card.ScaleTo(1, 500, Easing.SpringOut)
                );
            }));
#pragma warning restore CS4014
        }
    }

    private static List<T> GetVisualTreeChildren<T>(IView parent) where T : class
    {
        var results = new List<T>();
        if (parent is T match)
            results.Add(match);

        if (parent is Layout layout)
        {
            foreach (var child in layout.Children)
            {
                if (child is IView view)
                    results.AddRange(GetVisualTreeChildren<T>(view));
            }
        }
        else if (parent is ContentView contentView && contentView.Content is IView content)
            results.AddRange(GetVisualTreeChildren<T>(content));
        else if (parent is Border border && border.Content is IView borderContent)
            results.AddRange(GetVisualTreeChildren<T>(borderContent));
        else if (parent is ScrollView scrollView && scrollView.Content is IView scrollContent)
            results.AddRange(GetVisualTreeChildren<T>(scrollContent));
        else if (parent is RefreshView refreshView && refreshView.Content is IView refreshContent)
            results.AddRange(GetVisualTreeChildren<T>(refreshContent));

        return results;
    }
}
