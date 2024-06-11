using MedicalClinic.Appointments.Features.CreateAppointment.Contract;
using MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;
using MedicalClinic.Users.Features.IsUserADoctor.Contract;

namespace MedicalClinic.Calendar.Features.CreatePatientCalendarItem;

internal class CreatePatientCalendarItemHandler : ICreatePatientCalendarItemHandler
{
    private readonly ICreateAppointmentHandler _createAppointmentHandler;
    private readonly IIsUserADoctorHandler _isUserADoctorHandler;

    public CreatePatientCalendarItemHandler(
        ICreateAppointmentHandler createAppointmentHandler,
        IIsUserADoctorHandler isUserADoctorHandler)
    {
        _createAppointmentHandler = createAppointmentHandler;
        _isUserADoctorHandler = isUserADoctorHandler;
    }

    public async Task Handle(CreatePatientCalendarItemCommand command)
    {
        if (await _isUserADoctorHandler.Handle())
        {
            throw new InvalidOperationException("Doctor cannot create patient calendar items");
        }

        await _createAppointmentHandler.Handle(new(
            command.Reason,
            command.DoctorId,
            command.Date));
    }
}
