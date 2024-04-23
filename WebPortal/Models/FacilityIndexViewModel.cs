using DataAccess.Models;

namespace WebPortal.Models;

public class FacilityIndexViewModel
{
    public List<Facility> Facilities { get; set; }
    
    public HolidayResort Resort { get; set; }
}