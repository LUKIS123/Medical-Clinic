using FluentAssertions;
using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.IsUserADoctor;
using MedicalClinic.Users.Features.Shared;
using NSubstitute;

namespace MedicalClinic.Users.Tests;

public class IsUserADoctorHandlerTest
{
    private IsUserADoctorHandler _sut;
    private IUserRepository _userRepository;
    private IUserAccessor _userAccessor;

    [SetUp]
    public void Setup()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _userAccessor = Substitute.For<IUserAccessor>();
        _sut = new IsUserADoctorHandler(_userRepository, _userAccessor);
    }

    [Test]
    public async Task Handle_WhenUserIsDoctor_ReturnsTrue()
    {
        // Arrange
        _userAccessor.UserId.Returns(Guid.NewGuid());
        _userRepository.GetUserType(_userAccessor.UserId).Returns(UserType.Doctor);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public async Task Handle_WhenUserIsNotDoctor_ReturnsFalse()
    {
        // Arrange
        _userAccessor.UserId.Returns(Guid.NewGuid());
        _userRepository.GetUserType(_userAccessor.UserId).Returns(UserType.Patient);

        // Act
        var result = await _sut.Handle();

        // Assert
        result.Should().BeFalse();
    }
}