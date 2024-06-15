using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Infrastructure.Db.Users;

internal class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetByIds(IEnumerable<Guid> userIds) =>
        await _dbContext.Users
            .Where(u => userIds.Contains(u.Id))
            .Select(u => MapUser(u))
            .ToListAsync();

    public async Task<UserType?> GetUserType(Guid userId) =>
        await _dbContext.Users
            .Where(u => u.Id == userId)
            .Select(u => u.UserTypeId)
            .FirstOrDefaultAsync();

    public async Task<List<User>> GetByType(UserType userType)
    {
        return await _dbContext.Users
            .Where(u => u.UserTypeId == userType)
            .Select(u => MapUser(u))
            .ToListAsync();
    }

    private static User MapUser(UserEntity user) =>
        new(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            user.UserTypeId);
}