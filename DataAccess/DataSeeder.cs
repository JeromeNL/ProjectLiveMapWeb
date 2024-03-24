using DataAccess.Models;
using DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class DataSeeder
{
    public static void InitializeSeedData(this ModelBuilder modelBuilder)
    {
        var facilities = new FacilitySeeder().Seed();
        var proposedFacilities = new ProposedFacilitySeeder(facilities).Seed();
        var facilityReports = new FacilityReportSeeder(proposedFacilities).Seed();
        var users = new UserSeeder().Seed();
        
        modelBuilder.Entity<Facility>().HasData(facilities);
        modelBuilder.Entity<ProposedFacility>().HasData(proposedFacilities);
        modelBuilder.Entity<FacilityReport>().HasData(facilityReports);

        modelBuilder.Entity<User>().HasData(GenerateUsers());
    }

    private static List<User> GenerateUsers()
    {
        var users = new List<User>()
        {
            new()
            {
                Id = -1,
                Name = "Almior"
            },
            new()
            {
                Id = -2,
                Name = "Joram"
            }
        };
        return users;
    }

    private static List<Facility> GenerateFacilities()
    {
        var facilities = new List<Facility>()
        {
            new()
            {
                Id = -1,
                Name = "Sportveld",
                Description =
                    "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.",
                Type = "Sport",
                Latitude = 51.34343422501585,
                Longitude = 5.246223807334901,
                IconUrl = "https://cdn-icons-png.flaticon.com/512/4344/4344985.png"
            },
            new()
            {
                Id = -2,
                Name = "Zwemmeer",
                Description =
                    "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                Type = "Recreatie",
                Latitude = 51.3417225445989,
                Longitude = 5.245537161827088,
                IconUrl = "https://cdn-icons-png.freepik.com/512/50/50004.png"
            },
        };
        return facilities;
    }

    private static List<FacilityReport> GenerateFacilityReports()
    {
        var facilityReports = new List<FacilityReport>()
        {
            new()
            {
                Id = -1,
                FacilityId = -1,
                Description = "Het sportveld is in goede staat.",
                Status = FacilityReportStatus.Pending,
                CreatedAt = DateTime.Now,
                ProposedFacilityChangeId = -1
            },
            new()
            {
                Id = -2,
                FacilityId = -2,
                Description = "Het zwemmeer is in goede staat.",
                Status = FacilityReportStatus.Pending,
                CreatedAt = DateTime.Now,
                ProposedFacilityChangeId = -2
            }
        };

        return facilityReports;
    }

    private static List<ProposedFacilityChange> GenerateChanges()
    {
        var changes = new List<ProposedFacilityChange>()
        {
            new()
            {
                Id = -1,
                Name = "Sportveld Hoevelake",
                Description =
                    "Op het sportveld kun je allerlei activiteiten doen. Denk aan voetballen, basketballen en tennissen.",
                Type = "Sport",
                Latitude = 51.34343422501585,
                Longitude = 5.246223807334901,
                IconUrl = "https://cdn-icons-png.flaticon.com/512/4344/4344985.png"
            },
            new()
            {
                Id = -2,
                Name = "Zwemmeer JAKDKJLDUIIRUFJK",
                Description =
                    "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                Type = "Recreatie",
                Latitude = 51.3417225445989,
                Longitude = 5.245537161827088,
                IconUrl = "https://cdn-icons-png.freepik.com/512/50/50004.png"
            },
        };
        return changes;

    }
}