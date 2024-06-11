using MedicalClinic.SharedKernel;

namespace MedicalClinic.Infrastructure.Core;

internal class GuidProvider : IGuidProvider
{
    public Guid NewGuid() => Guid.NewGuid();
}
