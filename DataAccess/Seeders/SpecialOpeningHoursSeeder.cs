using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class SpecialOpeningHoursSeeder : ISeeder<SpecialOpeningHours>
{
    public List<SpecialOpeningHours> Seed()
    {
        var defaultOpeningHours = new List<SpecialOpeningHours>
        {
            new SpecialOpeningHours
            {
                FacilityId = 1,
                Date = DateOnly.FromDateTime(DateTime.Today),
                OpenTime = TimeOnly.Parse("06:00"),
                CloseTime = TimeOnly.Parse("23:30")
            },
        };

        return defaultOpeningHours;
    }
}