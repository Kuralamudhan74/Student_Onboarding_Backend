using StudentOnboardingApp.Helpers;
using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage(ForgotPasswordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(viewModel.ErrorMessage))
                ErrorBorder.IsVisible = !string.IsNullOrEmpty(viewModel.ErrorMessage);
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await AnimationHelper.FadeUpAsync(HeaderArea, delay: 100);
        await AnimationHelper.FadeUpAsync(FormCard, delay: 200);
    }
}
