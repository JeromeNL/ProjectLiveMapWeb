using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models;

public class FacilityCategory : ISoftDelete
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string IconName { get; set; }
    
    public int HolidayResortId { get; set; }
    
    [ForeignKey(nameof(HolidayResortId))]
    [JsonIgnore]
    public HolidayResort HolidayResort { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
}