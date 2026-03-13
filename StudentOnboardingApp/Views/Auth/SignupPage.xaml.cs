using StudentOnboardingApp.ViewModels.Auth;

namespace StudentOnboardingApp.Views.Auth;

public partial class SignupPage : ContentPage
{
    private readonly SignupViewModel _viewModel;

    public SignupPage(SignupViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadCoursesCommand.ExecuteAsync(null);
    }
}
