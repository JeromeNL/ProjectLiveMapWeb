namespace WebPortal.Models;

public class OpeningHoursInputModel
{
    public int FacilityId { get; set; }
    public List<DayOpeningHours> DayHours { get; set; } = new List<DayOpeningHours>();
}

