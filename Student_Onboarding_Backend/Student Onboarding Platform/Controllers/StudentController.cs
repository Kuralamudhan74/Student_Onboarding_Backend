using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Onboarding_Platform.Extensions;
using Student_Onboarding_Platform.Models.DTOs.Student;
using Student_Onboarding_Platform.Services.Interfaces;

namespace Student_Onboarding_Platform.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly INotificationService _notificationService;

    public StudentController(IStudentService studentService, INotificationService notificationService)
    {
        _studentService = studentService;
        _notificationService = notificationService;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.GetUserId();
        var result = await _studentService.GetProfileAsync(userId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        var userId = User.GetUserId();
        var result = await _studentService.UpdateProfileAsync(userId, request);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("profile/photo")]
    public async Task<IActionResult> UploadProfilePhoto(IFormFile photo)
    {
        if (photo == null || photo.Length == 0)
            return BadRequest(new { success = false, message = "No photo provided." });

        var userId = User.GetUserId();
        var result = await _studentService.UploadProfilePhotoAsync(userId, photo);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var userId = User.GetUserId();
        var result = await _studentService.GetDashboardAsync(userId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("courses")]
    public async Task<IActionResult> GetRegisteredCourses()
    {
        var userId = User.GetUserId();
        var result = await _studentService.GetRegisteredCoursesAsync(userId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("courses/register")]
    public async Task<IActionResult> RegisterForCourse([FromBody] CourseRegistrationRequest request)
    {
        var userId = User.GetUserId();
        var result = await _studentService.RegisterForCourseAsync(userId, request);

        if (result.Success)
        {
            await _notificationService.CreateStudentNotificationAsync(
                userId,
                "CourseRegistration",
                "Course Registration Submitted",
                "Your course registration has been submitted successfully. Please wait for admin approval.",
                request.CourseId);
        }

        return result.Success ? Ok(result) : BadRequest(result);
    }

    // Student Notification Endpoints

    [HttpGet("notifications")]
    public async Task<IActionResult> GetNotifications()
    {
        var userId = User.GetUserId();
        var result = await _notificationService.GetStudentNotificationsAsync(userId);
        return Ok(result);
    }

    [HttpPut("notifications/{id}/read")]
    public async Task<IActionResult> MarkNotificationAsRead(Guid id)
    {
        var userId = User.GetUserId();
        var result = await _notificationService.MarkStudentNotificationAsReadAsync(id, userId);
        return Ok(result);
    }
}
