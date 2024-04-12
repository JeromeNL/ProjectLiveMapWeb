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
        var serviceReports = new ServiceReportSeeder().Seed();
        var serviceReportsCategories = new ServiceReportCategorySeeder().Seed();
        
        modelBuilder.Entity<Facility>().HasData(facilities);
        modelBuilder.Entity<ProposedFacility>().HasData(proposedFacilities);
        modelBuilder.Entity<FacilityReport>().HasData(facilityReports);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<ServiceReport>().HasData(serviceReports);
        modelBuilder.Entity<ServiceReportCategory>().HasData(serviceReportsCategories);
    }
}