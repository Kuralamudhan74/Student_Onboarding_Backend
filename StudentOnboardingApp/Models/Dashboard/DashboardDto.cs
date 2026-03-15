namespace StudentOnboardingApp.Models.Dashboard;

public class DashboardDto
{
    public string CourseName { get; set; } = string.Empty;
    public decimal AmountDue { get; set; }
    public string Duration { get; set; } = string.Empty;
    public string ApprovalStatus { get; set; } = string.Empty;
    public DateTime? EnrolledDate { get; set; }
    public string? BatchTiming { get; set; }
}
