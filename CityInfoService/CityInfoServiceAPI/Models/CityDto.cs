using CityInfoServiceAPI.Entities;

namespace CityInfoServiceAPI.Models;

public class CityDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string? description { get; set; }

    public int NumberOfPointsOfInterest
    {
        get { return pointsOfInterest.Count; }
    }

    public ICollection<PointOfInterestDto> pointsOfInterest { get; set; }
        = new List<PointOfInterestDto>();
}