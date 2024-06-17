using FluentAssertions;
using MedicalClinic.Calendar.Features.GetAvailableDoctors;
using MedicalClinic.Calendar.Features.GetAvailableDoctors.Contract;
using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.GetAllDoctors.Contract;
using MedicalClinic.Users.Features.Shared;
using NSubstitute;

namespace MedicalClinic.Calendar.Tests;

public class GetAvailableDoctorsHandlerTest
{
    private GetAvailableDoctorsHandler _sut;
    private IGetAllDoctorsHandler _getAllDoctorsHandler;

    [SetUp]
    public void Setup()
    {
        _getAllDoctorsHandler = Substitute.For<IGetAllDoctorsHandler>();
        _sut = new GetAvailableDoctorsHandler(_getAllDoctorsHandler);
    }

    [Test]
    public async Task Handle_WhenDoctorsExist_ReturnsListOfDoctors()
    {
        // Arrange
        var expected = new List<User>
        {
            new(Guid.NewGuid(), "John", "Wolf", "jw@test.com", "123123123", UserType.Doctor)
        };
        _getAllDoctorsHandler.Handle().Returns(expected);
        var availableDoctors = expected.Select(x => new AvailableDoctor(x.Id, $"{x.FirstName} {x.LastName}")).ToList();

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(availableDoctors);
    }
}