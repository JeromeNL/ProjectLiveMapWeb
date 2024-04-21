using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("resorts")]
public class ResortController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllResorts()
    {
        var resorts = await context.HolidayResorts.ToListAsync();
        return Ok(resorts);
    }
}