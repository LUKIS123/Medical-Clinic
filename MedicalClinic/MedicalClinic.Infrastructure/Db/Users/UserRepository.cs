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
            .Select(u => new User(
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.Phone,
                u.UserTypeId))
            .ToListAsync();

    public async Task<UserType?> GetUserType(Guid userId) =>
        await _dbContext.Users
            .Where(u => u.Id == userId)
            .Select(u => u.UserTypeId)
            .FirstOrDefaultAsync();
}
