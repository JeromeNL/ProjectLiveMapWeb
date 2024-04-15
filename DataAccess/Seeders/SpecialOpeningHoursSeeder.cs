using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class SpecialOpeningHoursSeeder : ISeeder<SpecialOpeningHours>
{
    public List<SpecialOpeningHours> Seed()
    {
        var specialOpeningHours = new List<SpecialOpeningHours>
        {
            new SpecialOpeningHours
            {
                FacilityId = 1,
                Date = DateOnly.FromDateTime(DateTime.Today).AddDays(2),
                OpenTime = TimeOnly.Parse("06:00"),
                CloseTime = TimeOnly.Parse("23:30")
            },
            
            new SpecialOpeningHours
            {
                FacilityId = 1,
                Date = DateOnly.FromDateTime(DateTime.Today).AddDays(5),
                OpenTime = TimeOnly.Parse("09:00"),
                CloseTime = TimeOnly.Parse("14:00")
            },
            
            new SpecialOpeningHours
            {
                FacilityId = 1,
                Date = DateOnly.FromDateTime(DateTime.Today).AddDays(15),
                OpenTime = TimeOnly.Parse("15:00"),
                CloseTime = TimeOnly.Parse("22:00")
            },
            
            new SpecialOpeningHours
            {
                FacilityId = 2,
                Date = DateOnly.FromDateTime(DateTime.Today).AddDays(15),
                OpenTime = TimeOnly.Parse("15:00"),
                CloseTime = TimeOnly.Parse("22:00")
            },
            
            new SpecialOpeningHours
            {
                FacilityId = 2,
                Date = DateOnly.FromDateTime(DateTime.Today).AddDays(20),
                OpenTime = TimeOnly.Parse("15:00"),
                CloseTime = TimeOnly.Parse("22:00")
            },
        };

        return specialOpeningHours;
    }
}