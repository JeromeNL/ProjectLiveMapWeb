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
    
    // If empty then it is a new facility
    public int? FacilityId { get; set; }
    
    [ForeignKey(nameof(FacilityId))]
    [JsonIgnore]
    public Facility Facility { get; set; }
}