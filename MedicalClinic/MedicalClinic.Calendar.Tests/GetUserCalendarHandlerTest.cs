using FluentAssertions;
using MedicalClinic.Appointments.Features.GetAppointments.Contract;
using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.Calendar.Features.GetUserCalendar;
using MedicalClinic.Users.Features.GetUsers.Contract;
using MedicalClinic.Users.Features.Shared;
using NSubstitute;

namespace MedicalClinic.Calendar.Tests;

public class Tests
{
    private GetUserCalendarHandler _sut;
    private IGetAppointmentsHandler _getAppointmentsHandler;
    private IGetUsersHandler _getUsersHandler;

    [SetUp]
    public void Setup()
    {
        _getAppointmentsHandler = Substitute.For<IGetAppointmentsHandler>();
        _getUsersHandler = Substitute.For<IGetUsersHandler>();
        _sut = new GetUserCalendarHandler(_getAppointmentsHandler, _getUsersHandler);
    }

    [Test]
    public async Task Handle_WhenAppointmentsExist_ReturnsUserCalendarItems()
    {
        // Arrange
        var appointments = new List<Appointment>
        {
            new() { Id = Guid.NewGuid(), DoctorId = Guid.NewGuid(), PatientId = Guid.NewGuid() },
            new() { Id = Guid.NewGuid(), DoctorId = Guid.NewGuid(), PatientId = Guid.NewGuid() }
        };
        _getAppointmentsHandler.Handle().Returns(appointments);

        var users = new Dictionary<Guid, User>
        {
            {
                appointments[0].DoctorId,
                new() { Id = appointments[0].DoctorId, FirstName = "John", LastName = "Wolf" }
            },
            {
                appointments[0].PatientId,
                new() { Id = appointments[0].PatientId, FirstName = "Alice", LastName = "Smith" }
            },
            {
                appointments[1].DoctorId,
                new() { Id = appointments[1].DoctorId, FirstName = "Bob", LastName = "Brown" }
            },
            {
                appointments[1].PatientId,
                new() { Id = appointments[1].PatientId, FirstName = "Eve", LastName = "White" }
            }
        };
        _getUsersHandler.Handle(Arg.Any<GetUsersHandlerQuery>()).Returns(users);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].Doctor.Should().BeEquivalentTo(users[appointments[0].DoctorId]);
        result[0].Patient.Should().BeEquivalentTo(users[appointments[0].PatientId]);
        result[1].Doctor.Should().BeEquivalentTo(users[appointments[1].DoctorId]);
        result[1].Patient.Should().BeEquivalentTo(users[appointments[1].PatientId]);
    }
}