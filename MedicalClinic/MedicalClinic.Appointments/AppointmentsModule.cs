using MedicalClinic.Appointments.Features.CreateAppointment;
using MedicalClinic.Appointments.Features.CreateAppointment.Contract;
using MedicalClinic.Appointments.Features.GetAppointments;
using MedicalClinic.Appointments.Features.GetAppointments.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalClinic.Appointments;

public static class AppointmentsModule
{
    public static void AddAppointmentsModule(this IServiceCollection services)
    {
        services.AddTransient<ICreateAppointmentHandler, CreateAppointmentHandler>();
        services.AddTransient<IGetAppointmentsHandler, GetAppointmentsHandler>();
    }
}
