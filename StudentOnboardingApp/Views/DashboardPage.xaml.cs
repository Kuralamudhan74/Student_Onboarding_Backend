using StudentOnboardingApp.Helpers;
using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views;

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

        await _viewModel.LoadDataCommand.ExecuteAsync(null);

        // Staggered card animations
        await AnimationHelper.FadeUpAsync(GreetingLabel, delay: 100);
        await AnimationHelper.FadeUpAsync(UserNameLabel, delay: 150);

        _ = AnimationHelper.FadeUpAsync(QuickActionsCard, delay: 250);
        _ = AnimationHelper.FadeUpAsync(ProgressCard, delay: 350);
        _ = AnimationHelper.FadeUpAsync(AnnouncementsCard, delay: 450);
    }
}
