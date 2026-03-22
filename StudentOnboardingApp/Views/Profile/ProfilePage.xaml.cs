using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Profile;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;
    private bool _hasAnimated;

    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        DobPicker.MaximumDate = DateTime.Today;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadProfileCommand.ExecuteAsync(null);

        if (!_hasAnimated)
        {
            _hasAnimated = true;
            await Task.Delay(50);
            await RunEntranceAnimationsAsync();
        }
    }

    private async Task RunEntranceAnimationsAsync()
    {
        // Photo card — scale bounce in
        PhotoCard.Opacity = 0;
        PhotoCard.Scale = 0.85;

        await Task.WhenAll(
            PhotoCard.FadeTo(1, 500, Easing.CubicOut),
            PhotoCard.ScaleTo(1, 600, Easing.SpringOut)
        );

        await Task.Delay(100);

        // Info card — slide up from bottom
        InfoCard.Opacity = 0;
        InfoCard.TranslationY = 50;

        await Task.WhenAll(
            InfoCard.FadeTo(1, 450, Easing.CubicOut),
            InfoCard.TranslateTo(0, 0, 500, Easing.CubicOut)
        );

        // Edit card (if visible) follows
        EditCard.Opacity = 0;
        EditCard.TranslationY = 50;

        await Task.WhenAll(
            EditCard.FadeTo(1, 450, Easing.CubicOut),
            EditCard.TranslateTo(0, 0, 500, Easing.CubicOut)
        );
    }
}
