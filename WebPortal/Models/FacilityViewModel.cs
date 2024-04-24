using DataAccess.Models;

namespace WebPortal.Models;

public class FacilityViewModel
{
    public Facility Facility { get; set; } 
    public List<DefaultOpeningHours> OpeningHours { get; set; } 
    
    public Boolean IsAlwaysOpen { get; set; }
    
}