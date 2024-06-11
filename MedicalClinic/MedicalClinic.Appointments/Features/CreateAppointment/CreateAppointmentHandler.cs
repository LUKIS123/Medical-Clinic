using MedicalClinic.Appointments.Features.CreateAppointment.Contract;
using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.SharedKernel;

namespace MedicalClinic.Appointments.Features.CreateAppointment;

internal class CreateAppointmentHandler : ICreateAppointmentHandler
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IGuidProvider _guidProvider;
    private readonly IUserAccessor _userAccessor;

    public CreateAppointmentHandler(
        IAppointmentRepository appointmentRepository,
        IGuidProvider guidProvider,
        IUserAccessor userAccessor)
    {
        _appointmentRepository = appointmentRepository;
        _guidProvider = guidProvider;
        _userAccessor = userAccessor;
    }

    public async Task Handle(CreateAppointmentCommand command) =>
        await _appointmentRepository.Add(new(
            _guidProvider.NewGuid(),
            command.Date,
            command.Reason,
            command.DoctorId,
            _userAccessor.UserId));
}
