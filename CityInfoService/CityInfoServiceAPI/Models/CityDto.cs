namespace CityInfoServiceAPI.Models;

public class CityDto
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string? description { get; set; }

    public ICollection<PointOfInterestDto> pointsOfInterest { get; set; }
        = new List<PointOfInterestDto>();
}