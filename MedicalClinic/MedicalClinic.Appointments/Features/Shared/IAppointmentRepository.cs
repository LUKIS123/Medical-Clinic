namespace MedicalClinic.Appointments.Features.Shared;

public interface IAppointmentRepository
{
    Task Add(Appointment appointment);
    Task<List<Appointment>> GetByPatientId(Guid patientId);
    Task<List<Appointment>> GetByDoctorId(Guid doctorId);
}
