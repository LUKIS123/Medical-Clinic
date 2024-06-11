namespace MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;

public record CreatePatientCalendarItemCommand(
    string? Reason,
    Guid DoctorId,
    DateTime Date);
