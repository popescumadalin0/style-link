
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseLayout;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseLayout(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IContext, Context>();

        services.AddIdentityCore<User>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
            o.SignIn.RequireConfirmedAccount = true;
        });

        services.AddDbContext<Context>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        return services;
    }
}