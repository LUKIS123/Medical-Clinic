using MedicalClinic.Appointments.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Infrastructure.Db.Appointments;

internal class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Appointment appointment)
    {
        await _context.Appointments.AddAsync(new(
            appointment.Id,
            appointment.Date,
            appointment.Reason,
            appointment.DoctorId,
            appointment.PatientId));
        await _context.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetByDoctorId(Guid doctorId) =>
        await _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .Select(a => new Appointment(
                a.Id,
                a.Date,
                a.Reason,
                a.DoctorId,
                a.PatientId))
            .ToListAsync();

    public async Task<List<Appointment>> GetByPatientId(Guid patientId) =>
        await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .Select(a => new Appointment(
                a.Id,
                a.Date,
                a.Reason,
                a.DoctorId,
                a.PatientId))
            .ToListAsync();
}
