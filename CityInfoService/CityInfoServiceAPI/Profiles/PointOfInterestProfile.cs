using AutoMapper;

namespace CityInfoServiceAPI.Profiles;

public class PointOfInterestProfile : Profile
{
    public PointOfInterestProfile()
    {
        CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
        CreateMap<Entities.PointOfInterest, Models.PointOfInterestForCreationDto>();
        CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
    }
}