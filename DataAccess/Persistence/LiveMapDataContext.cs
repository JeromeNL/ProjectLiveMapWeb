using Microsoft.EntityFrameworkCore;

namespace DataAccess.Persistence;

public class LiveMapDataContext : DbContext
{
    public LiveMapDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        base.OnConfiguring(optionsBuilder);
    }
}