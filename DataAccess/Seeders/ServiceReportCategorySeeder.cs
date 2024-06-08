using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class ServiceReportCategorySeeder: ISeeder<ServiceReportCategory>
{
    public List<ServiceReportCategory> Seed()
    {
        var list = new List<ServiceReportCategory>
        {
            new()
            {
                Id = 1,
                Name = "Onderhoud",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Beveiliging",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Schoonmaak",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Apparatuurstoring",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Inspectie",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Feedback",
                HolidayResortId = 1,
            }
        };
        return list;
    }
}