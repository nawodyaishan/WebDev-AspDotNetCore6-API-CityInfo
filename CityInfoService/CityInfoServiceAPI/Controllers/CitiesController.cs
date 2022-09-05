using CityInfoServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[ApiController]
// [Route("api/[Controller]")]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public JsonResult GetCities()
    {
        var response = new JsonResult(CitiesDataStore.Current.cities);
        return response;
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCityDto(int id)
    {
        // Find City
        var cityToReturn = CitiesDataStore.Current.cities.FirstOrDefault(x => x.id == id);

        // Return with 2000 Ok Status Code
        return Ok(cityToReturn);
    }
}