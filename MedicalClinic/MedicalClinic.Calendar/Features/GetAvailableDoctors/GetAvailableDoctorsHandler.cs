using MedicalClinic.Calendar.Features.GetAvailableDoctors.Contract;
using MedicalClinic.Users.Features.GetAllDoctors.Contract;

namespace MedicalClinic.Calendar.Features.GetAvailableDoctors;

internal class GetAvailableDoctorsHandler : IGetAvailableDoctorsHandler
{
    private readonly IGetAllDoctorsHandler _getAvailableGetAllDoctorsHandler;

    public GetAvailableDoctorsHandler(IGetAllDoctorsHandler getAllDoctorsHandler)
    {
        _getAvailableGetAllDoctorsHandler = getAllDoctorsHandler;
    }

    public async Task<List<AvailableDoctor>> Handle()
    {
        var doctors = await _getAvailableGetAllDoctorsHandler.Handle();
        return doctors.Select(d => new AvailableDoctor
        {
            Id = d.Id,
            Name = string.Concat(d.FirstName, " ", d.LastName),
        }).ToList();
    }
}