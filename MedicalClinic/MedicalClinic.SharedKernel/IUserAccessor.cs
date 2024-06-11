namespace MedicalClinic.SharedKernel;

public interface IUserAccessor
{
    Guid UserId { get; }
    UserType UserType { get; }
}
