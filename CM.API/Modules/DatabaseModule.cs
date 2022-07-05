using CM.Infrastructure.Context;
using CM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CM.API.Modules;

public static class DatabaseModule
{
    public static IServiceCollection AddDatabaseModule(this IServiceCollection services, ConfigurationManager configuration)
    {
        var dbString = configuration.GetConnectionString("SqlServerConnection");
        services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(
                    dbString,
                    o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.ToString())
                );
            });

        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IContractRepository, ContractRepository>();
            
        return services;
    }
}