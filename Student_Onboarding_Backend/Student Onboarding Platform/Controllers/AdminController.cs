using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Onboarding_Platform.Extensions;
using Student_Onboarding_Platform.Models.DTOs.Admin;
using Student_Onboarding_Platform.Services.Interfaces;

namespace Student_Onboarding_Platform.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]

//[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly ICourseService _courseService;
    private readonly INotificationService _notificationService;

    public AdminController(
        IAdminService adminService,
        ICourseService courseService,
        INotificationService notificationService)
    {
        _adminService = adminService;
        _courseService = courseService;
        _notificationService = notificationService;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var result = await _adminService.GetDashboardAsync();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetStudents(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? status = null,
        [FromQuery] string? search = null)
    {
        var result = await _adminService.GetStudentsAsync(page, pageSize, status, search);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("students/{id}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var result = await _adminService.GetStudentByIdAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("students/{id}")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentRequest request)
    {
        var result = await _adminService.UpdateStudentAsync(id, request);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("students/{id}/approve")]
    public async Task<IActionResult> ApproveStudent(Guid id)
    {
        var adminId = User.GetUserId();
        var result = await _adminService.ApproveStudentAsync(id, adminId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("students/{id}/deny")]
    public async Task<IActionResult> DenyStudent(Guid id, [FromBody] DenyStudentRequest request)
    {
        var adminId = User.GetUserId();
        var result = await _adminService.DenyStudentAsync(id, adminId, request);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("notifications")]
    public async Task<IActionResult> GetNotifications()
    {
        var adminId = User.GetUserId();
        var result = await _notificationService.GetNotificationsAsync(adminId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("notifications/unread-count")]
    public async Task<IActionResult> GetUnreadCount()
    {
        var adminId = User.GetUserId();
        var result = await _notificationService.GetUnreadCountAsync(adminId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("notifications/{id}/read")]
    public async Task<IActionResult> MarkNotificationAsRead(Guid id)
    {
        var adminId = User.GetUserId();
        var result = await _notificationService.MarkAsReadAsync(id, adminId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("courses")]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
    {
        var adminId = User.GetUserId();
        var result = await _courseService.CreateCourseAsync(request, adminId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("courses/{id}")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseRequest request)
    {
        var result = await _courseService.UpdateCourseAsync(id, request);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("courses/{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        var result = await _courseService.DeleteCourseAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("course-registrations")]
    public async Task<IActionResult> GetCourseRegistrations(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _adminService.GetCourseRegistrationsAsync(page, pageSize);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("course-registrations/{id}/payment")]
    public async Task<IActionResult> UpdatePayment(Guid id, [FromBody] UpdatePaymentRequest request)
    {
        var result = await _adminService.UpdatePaymentAsync(id, request);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
