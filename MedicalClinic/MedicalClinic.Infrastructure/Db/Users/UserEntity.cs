using MedicalClinic.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinic.Infrastructure.Db.Users;

[Table("Users", Schema = "users")]
internal record UserEntity(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    UserType UserTypeId);
