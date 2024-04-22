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

    [Required(ErrorMessage = "Een selectie op de map is verplicht")]
    public string Coordinates { get; set; }
}