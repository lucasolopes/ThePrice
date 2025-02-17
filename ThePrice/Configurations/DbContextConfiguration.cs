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

            options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
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
