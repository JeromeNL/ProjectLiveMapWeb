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
            new DefaultOpeningHours(DayOfWeek.Monday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("14:00"),
                CloseTime = TimeOnly.Parse("20:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Tuesday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("20:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Wednesday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("11:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Thursday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Friday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("12:00"),
                CloseTime = TimeOnly.Parse("21:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Saturday)
            {
                FacilityId = 1,
                OpenTime = TimeOnly.Parse("09:00"),
                CloseTime = TimeOnly.Parse("23:00")
            },
            
            new DefaultOpeningHours(DayOfWeek.Sunday)
            {
                FacilityId = 1
            }
        };

        return defaultOpeningHours;
    }
}