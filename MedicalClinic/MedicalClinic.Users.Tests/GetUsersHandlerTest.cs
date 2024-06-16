using MedicalClinic.Users.Features.Shared;
using NSubstitute;
using FluentAssertions;
using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.GetUsers;
using MedicalClinic.Users.Features.GetUsers.Contract;

namespace MedicalClinic.Users.Tests;

public class GetUsersHandlerTest
{
    private GetUsersHandler _sut;
    private IUserRepository _userRepository;

    [SetUp]
    public void Setup()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _sut = new GetUsersHandler(_userRepository);
    }

    [Test]
    public async Task Handle_WhenUsersExist_DictionaryOfUsers()
    {
        // Arrange
        var expected = new List<User>
        {
            new(Guid.NewGuid(), "John", "Wolf", "jw@test.com", "111111111", UserType.Doctor),
            new(Guid.NewGuid(), "Jane", "Doe", "jd@test.com", "222222222", UserType.Patient)
        };
        var userIds = expected
            .Select(u => u.Id)
            .ToList();

        _userRepository.GetByIds(userIds).Returns(expected);

        // Act
        var result = await _sut.Handle(new GetUsersHandlerQuery(userIds));

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected.ToDictionary(u => u.Id, u => u));
    }

    [Test]
    public async Task Handle_WhenUsersExist_ReturnsEmptyDictionary()
    {
        // Arrange
        var expected = new List<User>();
        var userIds = new List<Guid>();

        _userRepository.GetByIds(userIds).Returns(expected);

        // Act
        var result = await _sut.Handle(new GetUsersHandlerQuery(userIds));

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}