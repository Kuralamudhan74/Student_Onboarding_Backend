using Dapper;
using Student_Onboarding_Platform.Models.Entities;
using Student_Onboarding_Platform.Data.Repositories.Interfaces;

namespace Student_Onboarding_Platform.Data.Repositories.Implementations;

public class FaqRepository : IFaqRepository
{
    private readonly DbConnectionFactory _db;

    public FaqRepository(DbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<Faq> CreateAsync(Faq faq)
    {
        faq.Id = Guid.NewGuid();
        faq.CreatedAt = DateTime.UtcNow;

        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(@"
            INSERT INTO Faqs (Id, Question, Answer, SortOrder, IsActive, IsDeleted, CreatedBy, CreatedAt)
            VALUES (@Id, @Question, @Answer, @SortOrder, @IsActive, @IsDeleted, @CreatedBy, @CreatedAt)",
            faq);

        return faq;
    }

    public async Task<Faq?> GetByIdAsync(Guid id)
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<Faq>(
            "SELECT * FROM Faqs WHERE Id = @Id AND IsDeleted = 0",
            new { Id = id });
    }

    public async Task<IEnumerable<Faq>> GetAllAsync()
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryAsync<Faq>(
            "SELECT * FROM Faqs WHERE IsDeleted = 0 ORDER BY SortOrder, CreatedAt");
    }

    public async Task<IEnumerable<Faq>> GetActiveAsync()
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryAsync<Faq>(
            "SELECT * FROM Faqs WHERE IsDeleted = 0 AND IsActive = 1 ORDER BY SortOrder, CreatedAt");
    }

    public async Task UpdateAsync(Faq faq)
    {
        faq.UpdatedAt = DateTime.UtcNow;

        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE Faqs SET Question = @Question, Answer = @Answer, SortOrder = @SortOrder,
                IsActive = @IsActive, UpdatedAt = @UpdatedAt
            WHERE Id = @Id",
            faq);
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        using var conn = _db.CreateConnection();
        await conn.ExecuteAsync(
            "UPDATE Faqs SET IsDeleted = 1, UpdatedAt = @UpdatedAt WHERE Id = @Id",
            new { Id = id, UpdatedAt = DateTime.UtcNow });
    }
}
