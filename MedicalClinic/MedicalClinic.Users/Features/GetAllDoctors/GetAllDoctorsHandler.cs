using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.GetAllDoctors.Contract;
using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Users.Features.GetAllDoctors;

internal class GetAllDoctorsHandler : IGetAllDoctorsHandler
{
    private readonly IUserRepository _userRepository;

    public GetAllDoctorsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle() =>
        await _userRepository.GetByType(UserType.Doctor);
}