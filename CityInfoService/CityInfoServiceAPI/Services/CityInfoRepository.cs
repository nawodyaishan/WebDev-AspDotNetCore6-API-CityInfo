using CityInfoServiceAPI.DbContexts;
using CityInfoServiceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoServiceAPI.Services;

public class CityInfoRepository : ICityInfoRepository
{
    private readonly CityInfoContext _context;

    public CityInfoRepository(CityInfoContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await _context.Cities.OrderBy(c => c.name).ToListAsync();
    }

    public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
    {
        if (includePointsOfInterest)
        {
            return await _context.Cities.Include(c => c.pointsOfInterest).Where(c => c.id == cityId)
                .FirstOrDefaultAsync();
        }

        return await _context.Cities.Where(c => c.id == cityId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
    {
        return await _context.PointsOfInterests.OrderBy(c => c.name).ToListAsync();
    }

    public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
    {
        return await _context.PointsOfInterests.Where(p => p.CityId == cityId && p.id == pointOfInterestId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CityExistsAsync(int cityId)
    {
        return await _context.Cities.AnyAsync(c => c.id == cityId);
    }

    public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
    {
        var city = await GetCityAsync(cityId, false);

        if (city != null)
        {
            city.pointsOfInterest.Add(pointOfInterest);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public void DeletePointOfInterest(PointOfInterest pointOfInterest)
    {
        _context.PointsOfInterests.Remove(pointOfInterest);
    }
}