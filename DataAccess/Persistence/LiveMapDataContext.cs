using Microsoft.EntityFrameworkCore;

namespace DataAccess.Persistence;

public class LiveMapDataContext : DbContext
{
    public LiveMapDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=LiveMap;User Id=root;Password=root;");
        base.OnConfiguring(optionsBuilder);
    }
}