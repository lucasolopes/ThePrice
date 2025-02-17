using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ThePriceDbContext(DbContextOptions<ThePriceDbContext> options) : DbContext(options)
{
    public DbSet<Challenge> Challenges { get; set; }
}

