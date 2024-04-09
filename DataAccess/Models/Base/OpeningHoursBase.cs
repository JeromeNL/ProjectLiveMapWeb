using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Enums;

namespace DataAccess.Models.Base;

public abstract class OpeningHoursBase
{
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    
    [ForeignKey("Facility")]
    public int FacilityId { get; set; }
    public Facility Facility { get; set; }
}