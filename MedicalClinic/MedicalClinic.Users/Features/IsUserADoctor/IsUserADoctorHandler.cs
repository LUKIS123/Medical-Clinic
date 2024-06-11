using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.IsUserADoctor.Contract;
using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Users.Features.IsUserADoctor;

internal class IsUserADoctorHandler : IIsUserADoctorHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUserAccessor _userAccessor;

    public IsUserADoctorHandler(
        IUserRepository userRepository,
        IUserAccessor userAccessor)
    {
        _userRepository = userRepository;
        _userAccessor = userAccessor;
    }

    public async Task<bool> Handle() =>
        await _userRepository.GetUserType(_userAccessor.UserId) == UserType.Doctor;
}
