namespace MedicalClinic.Appointments.Features.CreateAppointment.Contract;

public record CreateAppointmentCommand(
    string? Reason,
    Guid DoctorId,
    DateTime Date);