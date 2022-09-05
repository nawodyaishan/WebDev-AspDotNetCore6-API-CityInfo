using CityInfoServiceAPI.Models;

namespace CityInfoServiceAPI;

public class CitiesDataStore
{
    public List<CityDto> cities { get; set; }

    public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        // Init Dummy Data
        cities = new List<CityDto>()
        {
            new CityDto()
            {
                id = 1,
                name = "Colombo",
                description = "First Big City",
                numberOfPointsOfInterest = 5
            },
            new CityDto()
            {
                id = 2,
                name = "Kandy",
                description = "Second Big City",
                numberOfPointsOfInterest = 5
            },
            new CityDto()
            {
                id = 3,
                name = "Galle",
                description = "Third Big City",
                numberOfPointsOfInterest = 5
            }
        };
    }
}