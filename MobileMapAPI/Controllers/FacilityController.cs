using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("facilities")]
public class FacilityController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public FacilityController(LiveMapDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllFacilities()
    {
        var facilities = await _context.Facilities.ToListAsync();
        return Ok(facilities);
    }
}
