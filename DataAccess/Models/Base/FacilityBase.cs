using System.ComponentModel.DataAnnotations;
using DataAccess.Interfaces;

namespace DataAccess.Models.Base;

public abstract class FacilityBase : ISoftDelete
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
    
    public DateTimeOffset? DeletedAt { get; set; }
}