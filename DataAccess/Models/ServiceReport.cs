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
    [MaxLength(300)]
    public string Description { get; set; }

    public DateTime? SubmittedAt { get; set; }
    
    [Required]
    public int ServiceReportCategoryId { get; set; }
    [ForeignKey(nameof(ServiceReportCategoryId))]
    public ServiceReportCategory? ServiceReportCategory { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    [ForeignKey(nameof(FacilityId))]
    public Facility? Facility { get; set; }
    
    [Required]
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}