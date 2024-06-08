using DataAccess;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("resorts/{resortId:int}/facilities/facility-reports")]
public class FacilityReportController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFacilityReports(int resortId)
    {
        var facilityReports = await context.FacilityReports
            .Where(report => report.HolidayResortId == resortId)
            .Include(report => report.ProposedFacility)
            .Include(report => report.ApplicationUser)
            .ToListAsync();
        return Ok(facilityReports);
    }
    
    [HttpGet("{reportId:int}")]
    public async Task<IActionResult> GetFacilityReport(int reportId)
    {
        var facilityReport = await context.FacilityReports
            .Include(report => report.ProposedFacility)
            .Include(report => report.ApplicationUser)
            .FirstOrDefaultAsync(report => report.Id == reportId);

        if (facilityReport == null)
        {
            return NotFound("Report not found");
        }

        return Ok(facilityReport);
    }
    
    [HttpPatch("{reportId:int}/cancel")]
    public async Task<IActionResult> CancelReport(int reportId)
    {
        var facilityReport = await context.FacilityReports.FindAsync(reportId);

        if (facilityReport == null)
        {
            return NotFound("Report not found");
        }

        if (facilityReport.Status != ReportStatus.Pending)
        {
            return BadRequest("Report is already in progress or has been completed, so it cannot be cancelled.");
        }

        facilityReport.Status = ReportStatus.Cancelled;
        await context.SaveChangesAsync();
        return Ok("Report has been succesfully cancelled");
    }
}