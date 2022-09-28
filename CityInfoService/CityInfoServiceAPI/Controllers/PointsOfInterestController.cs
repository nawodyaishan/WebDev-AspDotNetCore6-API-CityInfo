using AutoMapper;
using CityInfoServiceAPI.Entities;
using CityInfoServiceAPI.Models;
using CityInfoServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{
    // Dependency Injection
    private readonly ILogger<PointsOfInterestController> _logger;
    private readonly IMailService _localMailService;
    private readonly IMapper _mapper;
    private readonly ICityInfoRepository _cityInfoRepository;

    // Constructor
    public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService,
        ICityInfoRepository cityInfoRepository, IMapper mapper)
    {
        _localMailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
    {
        var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

        if (cityExists)
        {
            _logger.LogInformation($"City with {cityId} not found !!");
        }

        var pointsOfInterestForCity = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);

        return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
    }

    [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
    public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
        int cityId, int pointOfInterestId)
    {
        var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

        // Checking for exist cities
        if (!cityExists)
        {
            _logger.LogInformation($"City with {cityId} not found !!");
            return NotFound();
        }

        var pointOfInterestForCity =
            await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

        if (pointOfInterestForCity == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterestForCity));
    }

    [HttpPost]
    public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int cityId,
        PointOfInterestForCreationDto pointOfInterest)
    {
        var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

        // Checking for exist cities
        if (!cityExists)
        {
            _logger.LogInformation($"City with {cityId} not found !!");
            return NotFound();
        }

        var finalPointOfInterest = _mapper.Map<PointOfInterest>(pointOfInterest);

        await _cityInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPointOfInterest);

        await _cityInfoRepository.SaveChangesAsync();

        var createdPointOfInterest = _mapper.Map<PointOfInterestDto>(finalPointOfInterest);

        return CreatedAtRoute("GetPointOfInterest",
            new
            {
                cityId = cityId,
                pointOfInterestId = createdPointOfInterest.id
            },
            createdPointOfInterest);
    }

    [HttpPut("{pointofinterestid}")]
    public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId,
        PointOfInterestForUpdateDto pointOfInterestForUpdateDto)
    {
        var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

        // Checking for exist cities
        if (!cityExists)
        {
            _logger.LogInformation($"City with {cityId} not found !!");
            return NotFound();
        }

        // Find point of interest
        var pointOfInterestEntity =
            await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

        if (pointOfInterestEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(pointOfInterestForUpdateDto, pointOfInterestEntity);

        await _cityInfoRepository.SaveChangesAsync();

        return NoContent();
    }

    //
    // [HttpPatch("{pointofinterestid}")]
    // public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
    //     JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
    // {
    //     // Find City
    //     var city = _citiesDataStore.cities.FirstOrDefault(c => c.id == cityId);
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     // Find point of interest
    //     var pointOfInterestFromStore = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);
    //
    //     if (pointOfInterestFromStore == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
    //     {
    //         name = pointOfInterestFromStore.name,
    //         description = pointOfInterestFromStore.description
    //     };
    //
    //     patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
    //
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //
    //     if (!TryValidateModel(pointOfInterestToPatch))
    //     {
    //         return BadRequest();
    //     }
    //
    //     pointOfInterestFromStore.name = pointOfInterestToPatch.name;
    //     pointOfInterestFromStore.description = pointOfInterestToPatch.description;
    //
    //     return NoContent();
    // }
    //
    // [HttpDelete("{pointofinterestid}")]
    // public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
    // {
    //     var city = _citiesDataStore.cities.FirstOrDefault(c => c.id == cityId);
    //
    //     if (city == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var pointOfInterestFromStore = city.pointsOfInterest.FirstOrDefault(c => c.id == pointOfInterestId);
    //
    //     if (pointOfInterestFromStore == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     city.pointsOfInterest.Remove(pointOfInterestFromStore);
    //
    //     _localMailService.Send("Point of interest deleted",
    //         $"point of interest {pointOfInterestFromStore.name} with id {pointOfInterestFromStore.id}");
    //
    //     return NoContent();
    // }
}