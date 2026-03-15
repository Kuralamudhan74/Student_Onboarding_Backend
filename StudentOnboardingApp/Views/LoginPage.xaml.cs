using StudentOnboardingApp.Helpers;
using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Staggered entrance animations
        await AnimationHelper.FadeUpAsync(BrandArea, delay: 100);
        await AnimationHelper.FadeUpAsync(LoginCard, delay: 200);
    }
}
