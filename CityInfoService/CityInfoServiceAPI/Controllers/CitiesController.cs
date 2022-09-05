using CityInfoServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[ApiController]
// [Route("api/[Controller]")]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetCities()
    {
        return Ok((CitiesDataStore.Current.cities));
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCityDto(int id)
    {
        // Find City
        var cityToReturn = CitiesDataStore.Current.cities.FirstOrDefault(x => x.id == id);

        // Return with 404 Not Found Status Code
        if (cityToReturn == null)
        {
            return NotFound();
        }

        // Return with 200 Ok Status Code
        return Ok(cityToReturn);
    }
}