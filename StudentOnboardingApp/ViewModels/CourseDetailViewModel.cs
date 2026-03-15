using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentOnboardingApp.Models.Course;
using StudentOnboardingApp.Services.Interfaces;

namespace StudentOnboardingApp.ViewModels;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDetailViewModel : BaseViewModel
{
    private readonly ICourseService _courseService;

    public CourseDetailViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        Title = "Course Details";
    }

    [ObservableProperty]
    private string _courseId = string.Empty;

    [ObservableProperty]
    private CourseDetailDto? _course;

    partial void OnCourseIdChanged(string value)
    {
        if (Guid.TryParse(value, out _))
            LoadCourseCommand.ExecuteAsync(null);
    }

    [RelayCommand]
    private async Task LoadCourseAsync()
    {
        await ExecuteAsync(async () =>
        {
            if (Guid.TryParse(CourseId, out var id))
            {
                var result = await _courseService.GetCourseDetailAsync(id);
                if (result.Success && result.Data != null)
                {
                    Course = result.Data;
                    Title = result.Data.Name;
                }
                else
                {
                    ErrorMessage = result.Message;
                }
            }
        });
    }

    [RelayCommand]
    private async Task ApplyAsync()
    {
        if (Course == null) return;

        await ExecuteAsync(async () =>
        {
            var request = new CourseApplicationRequest { CourseId = Course.Id };
            var result = await _courseService.ApplyForCourseAsync(request);

            if (result.Success)
            {
                await Shell.Current.DisplayAlert("Success", "Course application submitted successfully!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                ErrorMessage = result.Message;
            }
        });
    }
}
