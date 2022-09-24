using CityInfoServiceAPI.Models;
using CityInfoServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[ApiController]
// [Route("api/[Controller]")]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;

    public CitiesController(ICityInfoRepository cityInfoRepository)
    {
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
    {
        var cityEntities = await _cityInfoRepository.GetCitiesAsync();

        var resultsDtos = new List<CityWithoutPointOfInterestDto>();

        foreach (var cityEntity in cityEntities)
        {
            resultsDtos.Add(new CityWithoutPointOfInterestDto()
            {
                id = cityEntity.id,
                description = cityEntity.description,
                name = cityEntity.name
            });
        }

        return Ok(resultsDtos);

        // return Ok((_cityInfoRepository.cities));
    }

    // [HttpGet("{id}")]
    // public ActionResult<CityDto> GetCityDto(int id)
    // {
    //     // Find City
    //     var cityToReturn = _cityInfoRepository.cities.FirstOrDefault(x => x.id == id);
    //
    //     // Return with 404 Not Found Status Code
    //     if (cityToReturn == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     // Return with 200 Ok Status Code
    //     return Ok(cityToReturn);
    // }
}