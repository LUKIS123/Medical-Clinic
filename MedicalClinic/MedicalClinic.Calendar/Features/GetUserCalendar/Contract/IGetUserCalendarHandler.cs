namespace MedicalClinic.Calendar.Features.GetUserCalendar.Contract;

public interface IGetUserCalendarHandler
{
    Task<List<UserCalendarItem>> Handle();
}
