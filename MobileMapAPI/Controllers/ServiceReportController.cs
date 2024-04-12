using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("facilities/service-reports")]
public class ServiceReportController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public ServiceReportController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServiceReports()
    {
        var serviceReports = await _context.ServiceReports
            .Include(i => i.Facility)
            .Include(i => i.User)
            .ToListAsync();
        return Ok(serviceReports);
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceReport(ServiceReport data)
    {
        var belongsTo = await _context.Facilities.FindAsync(data.FacilityId);
        var user = await _context.Users.FindAsync(data.UserId);

        if (belongsTo == null)
        {
            return NotFound("Could not find provided Facility");
        }

        if (user == null)
        {
            return NotFound("Could not find provided User");
        }

        var newServiceReport = new ServiceReport()
        {
            Title = data.Title,
            Description = data.Description,
            Category = data.Category,
            FacilityId = data.FacilityId,
            Facility = belongsTo,
            UserId = data.UserId,
            User = user
        };

        await _context.ServiceReports.AddAsync(newServiceReport);
        await _context.SaveChangesAsync();

        return Ok("New service report has been saved");
    }

    [HttpPatch("{reportId:int}/cancel")]
    public async Task<IActionResult> CancelReport(int reportId)
    {
        var serviceReport = await _context.ServiceReports.FindAsync(reportId);

        if (serviceReport == null)
        {
            return NotFound("Report not found");
        }

        if (serviceReport.Status != ReportStatus.Pending)
        {
            return BadRequest("Report is already in progress or has been completed, so it cannot be cancelled.");
        }

        serviceReport.Status = ReportStatus.Cancelled;
        await _context.SaveChangesAsync();
        return Ok("Report has been succesfully cancelled");
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = new[]
        {
            new { name = "name1" },
            new { name = "name2" },
            new { name = "name3" }
        };

        return Ok(categories);
    }
}