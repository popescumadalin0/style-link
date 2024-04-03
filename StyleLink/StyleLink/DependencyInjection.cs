using DatabaseLayout;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StyleLink.Repositories;

namespace StyleLink;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDatabaseLayout(config);

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ISalonRepository, SalonRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISalonImageRepository, SalonImageRepository>();
        services.AddScoped<IHairStylistRepository, HairStylistRepository>();
        services.AddScoped<IHairStylistSalonRepository, HairStylistSalonRepository>();
        services.AddScoped<IHairStylistSalonServiceRepository, HairStylistSalonServiceRepository>();
        services.AddScoped<IWorkProgramRepository, WorkProgramRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

        return services;
    }
}