using MedicalClinic.Appointments.Features.Shared;
using MedicalClinic.Infrastructure.Core;
using MedicalClinic.Infrastructure.Db;
using MedicalClinic.Infrastructure.Db.Appointments;
using MedicalClinic.Infrastructure.Db.Users;
using MedicalClinic.Infrastructure.HttpContext;
using MedicalClinic.SharedKernel;
using MedicalClinic.Users.Features.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalClinic.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services, string sqlConnectionString)
    {
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IGuidProvider, GuidProvider>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(sqlConnectionString);
        });

        services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddScoped<IUserAccessor, HttpContextUserAccessor>();
    }
}
