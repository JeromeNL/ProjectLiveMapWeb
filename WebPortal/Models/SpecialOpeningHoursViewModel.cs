using DataAccess.Models;

namespace WebPortal.Models;

public class SpecialOpeningHoursViewModel
{
    public Facility Facility { get; set; }
    public List<SpecialOpeningHours> SpecialOpeningHoursList { get; set; } = new List<SpecialOpeningHours>();
}