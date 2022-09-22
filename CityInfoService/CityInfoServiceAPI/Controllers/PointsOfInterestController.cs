using System.Drawing;
using CityInfoServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
                cityId = cityId,
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
}