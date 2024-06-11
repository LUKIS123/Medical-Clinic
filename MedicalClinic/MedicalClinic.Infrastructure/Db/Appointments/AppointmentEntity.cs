using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinic.Infrastructure.Db.Appointments;

[Table("Appointments", Schema = "visits")]
internal record AppointmentEntity(
    Guid Id,
    DateTime Date,
    string Reason,
    Guid DoctorId,
    Guid PatientId);
