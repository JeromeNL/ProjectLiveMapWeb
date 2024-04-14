using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataAccess.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController(LiveMapDbContext context) : ControllerBase
{
    [HttpPost("{name}")]
    public IActionResult PostUserByName(string name)
    {
        var user = context.Users.FirstOrDefault(u => u.Name == name);

        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }

    [HttpGet("{userId:int}/service-reports")]
    public async Task<IActionResult> GetSubmittedServiceReports(int userId)
    {
        var serviceReports = await context.ServiceReports
            .Include(report => report.Facility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId).ToListAsync();
        return Ok(serviceReports);
    }

    [HttpGet("{userId:int}/facility-reports")]
    public async Task<IActionResult> GetSubmittedFacilityReports(int userId)
    {
        var facilityReports = await context.FacilityReports
            .Include(report => report.ProposedFacility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId).ToListAsync();
        return Ok(facilityReports);
    }
}