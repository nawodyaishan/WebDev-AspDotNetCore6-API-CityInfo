using CityInfoServiceAPI.Models;

namespace CityInfoServiceAPI;

public class CitiesDataStore
{
    public List<CityDto> cities { get; set; }

    // Removed Static Class After Dependency Injection
    // public static _CitiesDataStore Current { get; } = new _CitiesDataStore();

    public CitiesDataStore()
    {
        // Init Dummy Data
        cities = new List<CityDto>()
        {
            new()
            {
                id = 1,
                name = "Colombo",
                description = "First Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
                    {
                        id = 3,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                },
            },
            new()
            {
                id = 2,
                name = "Kandy",
                description = "Second Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
                    {
                        id = 3,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                },
            },
            new()
            {
                id = 3,
                name = "Galle",
                description = "Third Big City",
                pointsOfInterest = new List<PointOfInterestDto>()
                {
                    new()
                    {
                        id = 1,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
                    {
                        id = 2,
                        name = "Nelum Tower",
                        description = "Jh ahsda  uahd adabdjkha dajmhdad  dahda da,sndljknad jkhakd as,d ih"
                    },
                    new()
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