using MedicalClinic.Users.Features.GetUsers.Contract;
using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Users.Features.GetUsers;

internal class GetUsersHandler : IGetUsersHandler
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Dictionary<Guid, User>> Handle(GetUsersHandlerQuery query) =>
        GetUsersDictionary(
            await _userRepository.GetByIds(query.UserIds));

    private Dictionary<Guid, User> GetUsersDictionary(IEnumerable<User> users) =>
        users.ToDictionary(u => u.Id, u => u);
}