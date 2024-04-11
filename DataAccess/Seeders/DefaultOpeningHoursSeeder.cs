using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class DefaultOpeningHoursSeeder : ISeeder<DefaultOpeningHours>
{
    public List<DefaultOpeningHours> Seed()
    {
        var defaultOpeningHours = new List<DefaultOpeningHours>
        {
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Monday,
                OpenTime = TimeOnly.Parse("14:00"),
                CloseTime = TimeOnly.Parse("20:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Tuesday,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("20:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Wednesday,
                OpenTime = TimeOnly.Parse("11:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Thursday,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Friday,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Saturday,
                OpenTime = TimeOnly.Parse("09:00"),
                CloseTime = TimeOnly.Parse("23:00")
            },
            
            new DefaultOpeningHours
            {
                FacilityId = 1,
                WeekDay = WeekDay.Sunday
            },
        };

        return defaultOpeningHours;
    }
}