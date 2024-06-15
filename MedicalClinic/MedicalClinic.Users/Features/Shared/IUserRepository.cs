using MedicalClinic.SharedKernel;

namespace MedicalClinic.Users.Features.Shared;

public interface IUserRepository
{
    Task<List<User>> GetByIds(IEnumerable<Guid> userIds);
    Task<UserType?> GetUserType(Guid userId);
    Task<List<User>> GetByType(UserType userType);
}