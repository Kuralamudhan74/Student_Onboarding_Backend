using Dapper;
using Student_Onboarding_Platform.Data.Repositories.Interfaces;
using Student_Onboarding_Platform.Models.Entities;

namespace Student_Onboarding_Platform.Data.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly DbConnectionFactory _db;

    public UserRepository(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Id = @Id AND IsDeleted = @IsDeleted",
            new { Id = id, IsDeleted = false });
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Email = @Email AND IsDeleted = @IsDeleted",
            new { Email = email, IsDeleted = false });
    }

    public async Task<User> CreateAsync(User user)
    {
        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.UtcNow;

        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(@"
            INSERT INTO Users (Id, FirstName, LastName, Email, PhoneNumber, PasswordHash,
                EmailVerified, PhoneVerified, IsActive, IsDeleted, Role, CreatedAt)
            VALUES (@Id, @FirstName, @LastName, @Email, @PhoneNumber, @PasswordHash,
                @EmailVerified, @PhoneVerified, @IsActive, @IsDeleted, @Role, @CreatedAt)",
            user);

        return user;
    }

    public async Task UpdateEmailVerifiedAsync(Guid userId)
    {
        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(
            "UPDATE Users SET EmailVerified = @EmailVerified, UpdatedAt = @UpdatedAt WHERE Id = @Id",
            new { Id = userId, EmailVerified = true, UpdatedAt = DateTime.UtcNow });
    }

    public async Task UpdatePasswordAsync(Guid userId, string passwordHash, DateTime passwordUpdatedAt)
    {
        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(
            "UPDATE Users SET PasswordHash = @PasswordHash, PasswordUpdatedAt = @PasswordUpdatedAt, UpdatedAt = @UpdatedAt WHERE Id = @Id",
            new { Id = userId, PasswordHash = passwordHash, PasswordUpdatedAt = passwordUpdatedAt, UpdatedAt = DateTime.UtcNow });
    }

    public async Task UpdateLastLoginAsync(Guid userId, DateTime lastLoginAt)
    {
        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(
            "UPDATE Users SET LastLoginAt = @LastLoginAt WHERE Id = @Id",
            new { Id = userId, LastLoginAt = lastLoginAt });
    }
}
