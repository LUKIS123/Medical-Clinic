namespace MedicalClinic.Users.Features.IsUserADoctor.Contract;

public interface IIsUserADoctorHandler
{
    Task<bool> Handle();
}
