using StudentOnboardingApp.Helpers;
using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views;

public partial class OtpVerificationPage : ContentPage
{
    private readonly OtpVerificationViewModel _viewModel;

    public OtpVerificationPage(OtpVerificationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;

        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(viewModel.ErrorMessage))
                ErrorBorder.IsVisible = !string.IsNullOrEmpty(viewModel.ErrorMessage);
            if (e.PropertyName == nameof(viewModel.SuccessMessage))
                SuccessBorder.IsVisible = !string.IsNullOrEmpty(viewModel.SuccessMessage);
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await AnimationHelper.FadeUpAsync(HeaderArea, delay: 100);
        await AnimationHelper.FadeUpAsync(OtpCard, delay: 200);
    }
}
