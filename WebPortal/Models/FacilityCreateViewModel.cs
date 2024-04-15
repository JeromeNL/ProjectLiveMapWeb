using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebPortal.Models;

public class FacilityCreateViewModel
{
    public Facility Facility { get; set; }
    
    [ValidateNever]
    public List<FacilityCategory> FacilityCategories { get; set; }
    
    [ValidateNever]
    public double Latitude { get; set; }
    
    [ValidateNever]
    public double Longitude { get; set; }
}