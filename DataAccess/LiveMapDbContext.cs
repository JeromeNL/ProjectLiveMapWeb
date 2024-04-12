using DataAccess.Models;
using DataAccess.Models.Base;
using DataAccess.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class LiveMapDbContext : DbContext
{
    public LiveMapDbContext(DbContextOptions<LiveMapDbContext> options) : base(options)
    {
    }
    
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<FacilityReport> FacilityReports { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<ProposedFacility> ProposedFacilities { get; set; }
    
    public DbSet<ServiceReport> ServiceReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.InitializeSeedData();

        modelBuilder.Entity<FacilityReport>()
            .Property(report => report.CreatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<FacilityReport>()
            .Property(report => report.Status).HasDefaultValue(FacilityReportStatus.Pending);
        
        modelBuilder.Entity<Facility>()
            .HasQueryFilter(x => x.DeletedAt == null);
    }
}