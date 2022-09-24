using CityInfoServiceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoServiceAPI.DbContexts;

public class CityInfoContext : DbContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<PointOfInterest> PointsOfInterests { get; set; } = null!;

    public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    // {
    //     dbContextOptionsBuilder.UseSqlite("connectionString");
    //     base.OnConfiguring(dbContextOptionsBuilder);
    // }
}