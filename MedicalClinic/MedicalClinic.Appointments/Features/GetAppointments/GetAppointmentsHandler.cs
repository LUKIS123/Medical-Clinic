using MedicalClinic.Appointments.Features.GetAppointments.Contract;
using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.SharedKernel;

namespace MedicalClinic.Appointments.Features.GetAppointments;

internal class GetAppointmentsHandler : IGetAppointmentsHandler
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserAccessor _userAccessor;

    public GetAppointmentsHandler(
        IAppointmentRepository appointmentRepository,
        IUserAccessor userAccessor)
    {
        _appointmentRepository = appointmentRepository;
        _userAccessor = userAccessor;
    }

    public async Task<List<Appointment>> Handle() =>
        await GetAppointments();

    private Task<List<Appointment>> GetAppointments() =>
        _userAccessor.UserType switch
        {
            UserType.Doctor => _appointmentRepository.GetByDoctorId(_userAccessor.UserId),
            UserType.Patient => _appointmentRepository.GetByPatientId(_userAccessor.UserId),
            _ => throw new InvalidOperationException("Invalid user type.")
        };
}
