using MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;
using MedicalClinic.Calendar.Features.GetAvailableDoctors.Contract;
using MedicalClinic.Calendar.Features.GetUserCalendar.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.Features.Calendar;

public class CalendarController : Controller
{
    private readonly ICreatePatientCalendarItemHandler _createPatientCalendarItemHandler;
    private readonly IGetUserCalendarHandler _getAppointmentsHandler;
    private readonly IGetAvailableDoctorsHandler _getAvailableDoctorsHandler;

    public CalendarController(
        ICreatePatientCalendarItemHandler createAppointmentHandler,
        IGetUserCalendarHandler createPatientCalendarItemHandler,
        IGetAvailableDoctorsHandler getAvailableDoctorsHandler)
    {
        _createPatientCalendarItemHandler = createAppointmentHandler;
        _getAppointmentsHandler = createPatientCalendarItemHandler;
        _getAvailableDoctorsHandler = getAvailableDoctorsHandler;
    }

    public async Task<IActionResult> Index()
    {
        return View(
            new CalendarIndexViewModel(
                await _getAppointmentsHandler.Handle()));
    }

    public IActionResult CreateAppointment()
    {
        return View();
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

    [HttpGet]
    public async Task<IActionResult> GetAvailableDoctors()
    {
        var availableDoctors = await _getAvailableDoctorsHandler.Handle();
        return Ok(availableDoctors);
    }
}