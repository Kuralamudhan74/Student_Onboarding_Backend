using Student_Onboarding_Platform.Data.Repositories.Interfaces;
using Student_Onboarding_Platform.Models.Entities;
using Student_Onboarding_Platform.Services.Interfaces;

namespace Student_Onboarding_Platform.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public async Task UpdateEmailVerifiedAsync(Guid userId)
    {
        await _userRepository.UpdateEmailVerifiedAsync(userId);
    }

    public async Task UpdatePasswordAsync(Guid userId, string passwordHash)
    {
        await _userRepository.UpdatePasswordAsync(userId, passwordHash, DateTime.UtcNow);
    }

    public async Task UpdateLastLoginAsync(Guid userId)
    {
        await _userRepository.UpdateLastLoginAsync(userId, DateTime.UtcNow);
    }
}
