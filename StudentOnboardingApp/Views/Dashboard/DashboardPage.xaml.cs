using StudentOnboardingApp.ViewModels;

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

        // Quick fade-in on every tab switch
        PageContent.Opacity = 0;
        PageContent.TranslationY = 12;

        // Always reload dashboard data to reflect latest changes (e.g. payment status)
        await _viewModel.LoadDashboardCommand.ExecuteAsync(null);

        // Smooth entrance
        await Task.WhenAll(
            PageContent.FadeTo(1, 350, Easing.CubicOut),
            PageContent.TranslateTo(0, 0, 400, Easing.CubicOut)
        );
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Reset for next appearance
        PageContent.Opacity = 0;
    }
}
