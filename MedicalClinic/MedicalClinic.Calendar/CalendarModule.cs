using MedicalClinic.Calendar.Features.CreatePatientCalendarItem;
using MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;
using MedicalClinic.Calendar.Features.GetUserCalendar;
using MedicalClinic.Calendar.Features.GetUserCalendar.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalClinic.Calendar;

public static class CalendarModule
{
    public static void AddCalendarModule(this IServiceCollection services)
    {
        services.AddTransient<IGetUserCalendarHandler, GetUserCalendarHandler>();
        services.AddTransient<ICreatePatientCalendarItemHandler, CreatePatientCalendarItemHandler>();
    }
}
