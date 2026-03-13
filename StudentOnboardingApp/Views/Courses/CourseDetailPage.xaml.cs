using StudentOnboardingApp.ViewModels;

namespace StudentOnboardingApp.Views.Courses;

public partial class CourseDetailPage : ContentPage
{
    public CourseDetailPage(CourseDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
