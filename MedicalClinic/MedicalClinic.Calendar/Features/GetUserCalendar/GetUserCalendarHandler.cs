using MedicalClinic.Appointments.Features.GetAppointments.Contract;
using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.Calendar.Features.GetUserCalendar.Contract;
using MedicalClinic.Users.Features.GetUsers.Contract;

namespace MedicalClinic.Calendar.Features.GetUserCalendar;

internal class GetUserCalendarHandler : IGetUserCalendarHandler
{
    private readonly IGetAppointmentsHandler _getAppointmentsHandler;
    private readonly IGetUsersHandler _getUsersHandler;

    public GetUserCalendarHandler(
        IGetAppointmentsHandler getAppointmentsHandler,
        IGetUsersHandler getUsersHandler)
    {
        _getAppointmentsHandler = getAppointmentsHandler;
        _getUsersHandler = getUsersHandler;
    }

    public async Task<List<UserCalendarItem>> Handle()
    {
        var appointments = await _getAppointmentsHandler.Handle();
        var users = await _getUsersHandler.Handle(new(GetUserIds(appointments)));

        return appointments
            .Select(x => new UserCalendarItem(
                x.Id,
                x.Date,
                x.Reason,
                users.GetValueOrDefault(x.DoctorId),
                users.GetValueOrDefault(x.PatientId)))
            .ToList();
    }

    private IEnumerable<Guid> GetUserIds(IEnumerable<Appointment> appointments) =>
        appointments
            .SelectMany(x => new Guid[] { x.DoctorId, x.PatientId })
            .ToHashSet();
}