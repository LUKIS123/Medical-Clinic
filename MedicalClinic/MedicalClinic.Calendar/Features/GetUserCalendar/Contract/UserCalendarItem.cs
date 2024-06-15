using MedicalClinic.Users.Features.Shared;

namespace MedicalClinic.Calendar.Features.GetUserCalendar.Contract;

public readonly record struct UserCalendarItem(
    Guid Id,
    DateTime Date,
    string? Reason,
    User? Doctor,
    User? Patient);