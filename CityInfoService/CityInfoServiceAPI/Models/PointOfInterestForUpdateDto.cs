using System.ComponentModel.DataAnnotations;

namespace CityInfoServiceAPI.Models;

public class PointOfInterestForUpdateDto
{
    [Required(ErrorMessage = "You should provide a valid name")]
    [MaxLength(50)]
    public string name { get; set; } = string.Empty;

    [MaxLength(200)] public string? description { get; set; }
}