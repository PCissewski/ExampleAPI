using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Model;

internal interface IPlanetarySystemDbContext
{
    DbSet<PlanetarySystem> PlanetarySystems { get; }
    DbSet<User> Users { get; }
}