using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class HolidayResortCoordinate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int HolidayResortId { get; set; }

    [Required] public int Order { get; set; }

    [ForeignKey(nameof(HolidayResortId))] public HolidayResort? HolidayResort { get; set; }

    [Required]
    [Range(-90.0, 90.0, ErrorMessage = "Voer een geldige latitude in.")]
    public double Latitude { get; set; }

    [Required]
    [Range(-180.0, 180.0, ErrorMessage = "Voer een geldige longitude in.")]
    public double Longitude { get; set; }
}