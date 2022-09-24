using CityInfoServiceAPI.Models;
using CityInfoServiceAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    private readonly ILogger<PointsOfInterestController> _logger;
    private readonly LocalMailService _localMailService;

    public PointsOfInterestController(ILogger<PointsOfInterestController> logger, LocalMailService localMailService)
    {
        _localMailService = localMailService ?? throw new ArgumentNullException(nameof(localMailService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
    {
        var city = CitiesDataStore.Current.cities.FirstOrDefault(x => x.id == cityId);

        // Return with 404 Not Found Status Code
        if (city == null)
        {
            _logger.LogInformation("City with the id of {cityId} was not found", cityId);
            return NotFound();
        }

        // Return with 200 Ok Status Code
        return Ok(city.pointsOfInterest);
    }

    [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
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

    [HttpPost]
    public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId,
        PointOfInterestForCreationDto pointOfInterest)
    {
        // if (!ModelState.IsValid)
        // {
        //     BadRequest();
        // }

        var city = CitiesDataStore.Current.cities.FirstOrDefault(c => c.id == cityId);
        if (city == null)
        {
            return NotFound();
        }

        // Temp ID calculation
        var maxPointOfInterestId = CitiesDataStore.Current.cities.SelectMany(c => c.pointsOfInterest).Max(p => p.id);

        var finalPointOfInterest = new PointOfInterestDto()
        {
            id = ++maxPointOfInterestId,
            name = pointOfInterest.name,
            description = pointOfInterest.description
        };

        city.pointsOfInterest.Add(finalPointOfInterest);

        return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId,
                pointOfInterest = finalPointOfInterest.id,
            },
            finalPointOfInterest);
    }

    [HttpPut("{pointofinterestid}")]
    public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
        PointOfInterestForUpdateDto pointOfInterestForUpdateDto)
    {
        // Find City
        var city = CitiesDataStore.Current.cities.FirstOrDefault(c => c.id == cityId);
        if (city == null)
        {
            return NotFound();
        }

        // Find point of interest
        var pointOfInterestStore = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);

        if (pointOfInterestStore == null)
        {
            return NotFound();
        }

        pointOfInterestStore.name = pointOfInterestForUpdateDto.name;
        pointOfInterestStore.description = pointOfInterestForUpdateDto.description;

        return NoContent();
    }


    [HttpPatch("{pointofinterestid}")]
    public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
        JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
    {
        // Find City
        var city = CitiesDataStore.Current.cities.FirstOrDefault(c => c.id == cityId);
        if (city == null)
        {
            return NotFound();
        }

        // Find point of interest
        var pointOfInterestFromStore = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);

        if (pointOfInterestFromStore == null)
        {
            return NotFound();
        }

        var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
        {
            name = pointOfInterestFromStore.name,
            description = pointOfInterestFromStore.description
        };

        patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(pointOfInterestToPatch))
        {
            return BadRequest();
        }

        pointOfInterestFromStore.name = pointOfInterestToPatch.name;
        pointOfInterestFromStore.description = pointOfInterestToPatch.description;

        return NoContent();
    }

    [HttpDelete("{pointofinterestid}")]
    public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
    {
        var city = CitiesDataStore.Current.cities.FirstOrDefault(c => c.id == cityId);

        if (city == null)
        {
            return NotFound();
        }

        var pointOfInterestFromStore = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);

        if (pointOfInterestFromStore == null)
        {
            return NotFound();
        }

        city.pointsOfInterest.Remove(pointOfInterestFromStore);

        _localMailService.Send("Point of interest deleted",
            $"point of interest {pointOfInterestFromStore.name} with id {pointOfInterestFromStore.id}");

        return NoContent();
    }
}