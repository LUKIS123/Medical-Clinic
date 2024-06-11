using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Users.Features.GetUsers.Contract;

public interface IGetUsersHandler
{
    Task<Dictionary<Guid, User>> Handle(GetUsersHandlerQuery query);
}
