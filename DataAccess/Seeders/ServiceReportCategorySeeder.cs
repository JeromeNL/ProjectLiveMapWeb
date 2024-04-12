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
                Name = "category 1"
            },
            new()
            {
                Id = 2,
                Name = "category 2"
            },
            new()
            {
                Id = 3,
                Name = "category 3"
            }
        };
        return list;
    }
}