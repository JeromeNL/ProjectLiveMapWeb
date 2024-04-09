using DataAccess.Models.Base;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class DefaultOpeningHours : OpeningHoursBase
{
    public WeekDay WeekDay { get; set; }
    
}