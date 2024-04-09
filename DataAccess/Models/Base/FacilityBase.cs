using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;

namespace DataAccess.Models.Base;

public abstract class FacilityBase
{
    [Required(ErrorMessage = "Dit veld is verplicht.")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Dit veld is verplicht.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Dit veld is verplicht.")]
    public int CategoryId { get; set; }
    
    [ForeignKey(nameof(CategoryId))]
    public FacilityCategory Category { get; set; }

    [Required(ErrorMessage = "Dit veld is verplicht.")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Dit veld is verplicht.")]
    public double Longitude { get; set; }
}