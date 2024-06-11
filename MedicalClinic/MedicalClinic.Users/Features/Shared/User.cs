using MedicalClinic.SharedKernel;

namespace MedicalClinic.Users.Features.Shared;

public readonly record struct User(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    UserType UserType);
