using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("openinghours")]
public class OpeningHoursController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public OpeningHoursController(LiveMapDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOpeningHoursForWeek(int facilityId, int weekNumber, int year)
    {
        var openingHours = 
            await _context.DefaultOpeningHours
                .Where(e => e.FacilityId == facilityId)
                .ToListAsync();
        
        
        return Ok(openingHours);
    }
}