using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class LiveMapDbContext : IdentityDbContext<ApplicationUser>
{
    public LiveMapDbContext(DbContextOptions<LiveMapDbContext> options) : base(options)
    {
    }

    public DbSet<Facility> Facilities { get; set; }
    public DbSet<FacilityReport> FacilityReports { get; set; }

    public DbSet<ProposedFacility> ProposedFacilities { get; set; }

    public DbSet<DefaultOpeningHours> DefaultOpeningHours { get; set; }

    public DbSet<SpecialOpeningHours> SpecialOpeningHours { get; set; }


    public DbSet<ServiceReport> ServiceReports { get; set; }

    public DbSet<ServiceReportCategory> ServiceReportCategories { get; set; }

    public DbSet<FacilityCategory> FacilityCategories { get; set; }

    public DbSet<HolidayResort> HolidayResorts { get; set; }

    public DbSet<PointsTransaction> PointsTransactions { get; set; }

    public DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.InitializeSeedData();

        modelBuilder.Entity<FacilityReport>()
            .Property(report => report.CreatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<FacilityReport>()
            .Property(report => report.Status).HasDefaultValue(ReportStatus.Pending);

        modelBuilder.Entity<Facility>()
            .HasQueryFilter(x => x.DeletedAt == null);

        modelBuilder.Entity<DefaultOpeningHours>()
            .HasKey(o => new { o.WeekDay, o.FacilityId });

        modelBuilder.Entity<SpecialOpeningHours>()
            .HasKey(o => new { o.Date, o.FacilityId });

        modelBuilder.Entity<FacilityCategory>()
            .HasQueryFilter(x => x.DeletedAt == null);

        modelBuilder.Entity<ServiceReport>()
            .HasQueryFilter(x => x.DeletedAt == null);

        modelBuilder.Entity<HolidayResort>()
            .HasQueryFilter(x => x.DeletedAt == null);

        // This disables the cascade delete behavior globally
        // Normally this would be a no-go, but we're using soft delete, so a delete actually never triggers an SQL delete
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}