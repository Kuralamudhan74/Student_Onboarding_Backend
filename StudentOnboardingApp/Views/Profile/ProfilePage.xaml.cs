using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Profile;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        DobPicker.MaximumDate = DateTime.Today;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Reset for entrance
        PhotoCard.Opacity = 0;
        PhotoCard.Scale = 0.85;
        PhotoCard.TranslationY = -20;
        InfoCard.Opacity = 0;
        InfoCard.TranslationY = 30;
        InfoCard.Scale = 0.95;
        EditCard.Opacity = 0;
        EditCard.TranslationY = 30;
        EditCard.Scale = 0.95;

        await _viewModel.LoadProfileCommand.ExecuteAsync(null);

        // Photo card drops in with bounce
        await Task.WhenAll(
            PhotoCard.FadeTo(1, 450, Easing.CubicOut),
            PhotoCard.ScaleTo(1, 500, Easing.SpringOut),
            PhotoCard.TranslateTo(0, 0, 500, Easing.SpringOut)
        );

        await Task.Delay(80);

        // Info card slides up
        await Task.WhenAll(
            InfoCard.FadeTo(1, 400, Easing.CubicOut),
            InfoCard.TranslateTo(0, 0, 450, Easing.SpringOut),
            InfoCard.ScaleTo(1, 400, Easing.CubicOut)
        );

        await Task.Delay(60);

        // Edit card slides up
        await Task.WhenAll(
            EditCard.FadeTo(1, 400, Easing.CubicOut),
            EditCard.TranslateTo(0, 0, 450, Easing.SpringOut),
            EditCard.ScaleTo(1, 400, Easing.CubicOut)
        );
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        PhotoCard.Opacity = 0;
        InfoCard.Opacity = 0;
        EditCard.Opacity = 0;
    }
}
