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

        return services;
    }
}