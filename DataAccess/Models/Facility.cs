using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;
using DataAccess.Models.Base;

namespace DataAccess.Models;

public class Facility : FacilityBase, ISoftDelete

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
    public ICollection<ServiceReport>? ServiceReports { get; }

    public bool IsAlwaysOpen()
    {
        return DefaultOpeningHours.TrueForAll(hour =>
            hour.OpenTime == TimeOnly.Parse("00:00:00.0000000") &&
            hour.CloseTime == TimeOnly.Parse("23:59:00.0000000"));
    }
    
    public void SetAlwaysOpen()
    {
        foreach (var hour in DefaultOpeningHours)
        {
            hour.OpenTime = TimeOnly.Parse("00:00:00.0000000");
            hour.CloseTime = TimeOnly.Parse("23:59:00.0000000");
        }
    }
    
    public void SetToRegularOpeningHours()
    {
        foreach (var hour in DefaultOpeningHours)
        {
            hour.OpenTime = TimeOnly.Parse("09:00:00.0000000");
            hour.CloseTime = TimeOnly.Parse("18:00:00.0000000");
        }
    }
}