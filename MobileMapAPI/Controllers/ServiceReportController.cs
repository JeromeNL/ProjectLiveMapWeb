using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("resorts/{resortId:int}/facilities/service-reports")]
public class ServiceReportController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllServiceReports(int resortId)
    {
        var serviceReports = await context.ServiceReports
            .Where(report => report.HolidayResortId == resortId)
            .Include(report => report.Facility)
            .Include(report => report.User)
            .Include(report => report.ServiceReportCategory)
            .ToListAsync();
        
        return Ok(serviceReports);
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceReport(ServiceReport data, int resortId)
    {
        var belongsTo = await context.Facilities.FindAsync(data.FacilityId);
        var category = await context.ServiceReportCategories.FindAsync(data.ServiceReportCategoryId);
        var user = await context.Users.FindAsync(data.UserId);

        if (belongsTo == null)
        {
            return NotFound("Could not find provided Facility");
        }

        if (user == null)
        {
            return NotFound("Could not find provided ApplicationUser");
        }

        if (category == null)
        {
            return NotFound("Could not find provided ServiceReportCategory");
        }
        
        var newServiceReport = new ServiceReport()
        {
            Title = data.Title,
            Description = data.Description,
            CreatedAt = DateTime.Now,
            ServiceReportCategoryId = data.ServiceReportCategoryId,
            ServiceReportCategory = category,
            FacilityId = data.FacilityId,
            Facility = belongsTo,
            UserId = data.UserId,
            User = user,
            HolidayResortId = resortId
        };

        await context.ServiceReports.AddAsync(newServiceReport);
        await context.SaveChangesAsync();

        return Ok("New service report has been saved");
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories(int resortId)
    {
        var categories = await context.ServiceReportCategories
            .Where(category => category.HolidayResortId == resortId)
            .ToListAsync();
        return Ok(categories);
    }
}