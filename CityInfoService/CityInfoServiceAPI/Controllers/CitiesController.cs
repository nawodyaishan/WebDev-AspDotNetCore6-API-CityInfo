using CityInfoServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[ApiController]
// [Route("api/[Controller]")]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly CitiesDataStore _citiesDataStore;

    public CitiesController(CitiesDataStore citiesDataStore)
    {
        _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
    }

    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetCities()
    {
        return Ok((_citiesDataStore.cities));
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCityDto(int id)
    {
        // Find City
        var cityToReturn = _citiesDataStore.cities.FirstOrDefault(x => x.id == id);

        // Return with 404 Not Found Status Code
        if (cityToReturn == null)
        {
            return NotFound();
        }

        // Return with 200 Ok Status Code
        return Ok(cityToReturn);
    }
}