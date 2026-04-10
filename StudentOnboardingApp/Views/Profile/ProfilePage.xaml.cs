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
        PhotoCard.Scale = 0.95;
        PhotoCard.TranslationY = -10;
        InfoCard.Opacity = 0;
        InfoCard.TranslationY = 12;
        InfoCard.Scale = 0.98;
        EditCard.Opacity = 0;
        EditCard.TranslationY = 12;
        EditCard.Scale = 0.98;

        await _viewModel.LoadProfileCommand.ExecuteAsync(null);

        // Photo card drops in
        await Task.WhenAll(
            PhotoCard.FadeTo(1, 250, Easing.CubicOut),
            PhotoCard.ScaleTo(1, 280, Easing.CubicOut),
            PhotoCard.TranslateTo(0, 0, 280, Easing.CubicOut)
        );

        await Task.Delay(40);

        // Info and edit cards slide up together
        await Task.WhenAll(
            InfoCard.FadeTo(1, 220, Easing.CubicOut),
            InfoCard.TranslateTo(0, 0, 250, Easing.CubicOut),
            InfoCard.ScaleTo(1, 250, Easing.CubicOut),
            EditCard.FadeTo(1, 220, Easing.CubicOut),
            EditCard.TranslateTo(0, 0, 250, Easing.CubicOut),
            EditCard.ScaleTo(1, 250, Easing.CubicOut)
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
