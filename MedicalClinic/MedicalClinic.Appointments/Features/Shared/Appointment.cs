namespace MedicalClinic.Appointments.Features.Shared;

public readonly record struct Appointment(
    Guid Id,
    DateTime Date,
    string Reason,
    Guid DoctorId,
    Guid PatientId);
