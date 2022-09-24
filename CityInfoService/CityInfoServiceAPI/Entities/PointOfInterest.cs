using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoServiceAPI.Entities;

public class PointOfInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required] [MaxLength(50)] public string name { get; set; }

    [MaxLength(200)] public string description { get; set; }

    [ForeignKey("CityId")] public City? city { get; set; }

    public int CityId { get; set; }

    public PointOfInterest(string name)
    {
        this.name = name;
    }
}