using Microsoft.EntityFrameworkCore;
using Persistence;

namespace ThePrice.Configurations;

public static class DbContextConfiguration
{
    public static void ConfigureDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ThePriceDbContext>(options =>
        {
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var serverVersion = new MariaDbServerVersion(new Version(11, 4, 2));

            options.UseMySql(connectionString, serverVersion, mysqlOptions =>
                {
                    mysqlOptions.EnableRetryOnFailure(
                        5,
                        TimeSpan.FromSeconds(10),
                        null
                    );
                })
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
    }
}
