using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("service_reports")]
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
        var serviceReports = await _context.ServiceReports.ToListAsync();
        return Ok(serviceReports);
    }

    [HttpPost]
    public async Task<IActionResult> AddServiceReport(ServiceReport data)
    {
        var belongsTo = await _context.Facilities.FindAsync(data.facilityId);

        if (belongsTo == null)
        {
            return NotFound("Could not find provided Facility");
        }
        
        var newFault = new ServiceReport()
        {
            title = data.title,
            description = data.description,
            category = data.category,
            facilityId = data.facilityId,
            Facility = belongsTo
        };

        await _context.ServiceReports.AddAsync(newFault);
        await _context.SaveChangesAsync();

        return Ok("New service report has been saved");
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