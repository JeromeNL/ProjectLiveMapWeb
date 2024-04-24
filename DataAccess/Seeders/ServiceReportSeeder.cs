using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class ServiceReportSeeder : ISeeder<ServiceReport>
{
    private readonly Random _random = new();

    public List<ServiceReport> Seed()
    {
        var serviceReports = new List<ServiceReport>();

        for (var i = 1; i <= 30; i++)
        {
            var report = new ServiceReport
            {
                Id = i,
                Title = $"report {i}",
                Description = $"description {i}",
                CreatedAt = DateTime.Now,
                FacilityId = GetRandomId(1, 3),
                ServiceReportCategoryId = GetRandomId(1, 6),
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            };

            serviceReports.Add(report);
        }

        return serviceReports;
    }

    // Helper method to generate a random integer within a specified range
    private int GetRandomId(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}