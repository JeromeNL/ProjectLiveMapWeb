using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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