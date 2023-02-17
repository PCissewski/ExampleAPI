using ExampleAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Context;

public class PlanetarySystemDbContext : DbContext, IPlanetarySystemDbContext
{
    public PlanetarySystemDbContext(DbContextOptions<PlanetarySystemDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<PlanetarySystem> PlanetarySystems { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanetarySystem>().ToTable("PlanetarySystems");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}