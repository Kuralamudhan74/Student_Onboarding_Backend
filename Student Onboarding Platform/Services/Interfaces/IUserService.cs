using Student_Onboarding_Platform.Models.Entities;

namespace Student_Onboarding_Platform.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    Task<User> CreateAsync(User user);
    Task UpdateEmailVerifiedAsync(Guid userId);
    Task UpdatePasswordAsync(Guid userId, string passwordHash);
    Task UpdateLastLoginAsync(Guid userId);
}
