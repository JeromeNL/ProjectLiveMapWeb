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
}