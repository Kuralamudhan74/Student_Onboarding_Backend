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

        // Fade-up entrance animation
        PageContent.Opacity = 0;
        PageContent.TranslationY = 20;

        await _viewModel.LoadDashboardCommand.ExecuteAsync(null);

        await Task.WhenAll(
            PageContent.FadeTo(1, 400, Easing.CubicOut),
            PageContent.TranslateTo(0, 0, 450, Easing.CubicOut)
        );
    }
}
