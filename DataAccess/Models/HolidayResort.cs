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

    [Required]
    public string Name { get; set; }
    
    
    public double NorthEastLatitude { get; set; }

    
    public double NorthEastLongitude { get; set; }
    
   
    public double SouthWestLatitude { get; set; }

   
    public double SouthWestLongitude { get; set; }
}