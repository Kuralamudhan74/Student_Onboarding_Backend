using StudentOnboardingApp.Models.Common;
using StudentOnboardingApp.Models.Onboarding;

namespace StudentOnboardingApp.Services.Interfaces;

public interface IOnboardingService
{
    Task<ApiResponse<string>> GetApprovalStatusAsync();
    Task<ApiResponse<List<OnboardingInstructionDto>>> GetInstructionsAsync();
    Task<ApiResponse<string>> AcceptOnboardingAsync();
}
