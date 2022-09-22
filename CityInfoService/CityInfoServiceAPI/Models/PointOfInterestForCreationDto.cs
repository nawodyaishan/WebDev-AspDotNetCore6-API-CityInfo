using System.ComponentModel.DataAnnotations;

namespace CityInfoServiceAPI.Models;

public class PointOfInterestForCreationDto
{
    [Required] [MaxLength(50)] public string name { get; set; } = string.Empty;
    [MaxLength(200)] public string? description { get; set; }
}