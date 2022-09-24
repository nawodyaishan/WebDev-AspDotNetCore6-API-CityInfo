using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoServiceAPI.Entities;

public class PointOfInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int pointOfInterestId { get; set; }

    [Required]
    [MaxLength(50)]
    public string name { get; set; }
    
    [ForeignKey("CityId")]
    public City? city { get; set; }

    public int cityId { get; set; }

    public PointOfInterest(string name)
    {
        this.name = name;
    }
}