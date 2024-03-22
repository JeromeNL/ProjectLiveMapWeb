using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Models.Base;

namespace DataAccess.Models;

public class ProposedFacility : BaseFacility
{
    [Key]
    [JsonIgnore]
    public int Id { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [ForeignKey(nameof(FacilityId))]
    public Facility Facility { get; set; }
}