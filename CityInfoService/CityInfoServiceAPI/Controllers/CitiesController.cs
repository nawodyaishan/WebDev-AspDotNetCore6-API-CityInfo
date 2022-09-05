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
        return new JsonResult(new List<object>
        {
            new {id = 1, Name = "New York"},
            new {id = 2, Name = "Boston"},
        });
    }
}