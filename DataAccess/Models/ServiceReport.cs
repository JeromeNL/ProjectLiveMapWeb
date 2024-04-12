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
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [ForeignKey(nameof(FacilityId))]
    public Facility? Facility { get; set; }
}