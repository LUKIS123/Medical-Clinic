namespace MedicalClinic.Appointments.Features.CreateAppointment.Contract;

public interface ICreateAppointmentHandler
{
    Task Handle(CreateAppointmentCommand command);
}
