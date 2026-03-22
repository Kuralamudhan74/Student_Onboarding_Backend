using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
    private readonly DashboardViewModel _viewModel;
    private bool _hasAnimated;

    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadDashboardCommand.ExecuteAsync(null);

        if (!_hasAnimated)
        {
            _hasAnimated = true;
            // Ensure layout is complete before animating
            await Task.Delay(50);
            await RunEntranceAnimationsAsync();
        }
    }

    private async Task RunEntranceAnimationsAsync()
    {
        // Welcome card — slide from top + scale
        WelcomeCard.Opacity = 0;
        WelcomeCard.TranslationY = -40;
        WelcomeCard.Scale = 0.92;

        await Task.WhenAll(
            WelcomeCard.FadeTo(1, 600, Easing.CubicOut),
            WelcomeCard.TranslateTo(0, 0, 650, Easing.CubicOut),
            WelcomeCard.ScaleTo(1, 600, Easing.SpringOut)
        );

        await Task.Delay(120);

        // Content cards — slide from bottom
        var contentCard = _viewModel.HasCourse ? CourseCard : NoCourseCard;
        contentCard.Opacity = 0;
        contentCard.TranslationY = 50;
        contentCard.Scale = 0.95;

        await Task.WhenAll(
            contentCard.FadeTo(1, 500, Easing.CubicOut),
            contentCard.TranslateTo(0, 0, 550, Easing.CubicOut),
            contentCard.ScaleTo(1, 500, Easing.CubicOut)
        );
    }
}
