using FluentAssertions;
using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.GetAllDoctors;
using MedicalClinic.Users.Features.Shared;
using NSubstitute;

namespace MedicalClinic.Users.Tests;

public class GetAllDoctorsHandlerTest
{
    private GetAllDoctorsHandler _sut;
    private IUserRepository _userRepository;

    [SetUp]
    public void Setup()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _sut = new GetAllDoctorsHandler(_userRepository);
    }

    [Test]
    public async Task Handle_WhenDoctorsExist_ReturnsListOfDoctors()
    {
        // Arrange
        var expected = new List<User>
        {
            new(Guid.NewGuid(), "John", "Wolf", "jw@test.com", "111111111", UserType.Doctor),
        };
        _userRepository.GetByType(UserType.Doctor).Returns(expected);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public async Task Handle_WhenDoctorsExist_ReturnsEmptyList()
    {
        // Arrange
        var expected = new List<User>();
        _userRepository.GetByType(UserType.Doctor).Returns(expected);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }
}