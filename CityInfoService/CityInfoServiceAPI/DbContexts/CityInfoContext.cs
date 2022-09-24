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

    // Providing Data to Start With
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City("Colombo")
            {
                id = 1,
                description = "h9ew ud uewq dui phudwu9e dhu9wpe p"
            },
            new City("Badulla")
            {
                id = 2,
                description = "h9ew ud uewq dui phudwu9e dhu9wpe p"
            },
            new City("Matara")
            {
                id = 3,
                description = "h9ew ud uewq dui phudwu9e dhu9wpe p"
            }
        );

        modelBuilder.Entity<PointOfInterest>().HasData(
            new PointOfInterest("Lotus Tower")
            {
                id = 1,
                CityId = 1,
                description = "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh"
            },
            new PointOfInterest("Lotus Tower")
            {
                id = 2,
                CityId = 2,
                description = "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh"
            },
            new PointOfInterest("Lotus Tower")
            {
                id = 3,
                CityId = 3,
                description = "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh"
            },
            new PointOfInterest("Lotus Tower")
            {
                id = 4,
                CityId = 2,
                description = "jdhfi wejhiuwe hweu weh piuewh  h uwh hewu hue ph phuewh"
            }
        );
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    // {
    //     dbContextOptionsBuilder.UseSqlite("connectionString");
    //     base.OnConfiguring(dbContextOptionsBuilder);
    // }
}