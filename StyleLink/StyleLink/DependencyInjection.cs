using DatabaseLayout;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StyleLink.Repositories;
using StyleLink.Repositories.Interfaces;
using StyleLink.Services;
using StyleLink.Services.Interfaces;
using HairStylistService = StyleLink.Services.HairStylistService;

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
        services.AddScoped<IHairStylistServiceRepository, HairStylistServiceRepository>();
        services.AddScoped<IWorkProgramRepository, WorkProgramRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<ISalonService, SalonService>();
        services.AddScoped<IHairStylistService, HairStylistService>();
        services.AddScoped<IServiceSalonService, ServiceSalonService>();

        services.AddScoped<IImageConvertorService, ImageConvertorService>();

        return services;
    }
}