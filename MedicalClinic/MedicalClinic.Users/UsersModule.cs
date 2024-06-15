using MedicalClinic.Users.Features.GetAllDoctors;
using MedicalClinic.Users.Features.GetAllDoctors.Contract;
using MedicalClinic.Users.Features.GetUsers;
using MedicalClinic.Users.Features.GetUsers.Contract;
using MedicalClinic.Users.Features.IsUserADoctor;
using MedicalClinic.Users.Features.IsUserADoctor.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalClinic.Users;

public static class UsersModule
{
    public static void AddUsersModule(this IServiceCollection services)
    {
        services.AddTransient<IGetUsersHandler, GetUsersHandler>();
        services.AddTransient<IIsUserADoctorHandler, IsUserADoctorHandler>();
        services.AddTransient<IGetAllDoctorsHandler, GetAllDoctorsHandler>();
    }
}