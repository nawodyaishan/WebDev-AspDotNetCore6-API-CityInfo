using AutoMapper;
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
    private readonly IMapper _mapper;

    public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
    {
        var cityEntities = await _cityInfoRepository.GetCitiesAsync();
        return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCityDto(int id, bool includePointsOfInterest = false)
    {
        var cityToReturn = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);

        if (cityToReturn == null)
        {
            return NotFound();
        }

        if (includePointsOfInterest)
        {
            return Ok(_mapper.Map<CityDto>(cityToReturn));
        }

        return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(cityToReturn));
    }
}