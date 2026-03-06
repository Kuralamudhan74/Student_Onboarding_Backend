using Student_Onboarding_Platform.Models.Entities;

namespace Student_Onboarding_Platform.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(User user);
    Task UpdateEmailVerifiedAsync(Guid userId);
    Task UpdatePasswordAsync(Guid userId, string passwordHash, DateTime passwordUpdatedAt);
    Task UpdateLastLoginAsync(Guid userId, DateTime lastLoginAt);
}
