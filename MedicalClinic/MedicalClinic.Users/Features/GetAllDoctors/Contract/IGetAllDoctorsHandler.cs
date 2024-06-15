using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Users.Features.GetAllDoctors.Contract;

public interface IGetAllDoctorsHandler
{
    Task<List<User>> Handle();
}