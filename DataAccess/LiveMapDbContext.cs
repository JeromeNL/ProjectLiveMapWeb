using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class LiveMapDbContext : DbContext
{
    public LiveMapDbContext(DbContextOptions<LiveMapDbContext> options) : base(options)
    {
    }

    public DbSet<Facility> Facilities { get; set; }
    public DbSet<FacilityReport> FacilityReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.InitializeSeedData();
    }
}