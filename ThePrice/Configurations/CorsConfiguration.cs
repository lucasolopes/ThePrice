namespace ThePrice.Configurations;

public static class CorsConfiguration
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhostAndZero", policy =>
            {
                policy.WithOrigins("http://localhost", "http://0.0.0.0", 
                        "http://localhost:8080", "http://0.0.0.0:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }
}
