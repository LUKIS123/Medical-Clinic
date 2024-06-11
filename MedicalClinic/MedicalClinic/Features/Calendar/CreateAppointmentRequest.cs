namespace MedicalClinic.Features.Calendar;

public record CreateAppointmentRequest(
    string Reason,
    Guid DoctorId,
    DateTime Date);