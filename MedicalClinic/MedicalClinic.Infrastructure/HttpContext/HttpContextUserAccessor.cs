using MedicalClinic.SharedKernel;

namespace MedicalClinic.Infrastructure.HttpContext;

internal class HttpContextUserAccessor : IUserAccessor
{
    public Guid UserId => Guid.Parse("fc7b6dcb-f7e1-4a2f-8339-137b9ecd2ce9");

    public UserType UserType => UserType.Patient;
}
