using CityInfoServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
    {
        var city = CitiesDataStore.Current.cities.FirstOrDefault(x => x.id == cityId);

        // Return with 404 Not Found Status Code
        if (city == null)
        {
            return NotFound();
        }

        // Return with 200 Ok Status Code
        return Ok(city.pointsOfInterest);
    }

    [HttpGet("{pointofinterestid}")]
    public ActionResult<PointOfInterestDto> GetPointOfInterest(
        int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.cities.FirstOrDefault(x => x.id == cityId);

        // Return with 404 Not Found Status Code
        if (city == null)
        {
            return NotFound();
        }

        // Find point of interest
        var pointOfInterest = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);

        if (pointOfInterest == null)
        {
            return NotFound();
        }

        return Ok(pointOfInterest);
    }
}