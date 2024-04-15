using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataAccess.Converters;
using DataAccess.Models.Enums;

namespace DataAccess.Models.Base;

public abstract class OpeningHoursBase
{
    [JsonConverter(typeof(HourMinuteConverter))]
    public TimeOnly OpenTime { get; set; } = new TimeOnly(0, 0);  
    
    [JsonConverter(typeof(HourMinuteConverter))]
    public TimeOnly CloseTime { get; set; } = new TimeOnly(23, 59);

    [Required]
    [ForeignKey(nameof(Facility))]
    public int FacilityId { get; set; }
    
    [JsonIgnore]
    public Facility Facility { get; set; }

    public abstract DayOfWeek WeekDay { get; }
}