using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace WebPortal.Services;

public interface IResortService
{
    Task<List<HolidayResort>> GetResorts();
    
    Task<HolidayResort?> FirstOrDefaultAsync();

    Task<HolidayResort?> GetCurrentResort();
}

public class ResortService(LiveMapDbContext context) : IResortService
{
    public async Task<List<HolidayResort>> GetResorts()
    {
        return await context.HolidayResorts.ToListAsync();
    }
    
    public async Task<HolidayResort?> FirstOrDefaultAsync()
    {
        return await context.HolidayResorts.FirstOrDefaultAsync();
    }
    
    public async Task<HolidayResort?> GetCurrentResort()
    {
        return await context.HolidayResorts.FirstOrDefaultAsync();
    }
}