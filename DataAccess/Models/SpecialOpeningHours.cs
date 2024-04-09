using DataAccess.Models.Base;

namespace DataAccess.Models;

public class SpecialOpeningHours : OpeningHoursBase
{
    public DateOnly Date { get; set; }
}