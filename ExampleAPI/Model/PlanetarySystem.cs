using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Model;
[PrimaryKey("SystemId")]
public class PlanetarySystem
{
    public PlanetarySystem
    (
        string systemName, 
        int numberOfStars, 
        int numberOfPlanets)
    {
        SystemName = systemName;
        NumberOfStars = numberOfStars;
        NumberOfPlanets = numberOfPlanets;
    }
    
    public string SystemName { get; private set; }
    public int NumberOfStars { get; private set; }
    public int NumberOfPlanets { get; private set; }
    
    public int SystemId { get; private set; }
}