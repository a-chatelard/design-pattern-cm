using CM.Infrastructure.Context;
using CM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CM.API.Modules;

public static class DatabaseModule
{
    public static IServiceCollection AddDatabaseModule(this IServiceCollection services, ConfigurationManager configuration)
    {
        const bool useInMemoryDatabase = true;

        var dbString = configuration.GetConnectionString("SqlServerConnection");
        services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase(databaseName: "cm_db");
                }
                else
                {
                    options.UseSqlServer(
                        dbString,
                        o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.ToString())
                    );
                }
            });

        services
            .AddScoped<IContractRepository, ContractRepository>();
            
        return services;
    }
}