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

        // Animate header on first load
        if (!_hasAnimated)
        {
            HeaderTitle.Opacity = 0;
            HeaderTitle.TranslationY = -20;
            HeaderSubtitle.Opacity = 0;
            HeaderSubtitle.TranslationY = -10;

            await Task.WhenAll(
                HeaderTitle.FadeTo(1, 350, Easing.CubicOut),
                HeaderTitle.TranslateTo(0, 0, 400, Easing.CubicOut)
            );
            await Task.WhenAll(
                HeaderSubtitle.FadeTo(1, 300, Easing.CubicOut),
                HeaderSubtitle.TranslateTo(0, 0, 350, Easing.CubicOut)
            );
        }

        if (_viewModel.Courses.Count == 0)
        {
            await _viewModel.LoadCoursesCommand.ExecuteAsync(null);
        }

        // Staggered card animation after courses load
        if (!_hasAnimated)
        {
            _hasAnimated = true;
            await AnimateCardsAsync();
        }
    }

    private async Task AnimateCardsAsync()
    {
        // Small delay to let CollectionView render
        await Task.Delay(150);

        // Get all visible card borders from the visual tree
        var cards = GetVisualTreeChildren<Border>(CoursesCollection)
            .Where(b => b.BackgroundColor == Colors.White && b.StrokeShape != null)
            .ToList();

        // Set initial state
        foreach (var card in cards)
        {
            card.Opacity = 0;
            card.TranslationY = 30;
            card.Scale = 0.95;
        }

        // Staggered fade-in
        for (int i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var delay = i * 80; // 80ms stagger between each card

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 400, Easing.CubicOut),
                    card.TranslateTo(0, 0, 450, Easing.CubicOut),
                    card.ScaleTo(1, 400, Easing.CubicOut)
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
        {
            results.AddRange(GetVisualTreeChildren<T>(content));
        }
        else if (parent is Border border && border.Content is IView borderContent)
        {
            results.AddRange(GetVisualTreeChildren<T>(borderContent));
        }
        else if (parent is ScrollView scrollView && scrollView.Content is IView scrollContent)
        {
            results.AddRange(GetVisualTreeChildren<T>(scrollContent));
        }
        else if (parent is RefreshView refreshView && refreshView.Content is IView refreshContent)
        {
            results.AddRange(GetVisualTreeChildren<T>(refreshContent));
        }

        return results;
    }
}
