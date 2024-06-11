namespace MedicalClinic.Users.Features.GetUsers.Contract;

public record GetUsersHandlerQuery(
    IEnumerable<Guid> UserIds);
