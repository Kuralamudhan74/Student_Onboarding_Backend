using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Onboarding_Platform.Extensions;
using Student_Onboarding_Platform.Models.DTOs.Student;
using Student_Onboarding_Platform.Services.Interfaces;

namespace Student_Onboarding_Platform.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]

//[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
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
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
