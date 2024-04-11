using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    public int ServiceReportCategoryId { get; set; }

    [ForeignKey(nameof(ServiceReportCategoryId))]
    [JsonIgnore]
    public ServiceReportCategory ServiceReportCategory { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [ForeignKey(nameof(FacilityId))]
    [JsonIgnore]
    public Facility? Facility { get; set; }
}