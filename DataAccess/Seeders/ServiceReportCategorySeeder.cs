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
                Name = "Onderhoud"
            },
            new()
            {
                Id = 2,
                Name = "Beveiliging"
            },
            new()
            {
                Id = 3,
                Name = "Schoonmaak"
            },
            new()
            {
                Id = 4,
                Name = "Apparatuurstoring"
            },
            new()
            {
                Id = 5,
                Name = "Inspectie"
            },
            new()
            {
                Id = 6,
                Name = "Feedback"
            }
        };
        return list;
    }
}