using MedicalClinic.Appointments.Features.CreateAppointment.Contract;
using MedicalClinic.Appointments.Features.GetAppointments.Contract;
using MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;
using MedicalClinic.Calendar.Features.GetUserCalendar.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.Features.Calendar;

public class CalendarController : Controller
{
    private readonly ICreatePatientCalendarItemHandler _createPatientCalendarItemHandler;
    private readonly IGetUserCalendarHandler _getAppointmentsHandler;

    public CalendarController(
        ICreatePatientCalendarItemHandler createAppointmentHandler,
        IGetUserCalendarHandler createPatientCalendarItemHandler)
    {
        _createPatientCalendarItemHandler = createAppointmentHandler;
        _getAppointmentsHandler = createPatientCalendarItemHandler;
    }

    public async Task<IActionResult> Index()
    {
        return View(
            new CalendarIndexViewModel(
                await _getAppointmentsHandler.Handle()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
    {
        await _createPatientCalendarItemHandler.Handle(new(
            request.Reason,
            request.DoctorId,
            request.Date));

        return Ok();
    }
}
