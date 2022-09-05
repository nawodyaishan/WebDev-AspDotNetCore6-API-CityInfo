using CityInfoServiceAPI.Models;

namespace CityInfoServiceAPI;

public class CitiesDataStore
{
    public List<CityDto> cities { get; set; }

    public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        // Init Dummy Data
        cities = new List<CityDto>()
        {
            new CityDto()
            {
                id = 1,
                name = "Colombo",
                description = "First Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 3,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                },
            },
            new CityDto()
            {
                id = 2,
                name = "Kandy",
                description = "Second Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 3,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                },
            },
            new CityDto()
            {
                id = 3,
                name = "Galle",
                description = "Third Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new PointOfInterestDto()
                    {
                        id = 3,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                },
            }
        };
    }
}