using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace WebPortal.Services;

public interface IResortService
{
    Task<List<HolidayResort>> GetResorts();
    
    Task<HolidayResort?> FirstOrDefaultAsync();

    int? GetCurrentResortId();
    
    Task SetCurrentResortId(int resortId);
}

public class ResortService(LiveMapDbContext context, IHttpContextAccessor httpContextAccessor) : IResortService
{
    private readonly string resortSessionKey = "resortId"; 
    
    public async Task<List<HolidayResort>> GetResorts()
    {
        return await context.HolidayResorts.ToListAsync();
    }
    
    public async Task<HolidayResort?> FirstOrDefaultAsync()
    {
        return await context.HolidayResorts.FirstOrDefaultAsync();
    }
    
    public int? GetCurrentResortId()
    {
        return httpContextAccessor.HttpContext?.Session.GetInt32(resortSessionKey);
    }
    
    public async Task SetCurrentResortId(int resortId)
    {
        var resort = await context.HolidayResorts.FindAsync(resortId);
        if (resort == null)
        {
            throw new ArgumentException("Resort not found.");
        }
        httpContextAccessor.HttpContext?.Session.SetInt32(resortSessionKey, resortId);
    }
}