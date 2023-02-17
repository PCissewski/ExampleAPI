using ExampleAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace ExampleAPI.Context;

public static class DbInit
{
    public static void InitializeDb(PlanetarySystemDbContext context)
    {
        context.Database.EnsureCreated();
        
        if (context.PlanetarySystems.Any()) return;

        var users = new[]
        {
            new User(
                "pawel", 
                new PasswordHasher<User>().HashPassword(null, "password")),
            new User(
                "tomasz",
                new PasswordHasher<User>().HashPassword(null, "admin"))
        };
        foreach (var user in users)
        {
            context.Users.Add(user);
        }
        context.SaveChanges();
        
        var planetarySystems = new[]
        {
            new PlanetarySystem("PC-1234", 2, 7),
            new PlanetarySystem("AS-1736", 1, 13),
            new PlanetarySystem("TD-4301", 2, 4),

        };
        foreach (var system in planetarySystems)
        {
            context.PlanetarySystems.Add(system);
        }
        context.SaveChanges();
    }
}