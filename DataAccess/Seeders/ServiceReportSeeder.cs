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
            },
            new ()
            {
                Id = 4,
                Title = "report 4",
                Description = "description4",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 1
            },
            new ()
            {
                Id = 5,
                Title = "report 5",
                Description = "description5",
                FacilityId = 2,
                ServiceReportCategoryId = 2,
                UserId = 2
            },
            new ()
            {
                Id = 6,
                Title = "report 6",
                Description = "description6",
                FacilityId = 3,
                ServiceReportCategoryId = 3,
                UserId = 3
            },
            new ()
            {
                Id = 7,
                Title = "report 7",
                Description = "description7",
                FacilityId = 1,
                ServiceReportCategoryId = 4,
                UserId = 4
            },
            new ()
            {
                Id = 8,
                Title = "report 8",
                Description = "description8",
                FacilityId = 2,
                ServiceReportCategoryId = 5,
                UserId = 5
            },
            new ()
            {
                Id = 9,
                Title = "report 9",
                Description = "description9",
                FacilityId = 3,
                ServiceReportCategoryId = 6,
                UserId = 6
            },
            new ()
            {
                Id = 10,
                Title = "report 10",
                Description = "description10",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 1
            },
            new ()
            {
                Id = 11,
                Title = "report 11",
                Description = "description11",
                FacilityId = 2,
                ServiceReportCategoryId = 2,
                UserId = 2
            },
            new ()
            {
                Id = 12,
                Title = "report 12",
                Description = "description12",
                FacilityId = 3,
                ServiceReportCategoryId = 3,
                UserId = 3
            },
            new ()
            {
                Id = 13,
                Title = "report 13",
                Description = "description13",
                FacilityId = 1,
                ServiceReportCategoryId = 4,
                UserId = 4
            },
            new ()
            {
                Id = 14,
                Title = "report 14",
                Description = "description14",
                FacilityId = 2,
                ServiceReportCategoryId = 5,
                UserId = 5
            },
            new ()
            {
                Id = 15,
                Title = "report 15",
                Description = "description15",
                FacilityId = 3,
                ServiceReportCategoryId = 6,
                UserId = 6
            },
            new ()
            {
                Id = 16,
                Title = "report 16",
                Description = "description16",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 2
            },
            new ()
            {
                Id = 17,
                Title = "report 17",
                Description = "description17",
                FacilityId = 2,
                ServiceReportCategoryId = 2,
                UserId = 3
            },
            new ()
            {
                Id = 18,
                Title = "report 18",
                Description = "description18",
                FacilityId = 3,
                ServiceReportCategoryId = 3,
                UserId = 4
            },
            new ()
            {
                Id = 19,
                Title = "report 19",
                Description = "description19",
                FacilityId = 1,
                ServiceReportCategoryId = 4,
                UserId = 5
            },
            new ()
            {
                Id = 20,
                Title = "report 20",
                Description = "description20",
                FacilityId = 2,
                ServiceReportCategoryId = 5,
                UserId = 6
            },
            new ()
            {
                Id = 21,
                Title = "report 21",
                Description = "description21",
                FacilityId = 3,
                ServiceReportCategoryId = 6,
                UserId = 1
            },
            new ()
            {
                Id = 22,
                Title = "report 22",
                Description = "description22",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 2
            },
            new ()
            {
                Id = 23,
                Title = "report 23",
                Description = "description23",
                FacilityId = 2,
                ServiceReportCategoryId = 2,
                UserId = 3
            },
            new ()
            {
                Id = 24,
                Title = "report 24",
                Description = "description24",
                FacilityId = 3,
                ServiceReportCategoryId = 3,
                UserId = 4
            },
            new ()
            {
                Id = 25,
                Title = "report 25",
                Description = "description25",
                FacilityId = 1,
                ServiceReportCategoryId = 4,
                UserId = 5
            },
            new ()
            {
                Id = 26,
                Title = "report 26",
                Description = "description26",
                FacilityId = 2,
                ServiceReportCategoryId = 5,
                UserId = 6
            },
            new ()
            {
                Id = 27,
                Title = "report 27",
                Description = "description27",
                FacilityId = 3,
                ServiceReportCategoryId = 6,
                UserId = 1
            },
            new ()
            {
                Id = 28,
                Title = "report 28",
                Description = "description28",
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = 2
            },
            new ()
            {
                Id = 29,
                Title = "report 29",
                Description = "description29",
                FacilityId = 2,
                ServiceReportCategoryId = 2,
                UserId = 3
            },
            new()
            {
                Id = 30,
                Title = "report 30",
                Description = "description30",
                FacilityId = 3,
                ServiceReportCategoryId = 3,
                UserId = 4
            }
        };
        return list;
    }
}