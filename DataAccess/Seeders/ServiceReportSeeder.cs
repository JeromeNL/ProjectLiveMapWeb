using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class ServiceReportSeeder: ISeeder<ServiceReport>
{
    public List<ServiceReport> Seed()
    {
        var list = new List<ServiceReport>
        {
            new()
            {
                Id = 1,
                Title = "report 1",
                Description = "description1",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 1
            },
            new()
            {
                Id = 2,
                Title = "report 2",
                Description = "description2",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 1
            },
            new()
            {
                Id = 3,
                Title = "report 3",
                Description = "description3",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 1
            }
        };
        return list;
    }
}