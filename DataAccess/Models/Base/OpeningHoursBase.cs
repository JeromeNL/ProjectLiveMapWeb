using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Models.Enums;

namespace DataAccess.Models.Base;

public abstract class OpeningHoursBase
{
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }

    [Required]
    [ForeignKey(nameof(Facility))]
    public int FacilityId { get; set; }
    
    [JsonIgnore]
    public Facility Facility { get; set; }

    public abstract DayOfWeek WeekDay { get; }
}