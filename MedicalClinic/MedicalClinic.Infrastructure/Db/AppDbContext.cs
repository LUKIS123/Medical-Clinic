using MedicalClinic.Infrastructure.Db.Appointments;
using MedicalClinic.Infrastructure.Db.Users;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Infrastructure.Db;

internal class AppDbContext : DbContext
{
    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
