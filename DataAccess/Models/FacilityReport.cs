using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class FacilityReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [Required]
    public Facility Facility { get; set; }
    
    public ProposedFacilityChange? ProposedFacilityChange { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public FacilityReportStatus Status { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}