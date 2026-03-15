using StudentOnboardingApp.Helpers;
using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;

        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(viewModel.PasswordMessage))
            {
                PasswordMsgBorder.IsVisible = !string.IsNullOrEmpty(viewModel.PasswordMessage);
                PasswordMsgBorder.BackgroundColor = viewModel.IsPasswordMessageError
                    ? (Color)Application.Current!.Resources["DangerLight"]
                    : (Color)Application.Current!.Resources["SuccessLight"];
                PasswordMsgBorder.Stroke = viewModel.IsPasswordMessageError
                    ? (Color)Application.Current!.Resources["Danger"]
                    : (Color)Application.Current!.Resources["Success"];
            }
        };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadProfileCommand.ExecuteAsync(null);

        await AnimationHelper.FadeUpAsync(NameLabel, delay: 100);
        _ = AnimationHelper.FadeUpAsync(InfoCard, delay: 200);
        _ = AnimationHelper.FadeUpAsync(SecurityCard, delay: 300);
        _ = AnimationHelper.FadeUpAsync(LogoutButton, delay: 400);
    }
}
