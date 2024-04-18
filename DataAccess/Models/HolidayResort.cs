using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;

namespace DataAccess.Models;

public class HolidayResort : ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    [Required(ErrorMessage = "Het naam veld is verplicht")]
    public string Name { get; set; }
    
    [Required]
    [Range(-90.0, 90.0, ErrorMessage = "Voer een geldige latitude in.")]
    public double NorthEastLatitude { get; set; }
    
    [Required]
    [Range(-180.0, 180.0, ErrorMessage = "Voer een geldige longitude in.")]
    public double NorthEastLongitude { get; set; }
    
    [Required]
    [Range(-90.0, 90.0, ErrorMessage = "Voer een geldige latitude in.")]
    public double SouthWestLatitude { get; set; }

    [Required]
    [Range(-180.0, 180.0, ErrorMessage = "Voer een geldige longitude in.")]
    public double SouthWestLongitude { get; set; }
} 