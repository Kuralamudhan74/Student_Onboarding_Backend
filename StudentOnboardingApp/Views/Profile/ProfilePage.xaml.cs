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

        // Quick scale-in on every tab switch
        PhotoCard.Opacity = 0;
        PhotoCard.Scale = 0.9;
        InfoCard.Opacity = 0;
        InfoCard.TranslationY = 20;
        EditCard.Opacity = 0;
        EditCard.TranslationY = 20;

        await _viewModel.LoadProfileCommand.ExecuteAsync(null);

        // Photo card bounces in
        await Task.WhenAll(
            PhotoCard.FadeTo(1, 400, Easing.CubicOut),
            PhotoCard.ScaleTo(1, 450, Easing.SpringOut)
        );

        await Task.Delay(60);

        // Info/Edit cards slide up
        await Task.WhenAll(
            InfoCard.FadeTo(1, 350, Easing.CubicOut),
            InfoCard.TranslateTo(0, 0, 400, Easing.CubicOut),
            EditCard.FadeTo(1, 350, Easing.CubicOut),
            EditCard.TranslateTo(0, 0, 400, Easing.CubicOut)
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
