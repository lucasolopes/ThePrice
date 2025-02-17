using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Services.Abstractions;
using Services.Implementations;
using ThePrice.Configurations;
using ThePrice.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureDbContext();

builder.Services.AddScoped<IChallengesService, ChallengesService>();
builder.Services.AddScoped<IChallengesRepository, ChallengesRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    IServiceProvider services = serviceScope.ServiceProvider;
    try
    {
        ThePriceDbContext context = services.GetRequiredService<ThePriceDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
    }
}

app.Run();
