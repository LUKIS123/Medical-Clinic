namespace MedicalClinic.Calendar.Features.GetAvailableDoctors.Contract;

public interface IGetAvailableDoctorsHandler
{
    Task<List<AvailableDoctor>> Handle();
}