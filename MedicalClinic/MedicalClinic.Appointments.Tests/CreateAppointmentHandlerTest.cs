using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.SharedKernel;
using NSubstitute;
using MedicalClinic.Appointments.Features.CreateAppointment;
using MedicalClinic.Appointments.Features.CreateAppointment.Contract;

namespace MedicalClinic.Appointments.Tests;

public class CreateAppointmentHandlerTest
{
    private CreateAppointmentHandler _sut;
    private IAppointmentRepository _appointmentRepository;
    private IUserAccessor _userAccessor;
    private IGuidProvider _guidProvider;

    [SetUp]
    public void Setup()
    {
        _appointmentRepository = Substitute.For<IAppointmentRepository>();
        _userAccessor = Substitute.For<IUserAccessor>();
        _guidProvider = Substitute.For<IGuidProvider>();
        _sut = new CreateAppointmentHandler(_appointmentRepository, _guidProvider, _userAccessor);
    }

    [Test]
    public async Task Handle_ShouldAddAppointment()
    {
        // Arrange
        var command = new CreateAppointmentCommand(
            "Reason",
            Guid.NewGuid(),
            DateTime.Now);

        var appointmentId = Guid.NewGuid();
        _guidProvider.NewGuid().Returns(appointmentId);

        var patientId = Guid.NewGuid();
        _userAccessor.UserId.Returns(patientId);

        // Act
        await _sut.Handle(command);

        // Assert
        await _appointmentRepository.Received().Add(Arg.Is<Appointment>(a =>
            a.Id == appointmentId &&
            a.Date == command.Date &&
            a.Reason == command.Reason &&
            a.DoctorId == command.DoctorId &&
            a.PatientId == patientId));
    }
}