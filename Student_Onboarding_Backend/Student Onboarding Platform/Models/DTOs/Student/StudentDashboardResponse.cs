namespace Student_Onboarding_Platform.Models.DTOs.Student;

public class StudentDashboardResponse
{
    public string ApprovalStatus { get; set; } = string.Empty;
    public int RegisteredCoursesCount { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
