using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Courses;

public partial class CourseListPage : ContentPage
{
    private readonly CourseListViewModel _viewModel;
    private bool _dataLoaded;

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
        HeaderSection.TranslationX = -30;
        HeaderSection.Scale = 0.95;

        if (!_dataLoaded || _viewModel.Courses.Count == 0)
        {
            await _viewModel.LoadCoursesCommand.ExecuteAsync(null);
            _dataLoaded = true;
        }

        // Header slides in with spring
        await Task.WhenAll(
            HeaderSection.FadeTo(1, 400, Easing.CubicOut),
            HeaderSection.TranslateTo(0, 0, 450, Easing.SpringOut),
            HeaderSection.ScaleTo(1, 400, Easing.CubicOut)
        );

        // Staggered card animation
        await Task.Delay(60);
        await AnimateCardsAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        HeaderSection.Opacity = 0;
    }

    private async Task AnimateCardsAsync()
    {
        await Task.Delay(50);

        var cards = GetVisualTreeChildren<Border>(CoursesCollection)
            .Where(b => b.BackgroundColor == Colors.White && b.MinimumHeightRequest >= 200)
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
            var delay = i * 80;

#pragma warning disable CS4014
            Task.Delay(delay).ContinueWith(_ => MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(
                    card.FadeTo(1, 450, Easing.CubicOut),
                    card.TranslateTo(0, 0, 500, Easing.SpringOut),
                    card.ScaleTo(1, 450, Easing.SpringOut)
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
