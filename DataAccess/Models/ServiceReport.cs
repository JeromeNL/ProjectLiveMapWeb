using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public class ServiceReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string title { get; set; }
    
    [Required]
    public string description { get; set; }
    
    [Required]
    public string category { get; set; }
    
    [Required]
    public int facilityId { get; set; }
    
    [ForeignKey(nameof(facilityId))]
    [JsonIgnore]
    public Facility? Facility { get; set; }
}