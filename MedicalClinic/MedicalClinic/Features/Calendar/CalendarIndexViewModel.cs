using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.Calendar.Features.GetUserCalendar.Contract;

namespace MedicalClinic.Features.Calendar;

public record CalendarIndexViewModel(
    List<UserCalendarItem> Appointments);