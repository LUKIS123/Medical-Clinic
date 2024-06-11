using MedicalClinic.Appointments.Features.Shared;

namespace MedicalClinic.Appointments.Features.GetAppointments.Contract;

public interface IGetAppointmentsHandler
{
    Task<List<Appointment>> Handle();
}
