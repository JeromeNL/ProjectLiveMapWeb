using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class FacilityReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int ProposedFacilityId { get; set; }
    
    [ForeignKey(nameof(ProposedFacilityId))]
    public ProposedFacility ProposedFacility { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public ReportStatus Status { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; }
    
    [Required]
    public int HolidayResortId { get; set; }
    
    [ForeignKey(nameof(HolidayResortId))]
    [JsonIgnore]
    public HolidayResort? HolidayResort { get; set; }
}