using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Models.Enums;

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
    [MaxLength(300)]
    public string Description { get; set; }
    
    [Required]
    public ReportStatus Status { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [ForeignKey(nameof(FacilityId))]
    public Facility? Facility { get; set; }
    
    [Required]
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}