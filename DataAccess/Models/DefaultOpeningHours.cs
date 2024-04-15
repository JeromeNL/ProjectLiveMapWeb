using DataAccess.Models.Base;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class DefaultOpeningHours : OpeningHoursBase
{
    public DefaultOpeningHours(DayOfWeek weekDay)
    {
        WeekDay = weekDay;
    }

    public override DayOfWeek WeekDay { get; }
}