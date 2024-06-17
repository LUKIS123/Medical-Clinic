using FluentAssertions;
using MedicalClinic.Appointments.Features.CreateAppointment.Contract;
using MedicalClinic.Calendar.Features.CreatePatientCalendarItem;
using MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;
using MedicalClinic.Users.Features.IsUserADoctor.Contract;
using NSubstitute;

namespace MedicalClinic.Calendar.Tests;

public class CreatePatientCalendarItemHandlerTest
{
    private CreatePatientCalendarItemHandler _sut;
    private ICreateAppointmentHandler _createAppointmentHandler;
    private IIsUserADoctorHandler _isUserADoctorHandler;

    [SetUp]
    public void Setup()
    {
        _createAppointmentHandler = Substitute.For<ICreateAppointmentHandler>();
        _isUserADoctorHandler = Substitute.For<IIsUserADoctorHandler>();
        _sut = new CreatePatientCalendarItemHandler(_createAppointmentHandler, _isUserADoctorHandler);
    }

    [Test]
    public async Task Handle_WhenUserIsDoctor_ShouldThrowInvalidOperationException()
    {
        // Arrange
        _isUserADoctorHandler.Handle().Returns(true);

        // Act
        Func<Task> act = async () =>
            await _sut.Handle(new("test", Guid.NewGuid(), DateTime.Now));

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Doctor cannot create patient calendar items");
    }

    [Test]
    public async Task Handle_WhenUserIsNotDoctor_ShouldCreateAppointment()
    {
        // Arrange
        _isUserADoctorHandler.Handle().Returns(false);
        var createCalendarItemCommand = new CreatePatientCalendarItemCommand("test", Guid.NewGuid(), DateTime.Now);

        // Act
        await _sut.Handle(createCalendarItemCommand);

        // Assert
        await _createAppointmentHandler.Received().Handle(Arg.Is<CreateAppointmentCommand>(x =>
            x.Reason == createCalendarItemCommand.Reason &&
            x.DoctorId == createCalendarItemCommand.DoctorId &&
            x.Date == createCalendarItemCommand.Date));
    }
}