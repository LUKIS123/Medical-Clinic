using FluentAssertions;
using MedicalClinic.Appointments.Features.GetAppointments;
using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.SharedKernel;
using NSubstitute;

namespace MedicalClinic.Appointments.Tests;

public class GetAppointmentsHandlerTest
{
    private GetAppointmentsHandler _sut;
    private IAppointmentRepository _appointmentRepository;
    private IUserAccessor _userAccessor;

    [SetUp]
    public void Setup()
    {
        _appointmentRepository = Substitute.For<IAppointmentRepository>();
        _userAccessor = Substitute.For<IUserAccessor>();
        _sut = new GetAppointmentsHandler(_appointmentRepository, _userAccessor);
    }

    [Test]
    public async Task Handle_WhenUserTypeIsDoctor_ShouldReturnAppointmentsByDoctorId()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        _userAccessor.UserType.Returns(UserType.Doctor);
        _userAccessor.UserId.Returns(doctorId);

        var appointments = new List<Appointment>
        {
            new() { Id = Guid.NewGuid(), DoctorId = doctorId },
            new() { Id = Guid.NewGuid(), DoctorId = doctorId }
        };

        _appointmentRepository.GetByDoctorId(doctorId).Returns(appointments);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(appointments);
    }

    [Test]
    public async Task Handle_WhenUserTypeIsPatient_ShouldReturnAppointmentsByPatientId()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        _userAccessor.UserType.Returns(UserType.Patient);
        _userAccessor.UserId.Returns(patientId);

        var appointments = new List<Appointment>
        {
            new() { Id = Guid.NewGuid(), PatientId = patientId },
            new() { Id = Guid.NewGuid(), PatientId = patientId }
        };

        _appointmentRepository.GetByPatientId(patientId).Returns(appointments);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(appointments);
    }
}