using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Base;

public abstract class FacilityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Type { get; set; }

    [Required]
    public double Latitude { get; set; }
    
    [Required]
    public double Longitude { get; set; }

    [Required]
    public string IconName { get; set; }
    
    public List<DefaultOpeningHours> DefaultOpeningHours { get; set; }
    
    public List<SpecialOpeningHours> SpecialOpeningHours { get; set; }
}